using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imperium.Compilers.Module.SymbolTable {
    internal interface ICompiledTable {
        SymbolsTable GetTable();
    }
}
