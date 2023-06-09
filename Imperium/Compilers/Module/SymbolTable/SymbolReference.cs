﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imperium.Compilers.Module.SymbolTable {
    public class SymbolReference {
        private readonly SymbolsTable _table;
        private readonly int _reference;

        public SymbolReference(SymbolsTable table, int reference) {
            _table = table;
            _reference = reference;
        }

        public object Get() {
            return _table.GetReference(_reference);
        }
    }
}
