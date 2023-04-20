using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Managers.Solution.CodeAnalysis.SemanticModels {
    public class ObjectType : ICloneable {
        public AccessModifierType Access { get; protected set; }
        public string Name { get; protected set; }

        public object Clone() {
            return new UnknownObjectType(Name);
        }
    }
}
