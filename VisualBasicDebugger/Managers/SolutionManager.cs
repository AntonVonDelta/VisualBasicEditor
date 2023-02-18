using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Forms.Editor;
using VisualBasicDebugger.Managers.SolutionStructure;
using VisualBasicDebugger.Parser.Scopes;
using VisualBasicDebugger.SolutionStructure;

namespace VisualBasicDebugger.Managers {
    public class SolutionManager {
        private enum SolutionState {
            Closed,
            Opened,
            Busy
        }

        private IMainView _view;
        private string _projectPath;
        private SolutionState _state;
        private Hierarchy _hierarchy;
        private List<DocumentManager> _documents = new List<DocumentManager>();
        private SolutionScope _scope;
        private List<ProcessingMessage> _messages = new List<ProcessingMessage>();


        public List<ProcessingMessage> Messages { get => _messages; }

        public event Action Closed;
        public event Action Changed;

        public SolutionManager(IMainView view) {
            _view = view;
        }

        public void OpenSolution(string projectPath) {
            if (_state != SolutionState.Closed) return;

            _projectPath = projectPath;
            _hierarchy = new Hierarchy(_projectPath);
            _scope = new SolutionScope(this);

            LoadDocumentsInHierarchy();
        }

        private void LoadDocumentsInHierarchy() {
            foreach (var file in _hierarchy.GetProjectFiles()) {
                DocumentManager documentManager;

                try {
                    documentManager = new DocumentManager(file);
                    documentManager.Changed += Document_Changed;

                    _documents.Add(documentManager);
                } catch (Exception ex) {
                    _messages.Add(new ProcessingMessage() {
                        MessageType = MessageType.Error,
                        Message = $"Could not load file \"{file.FilePath}\""
                    });
                }
            }
        }

        private void Document_Changed(DocumentManager documentManager) {
            Changed();
        }

        private void OnChanged() {
            if (Changed != null) Changed();
        }
    }
}
