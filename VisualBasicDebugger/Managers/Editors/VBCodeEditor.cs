using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Forms.Editor;
using VisualBasicDebugger.Managers.Solution.Documents;

namespace VisualBasicDebugger.Managers.Editors {
    public class VBCodeEditor : BaseEditor {
        private readonly ICodeView _view;
        private readonly VBDocument _document;

        public VBCodeEditor(ICodeView view, VBDocument document) {
            _view = view;

        }
    }
}
