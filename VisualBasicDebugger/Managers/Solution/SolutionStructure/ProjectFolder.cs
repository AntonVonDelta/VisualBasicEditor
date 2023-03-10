using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VisualBasicDebugger.Managers.Solution.SolutionStructure {
    public class ProjectFolder {
        List<ProjectFolder> _childFolders = new List<ProjectFolder>();
        string _folderPath;
        List<ProjectFile> _files = new List<ProjectFile>();

        public List<ProjectFolder> ChildFolders { get => _childFolders; }
        public string FolderPath { get => _folderPath; }
        public List<ProjectFile> Files { get => _files; }
        public string FolderName { get => Path.GetDirectoryName(FolderPath); }

        public ProjectFolder(string folderPath) {
            _folderPath = folderPath;
        }
    }
}
