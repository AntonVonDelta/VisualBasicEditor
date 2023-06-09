﻿using Imperium.Compilers.Module.SymbolTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imperium.Compilers.Module.BasicElements {
    public class VariableElement {
        private readonly Modifier _modifier;
        private readonly string _name;
        private readonly SymbolReference _typeReference;

        public Modifier Modifer => _modifier;
        public string Name => _name;
        public SymbolReference Type => _typeReference;

        public VariableElement(Modifier modifier, string name, SymbolReference typeReference) {
            _modifier = modifier;
            _name = name;
            _typeReference = typeReference;
        }
    }
}
