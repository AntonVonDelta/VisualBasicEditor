using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Managers.Solution.Documents;

namespace VisualBasicDebugger.Managers.Solution.CodeAnalysis {
    public class VBDocumentAnalysis {
        private readonly VBDocument _document;

        public VBDocumentAnalysis(VBDocument document) {
            _document = document;
        }
    }
}
