using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Grammars.Generated;
using VisualBasicDebugger.Utils;

namespace VisualBasicDebugger.Parser.Tracer {
    public class TracerVisitor : VisualBasic6ParserBaseVisitor<object> {
        private List<FunctionTrace> _result = new List<FunctionTrace>();
        private FunctionTrace _currentTrace;

        public List<FunctionTrace> Result { get => _result; }

        public override object VisitFunctionStmt(VisualBasic6Parser.FunctionStmtContext context) {
            FunctionData currentFunction = new FunctionData() {
                Line = context.start.Line,
                Name = context.ambiguousIdentifier().GetText(),
                ScopedVariables = new CheckpointStack<VariableData>()
            };

            _currentTrace = new FunctionTrace() {
                ParentFunction = currentFunction,
                Traces = new List<TraceData>()
            };

            // Add arguments to scoped variables
            currentFunction.ScopedVariables.AddCheckpoint();
            foreach (var arg in context.argList().arg()) {
                var argType = arg.asTypeClause().type_().GetText();

                currentFunction.ScopedVariables.Add(new VariableData() {
                    Name = arg.ambiguousIdentifier().GetText(),
                    Type = argType
                });
            }

            // Add function name itself to variable list
            currentFunction.ScopedVariables.Add(new VariableData() {
                Name = currentFunction.Name
            });

            base.VisitFunctionStmt(context);

            _result.Add(_currentTrace);
            _currentTrace = null;

            return null;
        }

        public override object VisitBlock(VisualBasic6Parser.BlockContext context) {
            List<TraceData> result;

            _currentTrace.ParentFunction.ScopedVariables.AddCheckpoint();
            result = (List<TraceData>)base.VisitBlock(context);
            _currentTrace.ParentFunction.ScopedVariables.ReverseCheckpoint();

            return result;
        }

        public override object VisitForEachStmt(VisualBasic6Parser.ForEachStmtContext context) {
            var traceData = new TraceData() { Line = context.start.Line };
            var traceForEach = new TraceForEach(_currentTrace.ParentFunction);

            traceForEach.Visit(context.valueStmt());
            traceData.VariableTraces = traceForEach.Result;

            if (traceData.VariableTraces != null) _currentTrace.Traces.Add(traceData);

            base.VisitForEachStmt(context);

            return null;
        }

        public override object VisitLetStmt(VisualBasic6Parser.LetStmtContext context) {
            var traceData = new TraceData() { Line = context.start.Line };
            var traceLet = new TracerLetStmt(_currentTrace.ParentFunction);

            traceLet.Visit(context);
            traceData.VariableTraces = traceLet.Result;

            if (traceData.VariableTraces != null) _currentTrace.Traces.Add(traceData);

            return null;
        }

        public override object VisitVariableSubStmt(VisualBasic6Parser.VariableSubStmtContext context) {
            var variableName = context.ambiguousIdentifier().GetText();
            var variableType = (context.asTypeClause()?.type_().GetText()) ?? "Variant";

            _currentTrace.ParentFunction.ScopedVariables.Add(new VariableData() {
                Name = variableName,
                Type = variableType
            });

            return null;
        }
    }
}
