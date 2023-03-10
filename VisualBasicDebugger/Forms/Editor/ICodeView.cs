using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Forms.Editor {
    public interface ICodeView {
        void SetEditor(Scintilla editor);
    }
}
