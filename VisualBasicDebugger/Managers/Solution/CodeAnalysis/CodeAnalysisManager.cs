using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Managers.Solution.Documents;

namespace VisualBasicDebugger.Managers.Solution.CodeAnalysis {
    public class CodeAnalysisManager {
        private List<VBDocument> _documents = new List<VBDocument>();

        public void AddDocument(VBDocument document) {
            _documents.Add(document);
        }


        public void Analyze(string input) {

        }

        public void GetScopedVariables(int position) {

        }
    }
}
