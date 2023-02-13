﻿using Antlr4.Runtime;
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

namespace VisualBasicDebugger {
    public partial class Form1 : Form {
        private Tuple<int, VisualBasic6Parser.StartRuleContext> cachedTree;
        private Task<VisualBasic6Parser.StartRuleContext> _stylingTask;

        public Form1() {
            InitializeComponent();
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
            while (true) {
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

                while (true) {
                    await Task.Delay(2000);
                    if (input != mainTextEditor.Text) break;
                }
            }
        }

        private async void StartCodeStyling(StyleNeededEventArgs eventArgs) {
            var input = mainTextEditor.Text;
            var inputLength = mainTextEditor.TextLength;
            var startLine = mainTextEditor.LineFromPosition(mainTextEditor.GetEndStyled());
            var stopLine = eventArgs.Position;
            VisualBasic6Parser.StartRuleContext tree;
            ColoringListener coloringListener = new ColoringListener(mainTextEditor, startLine, stopLine);

            if (_stylingTask != null && !_stylingTask.IsCompleted) return;

            _stylingTask = GetTree(input);

            tree = await _stylingTask;
            if (tree == null) return;

            try {
                var parserTreeWalker = new ParseTreeWalker();

                // Apply our coloring
                parserTreeWalker.Walk(coloringListener, tree);
            } catch { }
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

            // Set line numbering margin width
            mainTextEditor.Margins[0].Width = 35;

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

        private void btnGenerateTraceCode_Click(object sender, EventArgs e) {
            //var input = txtDocument.Text;
            //var charStream = new CaseInsensitiveStream(input);
            //var lexer = new VisualBasic6Lexer(charStream);
            //var tokenStream = new CommonTokenStream(lexer);

            //var parser = new VisualBasic6Parser(tokenStream);
            //var tree = parser.startRule();

            //var tracerVisitor = new TracerVisitor();
            //tracerVisitor.Visit(tree);

            //var finalCode = "";
            //foreach (var functionTrace in tracerVisitor.Result) {
            //    var functionName = functionTrace.ParentFunction.Name;

            //    foreach (var traceLine in functionTrace.Traces) {
            //        var lineNr = traceLine.Line;
            //        var trace = "";

            //        if (traceLine.VariableTraces.Count == 0) {
            //            trace = $"Log \"[{functionName}:{lineNr}]\", \"\"";
            //        } else {
            //            var variableNames = string.Join(", ", traceLine.VariableTraces.Select(el => el.Name));
            //            trace = $"Log \"[{functionName}:{lineNr}]\", \"{GetIndexesForList(traceLine.VariableTraces)}\",{variableNames}";
            //        }

            //        finalCode += $"{trace}\r\n";
            //    }
            //}

            //textBox2.Text = finalCode;
        }

        private static string GetIndexesForList(List<TraceVariableData> list) {
            List<string> result = new List<string>();

            for (int i = 0; i < list.Count; i++) {
                result.Add($"{list[i].Name} {{{i}}}");
            }
            return string.Join(", ", result);
        }
    }
}
