using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VisualBasicDebugger.Managers.Solution.SolutionStructure {
    public class Hierarchy {
        public ProjectFolder Root { get; set; }

        public Hierarchy(string folderPath) {
            Queue<ProjectFolder> folders = new Queue<ProjectFolder>();

            Root = new ProjectFolder(folderPath);

            folders.Enqueue(Root);

            while (folders.Count != 0) {
                var currentFolder = folders.Dequeue();

                foreach (var filePath in Directory.GetFiles(currentFolder.FolderPath)) {
                    if (!VisualBasicFiles.FileTypesExtensions.ContainsValue(Path.GetExtension(filePath))) continue;

                    currentFolder.Files.Add(new ProjectFile(currentFolder, filePath));
                }

                foreach (var childFolderPath in Directory.GetDirectories(currentFolder.FolderPath)) {
                    var newFolder = new ProjectFolder(childFolderPath);

                    currentFolder.ChildFolders.Add(newFolder);

                    folders.Enqueue(newFolder);
                }
            }
        }

        public IEnumerable<ProjectFile> GetProjectFiles() {
            Queue<ProjectFolder> folders = new Queue<ProjectFolder>();

            folders.Enqueue(Root);

            while (folders.Count != 0) {
                var currentFolder = folders.Dequeue();

                foreach (var file in currentFolder.Files) {
                    yield return file;
                }

                foreach (var childFolder in currentFolder.ChildFolders) {
                    folders.Enqueue(childFolder);
                }
            }
        }
    }
}
