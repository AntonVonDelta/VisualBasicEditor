using Imperium.Compilers.Module.BasicElements;
using Imperium.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imperium.Compilers.Module.SymbolTable {
    public class SymbolsTable {
        class Entry {
            public string Name { get; set; }
            public SymbolType SymbolType { get; set; }
            public Modifier Modifier { get; set; }
            public bool Defined { get; set; }
            public object Value { get; set; }
        }

        private readonly List<Entry> _symbols = new List<Entry>();

        public SymbolsTable() {

        }

        public object GetReference(int reference) {
            throw new NotImplementedException();
        }

        public SymbolReference GetType(string typeName) {
            var symbol = _symbols.Where(el => el.Name == typeName).FirstOrDefault();

            if (symbol == null) return null;
            if (symbol.SymbolType != SymbolType.Type)
                throw new SymbolsSameNameDifferentTypes(typeName, symbol.SymbolType.ToString(), SymbolType.Type.ToString());
            
            return new SymbolReference(this, _symbols.IndexOf(symbol));
        }

        public SymbolReference AddType(TypeElement type) {
            var symbol = new Entry() {
                Name = type.Name,
                SymbolType = SymbolType.Type,
                Modifier = type.Modifer,
                Defined = type.Modifer == Modifier.Unknown ? false : true,
                Value = type
            };

            _symbols.Add(symbol);
            return new SymbolReference(this, _symbols.Count - 1);
        }

        public SymbolReference AddVariable(VariableElement variable) {
            var symbol = new Entry() {
                Name = variable.Name,
                SymbolType = SymbolType.Variable,
                Modifier = variable.Modifer,
                Defined = variable.Modifer == Modifier.Unknown ? false : true,
                Value = variable
            };

            _symbols.Add(symbol);
            return new SymbolReference(this, _symbols.Count - 1);
        }
    }
}
