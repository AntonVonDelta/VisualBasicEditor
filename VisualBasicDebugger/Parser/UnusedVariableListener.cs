﻿using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Grammars.Generated;

namespace VisualBasicDebugger.Parser {
    public class UnusedVariableListener : VisualBasic6ParserBaseListener {
        public class VariableInfo {
            public string Name { get; set; }
            public string Type { get; set; }

            public string ParentFunction { get; set; }
            public int StartPosition { get; set; }
            public int EndPosition { get; set; }

            public override string ToString() {
                return $"{Name} as {Type}, {StartPosition}-{EndPosition}";
            }
        }

        public List<VariableInfo> Result { get => _result; }

        private string currentFunctionName;
        private List<VariableInfo> _result = new List<VariableInfo>();

        public override void EnterFunctionStmt(VisualBasic6Parser.FunctionStmtContext context) {
            currentFunctionName = context.ambiguousIdentifier().GetText();
        }

        public override void EnterVariableSubStmt([NotNull] VisualBasic6Parser.VariableSubStmtContext context) {
            _result.Add(new VariableInfo() {
                Name = context.ambiguousIdentifier().GetText(),
                Type = (context.asTypeClause()?.type_().GetText()) ?? "Variant",
                ParentFunction = currentFunctionName,
                StartPosition = context.start.StartIndex,
                EndPosition = context.start.StopIndex
            });
        }

        public override void EnterICS_S_VariableOrProcedureCall([NotNull] VisualBasic6Parser.ICS_S_VariableOrProcedureCallContext context) {
            var variableName = context.ambiguousIdentifier().GetText();

            _result.RemoveAll(el => el.Name.ToLower() == variableName.ToLower());
        }

        public override void EnterForEachStmt([NotNull] VisualBasic6Parser.ForEachStmtContext context) {
            var variableName = context.ambiguousIdentifier()[0].GetText();

            _result.RemoveAll(el => el.Name.ToLower() == variableName.ToLower());
        }
    }
}
