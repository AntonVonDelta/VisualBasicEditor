using Antlr4.Runtime.Misc;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualBasicDebugger.Grammars.Generated;
using VisualBasicDebugger.Utils;

namespace VisualBasicDebugger.Parser.Tracer {
    public class ColoringListener : VisualBasic6ParserBaseListener {
        public class VariableData {
            public string Name { get; set; }
            public string Type { get; set; }
        }

        private Scintilla _doc;
        private CheckpointStack<VariableData> _scope = new CheckpointStack<VariableData>();


        public ColoringListener(Scintilla doc) {
            _doc = doc;
        }

        //Ics_s_variableorproceudre -> filter out variables for procedures
        //ICs_s_procedureorarray

        public override void EnterFunctionStmt(VisualBasic6Parser.FunctionStmtContext context) {
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.FUNCTION().GetText().Length, 1);

            _doc.StartStyling(context.END_FUNCTION().Symbol.StartIndex);
            _doc.SetStyling(context.END_FUNCTION().GetText().Length, 1);
        }

        // Color for syntax
        public override void EnterForEachStmt(VisualBasic6Parser.ForEachStmtContext context) {
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.FOR().GetText().Length, 1);

            _doc.StartStyling(context.NEXT().Symbol.StartIndex);
            _doc.SetStyling(context.NEXT().GetText().Length, 1);
        }

        // Color while syntax
        public override void EnterWhileWendStmt(VisualBasic6Parser.WhileWendStmtContext context) {
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.WHILE().GetText().Length, 1);

            _doc.StartStyling(context.WEND().Symbol.StartIndex);
            _doc.SetStyling(context.WEND().GetText().Length, 1);
        }

        // Color the 'dim' keyword from 'dim a as type'
        public override void EnterVariableStmt(VisualBasic6Parser.VariableStmtContext context) {
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.DIM().GetText().Length, 1);
        }

        // Color the variable type in 'dim a as type'
        public override void EnterType_(VisualBasic6Parser.Type_Context context) {
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.GetText().Length, 1);
        }

        // Color set in 'set a=b'
        public override void EnterSetStmt(VisualBasic6Parser.SetStmtContext context) {
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.SET().GetText().Length, 1);
        }
    }
}
