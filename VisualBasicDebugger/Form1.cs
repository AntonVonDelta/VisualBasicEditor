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

namespace VisualBasicDebugger {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //mainTextEditor.LexerName = "Container";
        }

        private void btnUnusedVariables_Click(object sender, EventArgs e) {
            //var input = txtDocument.Text;
            //var charStream = new CaseInsensitiveStream(input);
            //var lexer = new VisualBasic6Lexer(charStream);
            //var tokenStream = new CommonTokenStream(lexer);

            //var parser = new VisualBasic6Parser(tokenStream);
            //var tree = parser.startRule();

            //var parserTreeWalker = new ParseTreeWalker();
            //var unusedVariablesListener = new UnusedVariableListener();
            //parserTreeWalker.Walk(unusedVariablesListener, tree);

            //listView1.Items.Clear();
            //foreach (var item in unusedVariablesListener.Result) {
            //    var listItem = new ListViewItem(item.Line.ToString());

            //    listItem.SubItems.Add(item.Name);
            //    listItem.SubItems.Add(item.Type);
            //    listView1.Items.Add(listItem);
            //}
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

        private void btnColorize_Click(object sender, EventArgs e) {
            //ColoringListener coloringListener = new ColoringListener(txtDocument);

            //var input = txtDocument.Text;
            //var charStream = new CaseInsensitiveStream(input);
            //var lexer = new VisualBasic6Lexer(charStream);
            //var tokenStream = new CommonTokenStream(lexer);

            //var parser = new VisualBasic6Parser(tokenStream);
            //var tree = parser.startRule();

            //var parserTreeWalker = new ParseTreeWalker();
            //parserTreeWalker.Walk(coloringListener, tree);
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
