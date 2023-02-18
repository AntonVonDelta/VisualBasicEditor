using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VisualBasicDebugger.SolutionStructure;

namespace VisualBasicDebugger.Managers.SolutionStructure {
    public class ProjectFile {
        ProjectFolder _parent;
        string _filePath;
        VisualBasicFileTypes _fileType;

        public ProjectFolder Parent { get => _parent; }
        public string FilePath { get => _filePath; }
        public VisualBasicFileTypes FileType { get => _fileType; }

        public string FileNameExtension { get => Path.GetFileName(FilePath); }
        public string FileName { get => Path.GetFileNameWithoutExtension(FilePath); }
        public string Extension { get => Path.GetExtension(FilePath); }

        public ProjectFile(ProjectFolder parent, string filePath) {
            _parent = parent;
            _filePath = filePath;
            _fileType = VisualBasicFiles.FileTypesExtensions.Where(el => el.Value == FileNameExtension).Select(el => el.Key).First();
        }
    }
}
