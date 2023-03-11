using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Managers.Solution.Documents;
using VisualBasicDebugger.Utils;

namespace VisualBasicDebugger.Managers.Solution.CodeAnalysis {
    public class CodeAnalysisManager {
        private MerkleTree<VBDocument, SolutionAnalysis> _solutionMerkleTree;
        private List<VBDocument> _documents = new List<VBDocument>();

        public event Action<SolutionAnalysis> FinishedAnalysis;

        public CodeAnalysisManager() {
            _solutionMerkleTree = new MerkleTree<VBDocument, SolutionAnalysis>(MerkleTransformer, MerkleReducer);
        }

        public void AddDocument(VBDocument document) {
            _documents.Add(document);
            document.Changed += Document_Changed;

            _solutionMerkleTree.Add(document);
            OnFinishedAnalysis();
        }

        private void Document_Changed(Document document) {
            var vbdocument = (VBDocument)document;

            _solutionMerkleTree.UpdateEntry(vbdocument, vbdocument);
        }

        private SolutionAnalysis MerkleTransformer(VBDocument document) {
            return null;
        }

        private SolutionAnalysis MerkleReducer(SolutionAnalysis firstAnalysis, SolutionAnalysis secondAnalysis) {
            return null;
        }

        private void OnFinishedAnalysis() {
            if (FinishedAnalysis != null) FinishedAnalysis(_solutionMerkleTree.Result);
        }
    }
}
