using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.SolutionStructure {
    public enum VisualBasicFileTypes {
        Form,
        Module,
        Project
    }

    public class VisualBasicFiles {
        public static Dictionary<VisualBasicFileTypes, string> FileTypesExtensions = new Dictionary<VisualBasicFileTypes, string>() {
            {VisualBasicFileTypes.Form,"frm" },
            {VisualBasicFileTypes.Module,"bas" },
            {VisualBasicFileTypes.Project,"vbp" }
        };
    }
}
