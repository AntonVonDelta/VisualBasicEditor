using Antlr4.Runtime.Misc;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Grammars.Generated;
using VisualBasicDebugger.Utils;

namespace VisualBasicDebugger.Parser.Coloring {
    public class ColoringVisitor : VisualBasic6ParserBaseVisitor<object> {
        public class VariableData {
            public string Name { get; set; }
            public string Type { get; set; }
        }

        private Scintilla _doc;
        private CheckpointStack<VariableData> _scope = new CheckpointStack<VariableData>();
        private int _startLine;
        private int _stopLine;

        public ColoringVisitor(Scintilla doc, int startLine, int stopLine) {
            _doc = doc;
            _startLine = startLine;
            _stopLine = stopLine;
        }

        private bool ShouldStyle(int line) {
            return _startLine <= line && line <= _stopLine;
        }

        private void AddFunctionScope(VisualBasic6Parser.FunctionStmtContext context) {
            var functionName = context.ambiguousIdentifier().GetText();
            var functionType = context.asTypeClause()?.type_()?.GetText() ?? "Variant";

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

        public override object VisitModuleBody(VisualBasic6Parser.ModuleBodyContext context) {
            foreach (var el in context.moduleBodyElement()) {
                if (ShouldStyle(el.start.Line) || ShouldStyle(el.stop.Line)) {
                    base.VisitModuleBodyElement(el);
                }
            }

            return null;
        }


        public override object VisitFunctionStmt(VisualBasic6Parser.FunctionStmtContext context) {
            _scope = new CheckpointStack<VariableData>();
            _scope.AddCheckpoint();

            AddFunctionScope(context);

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

            base.VisitFunctionStmt(context);

            _scope.ReverseCheckpoint();

            return null;
        }

        public override object VisitBlock(VisualBasic6Parser.BlockContext context) {
            _scope.AddCheckpoint();
            base.VisitBlock(context);
            _scope.ReverseCheckpoint();

            return null;
        }

        // Color for syntax
        public override object VisitForEachStmt(VisualBasic6Parser.ForEachStmtContext context) {
            if (!ShouldStyle(context.start.Line)) return null;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.FOR().GetText().Length, 1);

            if (context.EACH() != null) {
                _doc.StartStyling(context.EACH().Symbol.StartIndex);
                _doc.SetStyling(context.EACH().GetText().Length, 1);
            }

            _doc.StartStyling(context.NEXT().Symbol.StartIndex);
            _doc.SetStyling(context.NEXT().GetText().Length, 1);

            return null;
        }

        // Color while syntax
        public override object VisitWhileWendStmt(VisualBasic6Parser.WhileWendStmtContext context) {
            if (!ShouldStyle(context.start.Line)) return null;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.WHILE().GetText().Length, 1);

            _doc.StartStyling(context.WEND().Symbol.StartIndex);
            _doc.SetStyling(context.WEND().GetText().Length, 1);

            return null;
        }

        // Color the 'dim' keyword from 'dim a as type'
        public override object VisitVariableStmt(VisualBasic6Parser.VariableStmtContext context) {
            if (!ShouldStyle(context.start.Line)) return null;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.DIM().GetText().Length, 1);

            return null;
        }

        public override object VisitVariableSubStmt(VisualBasic6Parser.VariableSubStmtContext context) {
            var variableName = context.ambiguousIdentifier().GetText();
            var variableType = context.asTypeClause()?.type_()?.GetText() ?? "Variant";

            _scope.Add(new VariableData() { Name = variableName, Type = variableType });

            return null;
        }

        // Color the variable type in 'dim a as type'
        public override object VisitType_(VisualBasic6Parser.Type_Context context) {
            if (!ShouldStyle(context.start.Line)) return null;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.GetText().Length, 1);

            return null;
        }

        // Color set in 'set a=b'
        public override object VisitSetStmt(VisualBasic6Parser.SetStmtContext context) {
            if (!ShouldStyle(context.start.Line)) return null;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.SET().GetText().Length, 1);

            return null;
        }

        public override object VisitICS_S_VariableOrProcedureCall(VisualBasic6Parser.ICS_S_VariableOrProcedureCallContext context) {
            var itemName = context.ambiguousIdentifier().GetText();

            if (!ShouldStyle(context.start.Line)) return null;
            if (_scope.Contains(el => el.Name.ToLower() == itemName.ToLower())) {
                _doc.StartStyling(context.ambiguousIdentifier().start.StartIndex);
                _doc.SetStyling(context.ambiguousIdentifier().GetText().Length, 2);
            }

            return null;
        }

        public override object VisitICS_S_ProcedureOrArrayCall(VisualBasic6Parser.ICS_S_ProcedureOrArrayCallContext context) {
            if (!ShouldStyle(context.start.Line)) return null;

            _doc.StartStyling(context.start.StartIndex);
            _doc.SetStyling(context.ambiguousIdentifier().GetText().Length, 3);

            return null;
        }
    }
}
