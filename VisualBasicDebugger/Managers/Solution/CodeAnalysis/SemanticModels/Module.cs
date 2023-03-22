using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Managers.Solution.CodeAnalysis.SemanticModels {
    public class Module {
        public string ModuleName { get => Path.GetDirectoryName(ModulePath); }
        public string ModulePath { get; private set; }

        public List<Variable> Variables { get; private set; }
        public List<Function> Functions { get; private set; }

        public Module() {

        }

        public void AddVariable(string name, string type) {

        }

    }
}
