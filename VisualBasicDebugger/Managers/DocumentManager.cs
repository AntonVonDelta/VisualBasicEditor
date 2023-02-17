using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Managers {
    public class DocumentManager {
        private string _filePath;
        private FileSystemWatcher _fileWatcher = new FileSystemWatcher();
        private string _originalData;
        private string _currentData;

        public string OriginalData { get => _originalData; }
        public string Data { get => _currentData; set => _currentData = value; }
        public bool PendingChanges { get => _currentData != _originalData; }

        public event Action<DocumentManager> Changed;

        public DocumentManager(string filePath) {
            _filePath = filePath;
            _fileWatcher.Path = _filePath;
            _fileWatcher.Changed += FileWatcher_Changed;

            using (var stream = new StreamReader(_filePath)) {
                _originalData = stream.ReadToEnd();
                _currentData = _originalData;
            }
        }

        public void Save() {
            if (PendingChanges) return;

            using (var stream = new StreamWriter(_filePath)) {
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
