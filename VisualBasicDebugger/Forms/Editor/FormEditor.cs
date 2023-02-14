using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VisualBasicDebugger.Grammars.Generated;
using VisualBasicDebugger.Parser;
using VisualBasicDebugger.Parser.Tracer;
using VisualBasicDebugger.Parser.Utils;
using System.Linq;
using System.Drawing;
using ScintillaNET;
using System.Threading.Tasks;
using VisualBasicDebugger.Parser.Coloring;

namespace VisualBasicDebugger.Forms.Editor {
    public partial class FormEditor : Form {
        private Tuple<int, VisualBasic6Parser.StartRuleContext> cachedTree;
        private Task<VisualBasic6Parser.StartRuleContext> _stylingTask;
        private TaskCompletionSource<bool> _closeFormTask;

        public FormEditor(string projectPath) {
            InitializeComponent();
        }


        private Task<bool> ShouldCancelClose() {
            if (_closeFormTask == null) _closeFormTask = new TaskCompletionSource<bool>();
            return _closeFormTask.Task;
        }

        private void SetStyles() {
            // Control statements
            mainTextEditor.Styles[1].ForeColor = Color.Blue;

            // Variables
            mainTextEditor.Styles[2].ForeColor = Color.FromArgb(33, 170, 216);

            // Function calls
            mainTextEditor.Styles[3].ForeColor = Color.SaddleBrown;

            // Unused variable indicator
            mainTextEditor.Indicators[0].Style = IndicatorStyle.StraightBox;
            mainTextEditor.Indicators[0].ForeColor = Color.Brown;

            mainTextEditor.MouseDwellTime = 400;
            mainTextEditor.Styles[Style.CallTip].SizeF = 8.25f;
            mainTextEditor.Styles[Style.CallTip].ForeColor = SystemColors.InfoText;
            mainTextEditor.Styles[Style.CallTip].BackColor = SystemColors.Info;
        }

        private async Task<VisualBasic6Parser.StartRuleContext> GetTree(string input) {
            if (cachedTree != null && cachedTree.Item1 == input.GetHashCode()) return cachedTree.Item2;

            try {
                var charStream = new CaseInsensitiveStream(input);
                var lexer = new VisualBasic6Lexer(charStream);
                CommonTokenStream tokenStream;
                VisualBasic6Parser.StartRuleContext tree;
                VisualBasic6Parser parser;

                tokenStream = new CommonTokenStream(lexer);
                parser = new VisualBasic6Parser(tokenStream);

                tree = await Task.Run(() => {
                    return parser.startRule();
                });

                cachedTree = new Tuple<int, VisualBasic6Parser.StartRuleContext>(input.GetHashCode(), tree);

                return tree;
            } catch { }

            return null;
        }

        private async void StartCodeAnalysis() {
            while (_closeFormTask == null) {
                string input;
                VisualBasic6Parser.StartRuleContext tree;

                input = mainTextEditor.Text;
                tree = await GetTree(input);
                if (tree == null) return;

                // Process data for unused variables
                mainTextEditor.IndicatorClearRange(0, mainTextEditor.TextLength);

                try {

                    var parserTreeWalker = new ParseTreeWalker();
                    var unusedVariablesListener = new UnusedVariableListener();
                    parserTreeWalker.Walk(unusedVariablesListener, tree);

                    if (unusedVariablesListener.Result != null) {
                        foreach (var item in unusedVariablesListener.Result) {
                            mainTextEditor.IndicatorCurrent = 0;
                            mainTextEditor.IndicatorFillRange(item.StartPosition, item.EndPosition - item.StartPosition + 1);
                        }
                    }
                } catch {

                }

                while (_closeFormTask == null) {
                    await Task.Delay(2000);
                    if (input != mainTextEditor.Text) break;
                }
            }

            _closeFormTask.SetResult(false);
        }

        private async void StartCodeStyling(StyleNeededEventArgs eventArgs) {
            var startLine = mainTextEditor.LineFromPosition(mainTextEditor.GetEndStyled());
            var stopLine = mainTextEditor.LineFromPosition(eventArgs.Position);
            VisualBasic6Parser.StartRuleContext tree;
            ColoringListener coloringListener = new ColoringListener(mainTextEditor, startLine, stopLine);

            if (_stylingTask != null && !_stylingTask.IsCompleted) return;

            _stylingTask = GetTree(mainTextEditor.Text);
            tree = await _stylingTask;

            if (tree == null) return;

            try {
                var parserTreeWalker = new ParseTreeWalker();

                // Apply our coloring
                parserTreeWalker.Walk(coloringListener, tree);
            } catch { }
        }

        private void SetChangeHistory(int changeHistory) {
            // This is needed for history changes to work
            mainTextEditor.EmptyUndoBuffer();

            mainTextEditor.DirectMessage(2780, new IntPtr(changeHistory), IntPtr.Zero);
        }

        private string GetUnusedVariableAtPosition(int position) {
            var indicator = mainTextEditor.Indicators[0];
            var bitmapFlag = 1 << indicator.Index;
            var bitmap = mainTextEditor.IndicatorAllOnFor(position);
            var hasIndicator = ((bitmapFlag & bitmap) == bitmapFlag);

            if (hasIndicator) {
                var startPos = indicator.Start(position);
                var endPos = indicator.End(position);

                var text = mainTextEditor.GetTextRange(startPos, endPos - startPos).Trim();
                return text;
            }

            return null;
        }

        private void UpdateLineNumbers() {
            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var maxLineNumberCharLength = mainTextEditor.Lines.Count.ToString().Length;

            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;

            mainTextEditor.Margins[0].Width = mainTextEditor.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
        }


        private void Form1_Load(object sender, EventArgs e) {
            SetStyles();
            StartCodeAnalysis();
            UpdateLineNumbers();
            SetChangeHistory(3);

            tabPage1.Enabled = false;
            mainTextEditor.Margins[1].Width = 20;

            mainTextEditor.StyleNeeded += (object eventSender, StyleNeededEventArgs eventArgs) => {
                StartCodeStyling(eventArgs);
            };

            mainTextEditor.DwellStart += (object eventSender, DwellEventArgs eventArgs) => {
                if (GetUnusedVariableAtPosition(eventArgs.Position) != null)
                    mainTextEditor.CallTipShow(eventArgs.Position, "Unused variable");
            };

            mainTextEditor.DwellEnd += (object eventSender, DwellEventArgs eventArgs) => {
                mainTextEditor.CallTipCancel();
            };


            mainTextEditor.TextChanged += (object eventSender, EventArgs eventArgs) => {
                UpdateLineNumbers();
            };

            mainTextEditor.ZoomChanged += (object eventSender, EventArgs eventArgs) => {
                UpdateLineNumbers();
            };
        }

        private static string GetIndexesForList(List<TraceVariableData> list) {
            List<string> result = new List<string>();

            for (int i = 0; i < list.Count; i++) {
                result.Add($"{list[i].Name} {{{i}}}");
            }
            return string.Join(", ", result);
        }

        private async void btnGenerateTraceCode_Click(object sender, EventArgs e) {
            var input = mainTextEditor.Text;
            TracerVisitor tracerVisitor;
            VisualBasic6Parser.StartRuleContext tree;
            List<string> lines = input.Split('\n').ToList();

            tree = await GetTree(mainTextEditor.Text);
            tracerVisitor = new TracerVisitor();
            tracerVisitor.Visit(tree);

            foreach (var functionTrace in tracerVisitor.Result) {
                var functionName = functionTrace.ParentFunction.Name;

                for (int i = functionTrace.Traces.Count - 1; i >= 0; i--) {
                    var traceLine = functionTrace.Traces[i];
                    var lineNr = traceLine.Line;
                    string trace;

                    if (traceLine.VariableTraces.Count == 0) {
                        trace = $"\tLog \"[{functionName}:{lineNr + i + 1}]\", \"\"";
                    } else {
                        var variableNames = string.Join(", ", traceLine.VariableTraces.Select(el => el.Name));
                        trace = $"\tLog \"[{functionName}:{lineNr + i + 1}]\", \"{GetIndexesForList(traceLine.VariableTraces)}\",{variableNames}";
                    }

                    lines.Insert(lineNr - 1, trace);
                }
            }

            mainTextEditor.Text = string.Join("\n", lines);
        }

        private async void FormEditor_FormClosing(object sender, FormClosingEventArgs e) {
            var cancelCloseTask = ShouldCancelClose();

            if (cancelCloseTask.IsCompleted) {
                if (await cancelCloseTask) e.Cancel = true;
                return;
            }

            e.Cancel = true;

            if (!await cancelCloseTask) {
                Close();
            }
        }
    }
}
