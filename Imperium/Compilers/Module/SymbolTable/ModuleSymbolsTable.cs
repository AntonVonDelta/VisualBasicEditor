using Imperium.Compilers.Module.BasicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imperium.Compilers.Module.SymbolTable {
    public class ModuleSymbolsTable {
        class Entry {
            public string Name { get; set; }
            public SymbolType SymbolType { get; set; }
            public Modifier Modifier { get; set; }
            public bool Defined { get; set; }
            public object Value { get; set; }
        }

        private readonly List<Entry> _symbols = new List<Entry>();

        public ModuleSymbolsTable() {

        }

        public object GetReference(int reference) {
            throw new NotImplementedException();
        }

        public SymbolReference AddType(string type) {
            throw new NotImplementedException();

        }

        public SymbolReference AddVariable(Modifier modifier, string name, string type) {
            var typeReference = AddType(type);
            var variable = new VariableElement(modifier, name, typeReference);
            var symbol = new Entry() { Name = name, SymbolType = SymbolType.Variable, Modifier = modifier, Defined = true, Value = variable };

            _symbols.Add(symbol);
            return new SymbolReference(this, _symbols.Count - 1);
        }
    }
}
