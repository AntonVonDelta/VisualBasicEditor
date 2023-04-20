using Imperium.Analyzers.Module.SymbolTable;
using Imperium.Compilers.Module.SymbolTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imperium.Compilers.Module.BasicElements {
    public class TypeElement {
        struct ReferenceBinding {
            public string name;
            public SymbolReference reference;
        }

        private readonly Modifier _modifier;
        private readonly string _name;
        private readonly List<ReferenceBinding> _members = new List<ReferenceBinding>();

        public Modifier Modifer => _modifier;
        public string Name => _name;

        public TypeElement(Modifier modifier, string name) {
            _name = name;
            _modifier = modifier;
        }

        public void AddMember(string memberName, SymbolReference reference) {
            _members.Add(new ReferenceBinding() { name = memberName, reference = reference });
        }
    }
}
