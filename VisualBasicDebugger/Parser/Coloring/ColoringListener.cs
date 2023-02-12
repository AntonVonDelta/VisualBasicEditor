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

namespace VisualBasicDebugger.Parser.Coloring {
    public class ColoringListener : VisualBasic6ParserBaseListener {
        public class VariableData {
            public string Name { get; set; }
            public string Type { get; set; }
        }

        private Scintilla _doc;
        private CheckpointStack<VariableData> _scope = new CheckpointStack<VariableData>();
        private int _startLine;
        private int _stopLine;

        public ColoringListener(Scintilla doc, int startLine, int stopLine) {
            _doc = doc;
            _startLine = startLine;
            _stopLine = stopLine;
        }

        private bool ShouldStyle(int line) {
            return true;// _startLine <= line && line <= _stopLine;
        }

        private void AddFunctionScope(VisualBasic6Parser.FunctionStmtContext context) {
            var functionName = context.ambiguousIdentifier().GetText();
            var functionType = context.asTypeClause()?.type_()?.GetText() ?? "Variant";

            _scope = new CheckpointStack<VariableData>();
            _scope.AddCheckpoint();

            // Add arguments to scoped variables
            foreach (var arg in context.argList().arg()) {
                var argType = arg.asTypeClause().type_().GetText();

                _scope.Add(new VariableData() {
                    Name = arg.ambiguousIdentifier().GetText(),
                    Type = argType
                });
            }

            // Add function name itself to variable list
            _scope.Add(new VariableData() {
                Name = functionName,
                Type = functionType
            });
        }

        public override void EnterFunctionStmt(VisualBasic6Parser.FunctionStmtContext context) {
            AddFunctionScope(context);

            if (!ShouldStyle(context.start.Line)) return;

            // Clear previous styling
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.GetText().Length, 0);

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.FUNCTION().GetText().Length, 1);

            _doc.StartStyling(context.ambiguousIdentifier().start.StartIndex);
            _doc.SetStyling(context.ambiguousIdentifier().GetText().Length, 3);

            if (context.asTypeClause()?.type_() != null) {
                _doc.StartStyling(context.asTypeClause().type_().start.StartIndex);
                _doc.SetStyling(context.asTypeClause().type_().GetText().Length, 3);
            }

            _doc.StartStyling(context.END_FUNCTION().Symbol.StartIndex);
            _doc.SetStyling(context.END_FUNCTION().GetText().Length, 1);
        }

        public override void EnterBlock(VisualBasic6Parser.BlockContext context) {
            _scope.AddCheckpoint();
        }

        public override void ExitBlock(VisualBasic6Parser.BlockContext context) {
            _scope.ReverseCheckpoint();
        }

        // Color for syntax
        public override void EnterForEachStmt(VisualBasic6Parser.ForEachStmtContext context) {
            if (!ShouldStyle(context.start.Line)) return;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.FOR().GetText().Length, 1);

            if (context.EACH() != null) {
                _doc.StartStyling(context.EACH().Symbol.StartIndex);
                _doc.SetStyling(context.EACH().GetText().Length, 1);
            }

            _doc.StartStyling(context.NEXT().Symbol.StartIndex);
            _doc.SetStyling(context.NEXT().GetText().Length, 1);
        }

        // Color while syntax
        public override void EnterWhileWendStmt(VisualBasic6Parser.WhileWendStmtContext context) {
            if (!ShouldStyle(context.start.Line)) return;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.WHILE().GetText().Length, 1);

            _doc.StartStyling(context.WEND().Symbol.StartIndex);
            _doc.SetStyling(context.WEND().GetText().Length, 1);
        }

        // Color the 'dim' keyword from 'dim a as type'
        public override void EnterVariableStmt(VisualBasic6Parser.VariableStmtContext context) {
            if (!ShouldStyle(context.start.Line)) return;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.DIM().GetText().Length, 1);
        }

        public override void EnterVariableSubStmt(VisualBasic6Parser.VariableSubStmtContext context) {
            var variableName = context.ambiguousIdentifier().GetText();
            var variableType = context.asTypeClause()?.type_()?.GetText() ?? "Variant";

            _scope.Add(new VariableData() { Name = variableName, Type = variableType });
        }

        // Color the variable type in 'dim a as type'
        public override void EnterType_(VisualBasic6Parser.Type_Context context) {
            if (!ShouldStyle(context.start.Line)) return;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.GetText().Length, 1);
        }

        // Color set in 'set a=b'
        public override void EnterSetStmt(VisualBasic6Parser.SetStmtContext context) {
            if (!ShouldStyle(context.start.Line)) return;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.SET().GetText().Length, 1);
        }

        public override void EnterICS_S_VariableOrProcedureCall(VisualBasic6Parser.ICS_S_VariableOrProcedureCallContext context) {
            var itemName = context.ambiguousIdentifier().GetText();

            if (!ShouldStyle(context.start.Line)) return;
            if (_scope.Contains(el => el.Name.ToLower() == itemName.ToLower())) {
                _doc.StartStyling(context.ambiguousIdentifier().start.StartIndex);
                _doc.SetStyling(context.ambiguousIdentifier().GetText().Length, 2);
            }
        }

        public override void EnterICS_S_ProcedureOrArrayCall(VisualBasic6Parser.ICS_S_ProcedureOrArrayCallContext context) {
            if (!ShouldStyle(context.start.Line)) return;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.ambiguousIdentifier().GetText().Length, 3);
        }
    }
}
