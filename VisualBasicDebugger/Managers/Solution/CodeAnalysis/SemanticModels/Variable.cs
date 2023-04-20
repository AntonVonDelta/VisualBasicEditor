using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Managers.Solution.CodeAnalysis.SemanticModels {
    public class Variable : ICloneable {
        public string Name { get; private set; }
        public ObjectType Type { get; private set; }

        public Variable(string name, ObjectType type) {
            Name = name;
            Type = type;
        }

        public object Clone() {
            return new Variable(Name, (ObjectType)
                Type.Clone());
        }
    }
}
