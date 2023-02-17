using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Parser.Scopes;

namespace VisualBasicDebugger.Managers {
    public class SolutionManager {
        private readonly string[] _extensionsWhiteList = new string[] { ".vbp", ".frm", ".vbg", ".bas" };
        private string _projectPath;
        private List<DocumentManager> _documents = new List<DocumentManager>();
        private SolutionScope _scope;
        private List<ProcessingMessage> _messages = new List<ProcessingMessage>();

        public List<ProcessingMessage> Messages { get => _messages; }

        public event Action Changed;

        public SolutionManager(string projectPath) {
            _projectPath = projectPath;
            _scope = new SolutionScope(this);

            foreach (var filePath in Directory.GetFiles(projectPath)) {
                DocumentManager documentManager;
                if (!_extensionsWhiteList.Contains(Path.GetExtension(filePath))) continue;

                try {
                    documentManager = new DocumentManager(filePath);
                    documentManager.Changed += Document_Changed;

                    _documents.Add(documentManager);
                } catch (Exception ex) {
                    _messages.Add(new ProcessingMessage() {
                        MessageType = MessageType.Error,
                        Message = $"Could not load file \"{filePath}\""
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
