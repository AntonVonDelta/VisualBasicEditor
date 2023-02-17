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

        private void AddSubScope(VisualBasic6Parser.SubStmtContext context) {
            _scope.AddCheckpoint();

            // Add arguments to scoped variables
            foreach (var arg in context.argList().arg()) {
                var argType = arg.asTypeClause().type_().GetText();

                _scope.Add(new VariableData() {
                    Name = arg.ambiguousIdentifier().GetText(),
                    Type = argType
                });
            }
        }

        public override void EnterFunctionStmt(VisualBasic6Parser.FunctionStmtContext context) {
            AddFunctionScope(context);

            // Clear previous styling
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.GetText().Length, 0);

            if (context.visibility() != null) {
                _doc.StartStyling(context.visibility().start.StartIndex);
                _doc.SetStyling(context.visibility().GetText().Length, 1);
            }

            _doc.StartStyling(context.FUNCTION().Symbol.StartIndex);
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

        public override void ExitFunctionStmt(VisualBasic6Parser.FunctionStmtContext context) {
            _scope.ReverseCheckpoint();
        }

        public override void EnterSubStmt(VisualBasic6Parser.SubStmtContext context) {
            AddSubScope(context);

            // Clear previous styling
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.GetText().Length, 0);

            if (context.visibility() != null) {
                _doc.StartStyling(context.visibility().start.StartIndex);
                _doc.SetStyling(context.visibility().GetText().Length, 1);
            }

            _doc.StartStyling(context.SUB().Symbol.StartIndex);
            _doc.SetStyling(context.SUB().GetText().Length, 1);

            _doc.StartStyling(context.ambiguousIdentifier().start.StartIndex);
            _doc.SetStyling(context.ambiguousIdentifier().GetText().Length, 3);

            _doc.StartStyling(context.END_SUB().Symbol.StartIndex);
            _doc.SetStyling(context.END_SUB().GetText().Length, 1);
        }

        public override void ExitSubStmt(VisualBasic6Parser.SubStmtContext context) {
            _scope.ReverseCheckpoint();
        }

        public override void EnterArgList(VisualBasic6Parser.ArgListContext context) {
            if(context.parent is VisualBasic6Parser.DeclareStmtContext) {
                return;
            }

            foreach (var arg in context.arg()) {
                var variableName = arg.ambiguousIdentifier().GetText();
                var variableType = arg.asTypeClause()?.type_()?.GetText() ?? "Variant";

                _scope.Add(new VariableData() { Name = variableName, Type = variableType });

                if (arg.BYVAL() != null) {
                    _doc.StartStyling(arg.BYVAL().Symbol.StartIndex);
                    _doc.SetStyling(arg.BYVAL().GetText().Length, 1);
                }

                if (arg.BYREF() != null) {
                    _doc.StartStyling(arg.BYREF().Symbol.StartIndex);
                    _doc.SetStyling(arg.BYREF().GetText().Length, 1);
                }

                _doc.StartStyling(arg.ambiguousIdentifier().start.StartIndex);
                _doc.SetStyling(arg.ambiguousIdentifier().GetText().Length, 2);
            }
        }



        public override void EnterBlock(VisualBasic6Parser.BlockContext context) {
            _scope.AddCheckpoint();
        }

        public override void ExitBlock(VisualBasic6Parser.BlockContext context) {
            _scope.ReverseCheckpoint();
        }

        // Color for syntax
        public override void EnterForEachStmt(VisualBasic6Parser.ForEachStmtContext context) {
            _doc.StartStyling(context.FOR().Symbol.StartIndex);
            _doc.SetStyling(context.FOR().GetText().Length, 1);

            _doc.StartStyling(context.EACH().Symbol.StartIndex);
            _doc.SetStyling(context.EACH().GetText().Length, 1);

            _doc.StartStyling(context.IN().Symbol.StartIndex);
            _doc.SetStyling(context.IN().GetText().Length, 1);

            _doc.StartStyling(context.NEXT().Symbol.StartIndex);
            _doc.SetStyling(context.NEXT().GetText().Length, 1);
        }

        public override void EnterForNextStmt(VisualBasic6Parser.ForNextStmtContext context) {
            _doc.StartStyling(context.FOR().Symbol.StartIndex);
            _doc.SetStyling(context.FOR().GetText().Length, 1);

            _doc.StartStyling(context.NEXT().Symbol.StartIndex);
            _doc.SetStyling(context.NEXT().GetText().Length, 1);
        }

        // Color while syntax
        public override void EnterWhileWendStmt(VisualBasic6Parser.WhileWendStmtContext context) {
            _doc.StartStyling(context.WHILE().Symbol.StartIndex);
            _doc.SetStyling(context.WHILE().GetText().Length, 1);

            _doc.StartStyling(context.WEND().Symbol.StartIndex);
            _doc.SetStyling(context.WEND().GetText().Length, 1);
        }

        public override void EnterInlineIfThenElse(VisualBasic6Parser.InlineIfThenElseContext context) {
            _doc.StartStyling(context.IF().Symbol.StartIndex);
            _doc.SetStyling(context.IF().GetText().Length, 1);

            _doc.StartStyling(context.THEN().Symbol.StartIndex);
            _doc.SetStyling(context.THEN().GetText().Length, 1);
        }


        // Color if statements
        public override void EnterIfBlockStmt(VisualBasic6Parser.IfBlockStmtContext context) {
            _doc.StartStyling(context.IF().Symbol.StartIndex);
            _doc.SetStyling(context.IF().GetText().Length, 1);

            _doc.StartStyling(context.THEN().Symbol.StartIndex);
            _doc.SetStyling(context.THEN().GetText().Length, 1);
        }
        public override void EnterIfElseIfBlockStmt(VisualBasic6Parser.IfElseIfBlockStmtContext context) {
            _doc.StartStyling(context.ELSEIF().Symbol.StartIndex);
            _doc.SetStyling(context.ELSEIF().GetText().Length, 1);
        }
        public override void EnterIfElseBlockStmt(VisualBasic6Parser.IfElseBlockStmtContext context) {
            _doc.StartStyling(context.ELSE().Symbol.StartIndex);
            _doc.SetStyling(context.ELSE().GetText().Length, 1);
        }
        public override void EnterBlockIfThenElse(VisualBasic6Parser.BlockIfThenElseContext context) {
            _doc.StartStyling(context.END_IF().Symbol.StartIndex);
            _doc.SetStyling(context.END_IF().GetText().Length, 1);
        }


        // Color the 'dim' keyword from 'dim a as type'
        public override void EnterVariableStmt(VisualBasic6Parser.VariableStmtContext context) {
            if (context.DIM() != null) {
                _doc.StartStyling(context.DIM().Symbol.StartIndex);
                _doc.SetStyling(context.DIM().GetText().Length, 1);
            }
            if (context.STATIC() != null) {
                _doc.StartStyling(context.STATIC().Symbol.StartIndex);
                _doc.SetStyling(context.STATIC().GetText().Length, 1);
            }
            if (context.visibility() != null) {
                _doc.StartStyling(context.visibility().start.StartIndex);
                _doc.SetStyling(context.visibility().GetText().Length, 1);
            }
            if (context.WITHEVENTS() != null) {
                _doc.StartStyling(context.WITHEVENTS().Symbol.StartIndex);
                _doc.SetStyling(context.WITHEVENTS().GetText().Length, 1);
            }
        }

        public override void EnterVariableSubStmt(VisualBasic6Parser.VariableSubStmtContext context) {
            var variableName = context.ambiguousIdentifier().GetText();
            var variableType = context.asTypeClause()?.type_()?.GetText() ?? "Variant";

            _scope.Add(new VariableData() { Name = variableName, Type = variableType });

            _doc.StartStyling(context.ambiguousIdentifier().start.StartIndex);
            _doc.SetStyling(context.ambiguousIdentifier().GetText().Length, 2);
        }

        // Color the variable type in 'dim a as type'
        public override void EnterType_(VisualBasic6Parser.Type_Context context) {
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.GetText().Length, 1);
        }

        // Color set in 'set a=b'
        public override void EnterSetStmt(VisualBasic6Parser.SetStmtContext context) {
            _doc.StartStyling(context.SET().Symbol.StartIndex);
            _doc.SetStyling(context.SET().GetText().Length, 1);
        }

        public override void EnterICS_S_VariableOrProcedureCall(VisualBasic6Parser.ICS_S_VariableOrProcedureCallContext context) {
            var itemName = context.ambiguousIdentifier().GetText();

            if (_scope.Contains(el => el.Name.ToLower() == itemName.ToLower())) {
                _doc.StartStyling(context.ambiguousIdentifier().start.StartIndex);
                _doc.SetStyling(context.ambiguousIdentifier().GetText().Length, 2);
            }
        }

        public override void EnterICS_S_ProcedureOrArrayCall(VisualBasic6Parser.ICS_S_ProcedureOrArrayCallContext context) {
            _doc.StartStyling(context.ambiguousIdentifier().start.StartIndex);
            _doc.SetStyling(context.ambiguousIdentifier().GetText().Length, 3);
        }

        public override void EnterGoToStmt(VisualBasic6Parser.GoToStmtContext context) {
            _doc.StartStyling(context.GOTO().Symbol.StartIndex);
            _doc.SetStyling(context.GOTO().GetText().Length, 1);
        }

        public override void EnterVsLiteral(VisualBasic6Parser.VsLiteralContext context) {
            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.GetText().Length, 1);
        }
    }
}
