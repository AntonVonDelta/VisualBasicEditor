using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Managers.Solution.CodeAnalysis.SemanticModels {
    public class Function : ICloneable {
        private string _name;
        private List<Variable> _parameters = new List<Variable>();

        public string Name => _name;

        public Function(string name) {
            _name = name;
        }

        public void AddParameter(Variable variable) {
            //List<Variable> clonedParameters=_parameters.Select()
            throw new NotImplementedException();
        }

        public object Clone() {
            throw new NotImplementedException();
        }
    }
}
