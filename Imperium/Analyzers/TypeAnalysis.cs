using Imperium.Compilers.Module.SymbolTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imperium.Analyzers {
    public class TypeAnalysis : ICompiledTable {
        private readonly SymbolsTable _symbolsTable = new SymbolsTable();
        private readonly string _name;

        public TypeAnalysis(string name) {
            _name = name;
        }

        public void AddMember(string name, string type) {

        }

        public SymbolsTable GetTable() {
            return _symbolsTable;
        }
    }
}
