using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Managers.Solution.CodeAnalysis.SemanticModels;

namespace VisualBasicDebugger.Managers.Solution.CodeAnalysis.SemanticModels {
    public class SolutionAnalysis {
        public List<Module> Modules { get; set; }

        public List<Function> Functions { get; set; }
        public List<Variable> Variables { get; set; }
    }
}
