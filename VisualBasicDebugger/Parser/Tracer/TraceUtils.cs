using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Utils;

namespace VisualBasicDebugger.Parser.Tracer {
    public enum VariableType {
        String = 1,
        Integer = 2,
        Long = 4,
        Boolean = 8,
        Variant = 16,
        Array = 32
    }

    public class FunctionData {
        public int Line { get; set; }
        public string Name { get; set; }
        public CheckpointStack<VariableData> ScopedVariables { get; set; }
    }

    public class VariableData {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class TraceVariableData {
        public string Name { get; set; }
        public VariableType Type { get; set; }
    }

    public class TraceData {
        public int Line { get; set; }
        public List<TraceVariableData> VariableTraces { get; set; }
    }

    public class FunctionTrace {
        public FunctionData ParentFunction { get; set; }
        public List<TraceData> Traces { get; set; }
    }
}
