using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Forms.Editor;
using VisualBasicDebugger.Managers.Solution.SolutionStructure;
using VisualBasicDebugger.Managers.Solution.Documents;

namespace VisualBasicDebugger.Managers.Solution {
    public class SolutionManager {
        private enum SolutionState {
            Closed,
            Opened,
            Busy
        }

        private string _projectPath;
        private SolutionState _state;
        private Hierarchy _hierarchy;
        private List<ProcessingMessage> _messages = new List<ProcessingMessage>();
        private List<Document> _documents = new List<Document>();
        private CodeAnalysisManager _codeAnalysisManager = new CodeAnalysisManager();

        public List<ProcessingMessage> Messages { get => _messages; }

        public event Action Closed;
        public event Action Changed;

        public SolutionManager() {
        }

        public void OpenSolution(string projectPath) {
            if (_state != SolutionState.Closed) return;

            _projectPath = projectPath;
            _hierarchy = new Hierarchy(_projectPath);

            LoadDocumentsInHierarchy();
        }

        private void LoadDocumentsInHierarchy() {
            foreach (var file in _hierarchy.GetProjectFiles()) {
                Document documentManager;

                try {
                    documentManager = new Document(file);
                    documentManager.Changed += Document_Changed;

                    _documents.Add(documentManager);
                } catch (Exception ex) {
                    _messages.Add(new ProcessingMessage() {
                        MessageType = MessageType.Error,
                        Message = $"Could not load file \"{file.FilePath}\" because '{ex.Message}'"
                    });
                }
            }
        }

        private void Document_Changed(Document documentManager) {
            OnChanged();
        }

        private void OnChanged() {
            if (Changed != null) Changed();
        }
    }
}
