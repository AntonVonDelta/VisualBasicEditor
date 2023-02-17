using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Managers;

namespace VisualBasicDebugger.Parser.Scopes {
    public class SolutionScope : Scope {
        private SolutionManager _source;

        public SolutionScope(SolutionManager solutionManager) {
            _source = solutionManager;
        }
    }
}
