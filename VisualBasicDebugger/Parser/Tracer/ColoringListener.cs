using Antlr4.Runtime.Misc;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualBasicDebugger.Grammars.Generated;

namespace VisualBasicDebugger.Parser.Tracer {
    public class ColoringListener : VisualBasic6ParserBaseListener {
        private Scintilla _doc;

        public ColoringListener(Scintilla doc) {
            _doc = doc;
        }

        public override void EnterForEachStmt(VisualBasic6Parser.ForEachStmtContext context) {
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.FOR().GetText().Length, 1);

            _doc.StartStyling(context.NEXT().Symbol.StartIndex);
            _doc.SetStyling(context.NEXT().GetText().Length, 1);
        }

        public override void EnterWhileWendStmt(VisualBasic6Parser.WhileWendStmtContext context) {
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.WHILE().GetText().Length, 1);

            _doc.StartStyling(context.WEND().Symbol.StartIndex);
            _doc.SetStyling(context.WEND().GetText().Length, 1);
        }
    }
}
