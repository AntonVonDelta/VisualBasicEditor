using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Grammars.Generated;
using VisualBasicDebugger.Utils;

namespace VisualBasicDebugger.Parser.Scope {
    public class VariablesListener : VisualBasic6ParserBaseListener {
        class VariableData {
            public string Name { get; set; }
            public string Type { get; set; }
        }

        private List<CheckpointStack<VariableData>> _scopes = new List<CheckpointStack<VariableData>>();
        private CheckpointStack<VariableData> _scope = new CheckpointStack<VariableData>();

        public List<string> Result {
            get {
                return Flatten().Select(el => el.Name).ToList();
            }
        }

        public VariablesListener() {
        }

        private List<VariableData> Flatten() {
            var result = new List<VariableData>();

            foreach (var el in _scopes) {
                result.AddRange(el.Flatten());
            }

            return result;
        }

        private void AddFunctionScope(VisualBasic6Parser.FunctionStmtContext context) {
            var functionName = context.ambiguousIdentifier().GetText();
            var functionType = context.asTypeClause()?.type_()?.GetText() ?? "Variant";

            _scope = new CheckpointStack<VariableData>();
            _scope.AddCheckpoint();

            _scopes.Add(_scope);

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
        }

        public override void ExitFunctionStmt(VisualBasic6Parser.FunctionStmtContext context) {
            _scope.ReverseCheckpoint();
        }

        public override void EnterSubStmt(VisualBasic6Parser.SubStmtContext context) {
            AddSubScope(context);
        }

        public override void ExitSubStmt(VisualBasic6Parser.SubStmtContext context) {
            _scope.ReverseCheckpoint();
        }

        public override void EnterArgList(VisualBasic6Parser.ArgListContext context) {
            foreach (var arg in context.arg()) {
                var variableName = arg.ambiguousIdentifier().GetText();
                var variableType = arg.asTypeClause()?.type_()?.GetText() ?? "Variant";

                _scope.Add(new VariableData() { Name = variableName, Type = variableType });
            }
        }



        public override void EnterBlock(VisualBasic6Parser.BlockContext context) {
            _scope.AddCheckpoint();
        }

        public override void ExitBlock(VisualBasic6Parser.BlockContext context) {
            _scope.ReverseCheckpoint();
        }

        public override void EnterVariableSubStmt(VisualBasic6Parser.VariableSubStmtContext context) {
            var variableName = context.ambiguousIdentifier().GetText();
            var variableType = context.asTypeClause()?.type_()?.GetText() ?? "Variant";

            _scope.Add(new VariableData() { Name = variableName, Type = variableType });
        }
    }
}
