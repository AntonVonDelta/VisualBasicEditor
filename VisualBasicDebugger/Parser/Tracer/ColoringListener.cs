using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualBasicDebugger.Grammars.Generated;

namespace VisualBasicDebugger.Parser.Tracer {
    public class ColoringListener : VisualBasic6ParserBaseListener {
        private RichTextBox _doc;

        public ColoringListener(RichTextBox doc) {
            _doc = doc;
        }
        public override void EnterForEachStmt(VisualBasic6Parser.ForEachStmtContext context) {
            _doc.Select(context.start.StartIndex, context.FOR().GetText().Length);
            _doc.SelectionColor = System.Drawing.Color.Blue;
        }
    }
}
