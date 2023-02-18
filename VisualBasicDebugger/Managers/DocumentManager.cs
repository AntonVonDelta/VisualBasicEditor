using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Managers.SolutionStructure;

namespace VisualBasicDebugger.Managers {
    public class DocumentManager {
        ProjectFile _file;
        private FileSystemWatcher _fileWatcher = new FileSystemWatcher();
        private string _originalData;
        private string _currentData;

        public string FilePath { get => _file.FilePath; }
        public string OriginalData { get => _originalData; }
        public string Data { get => _currentData; set => _currentData = value; }
        public bool PendingChanges { get => _currentData != _originalData; }

        public event Action<DocumentManager> Changed;

        public DocumentManager(ProjectFile file) {
            _file = file;
            _fileWatcher.Path = FilePath;
            _fileWatcher.Changed += FileWatcher_Changed;

            using (var stream = new StreamReader(FilePath)) {
                _originalData = stream.ReadToEnd();
                _currentData = _originalData;
            }
        }

        public void Save() {
            if (PendingChanges) return;

            using (var stream = new StreamWriter(FilePath)) {
                stream.Write(_currentData);
            }
            _originalData = _currentData;
        }


        private void FileWatcher_Changed(object sender, FileSystemEventArgs e) {
            if (PendingChanges) OnChanged();
        }

        private void OnChanged() {
            if (Changed != null) Changed(this);
        }
    }
}
