using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Grammars.Generated;

namespace VisualBasicDebugger.Parser.Tracer {
    public class TracerLetStmt : VisualBasic6ParserBaseVisitor<object> {
        private List<TraceVariableData> _result = new List<TraceVariableData>();
        private FunctionData _currentFunction;

        public List<TraceVariableData> Result { get => _result; }

        public TracerLetStmt(FunctionData currentFunction) {
            _currentFunction = currentFunction;
        }

        public override object VisitICS_S_VariableOrProcedureCall(VisualBasic6Parser.ICS_S_VariableOrProcedureCallContext context) {
            string variableName = context.ambiguousIdentifier().GetText();
            string variableType;
            var inScopeVariable = _currentFunction.ScopedVariables.Get(el => el.Name.ToLower() == variableName.ToLower());
            VariableType traceableType;

            // Differentiate between variable or procedure call by checking the current scope
            if (inScopeVariable == null) return null;

            variableType = inScopeVariable.Type;
            if (!Enum.TryParse<VariableType>(variableType, out traceableType)) return null;

            _result.Add(new TraceVariableData() {
                Name = context.ambiguousIdentifier().GetText(),
                Type = traceableType
            });

            return null;
        }
    }
}
