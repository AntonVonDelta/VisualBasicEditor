using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Managers {
    public class SolutionManager {
        public SolutionManager(string projectPath) {
            List<string> extensionsWhiteList = new List<string>() { ".vbp", ".frm", ".vbg", ".bas" };

            //foreach (var file in Directory.GetFiles(_projectPath)) {
            //    TabPage documentTitleTab;

            //    if (!extensionsWhiteList.Contains(Path.GetExtension(file))) continue;

            //    documentTitleTab = new TabPage(Path.GetFileName(file));
            //    documentTitleTab.Tag = file;
            //    tabDocuments.TabPages.Add(documentTitleTab);
            //}
        }
    }
}
