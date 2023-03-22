using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Managers.Solution.Documents;

namespace VisualBasicDebugger.Managers.Solution.CodeAnalysis.SemanticModels {
    public class VBDocumentAnalysis {
        public List<Function> Functions { get; set; }
        public List<Variable> Variables { get; set; }
    }
}
