using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imperium.Exceptions {
    public class SymbolsSameNameDifferentTypes : Exception {
        public SymbolsSameNameDifferentTypes(string symbolName, string firstType, string secondType) :
            base($"Two symbols have the same name {symbolName}, types {firstType}/{secondType}") {
        }
    }
}
