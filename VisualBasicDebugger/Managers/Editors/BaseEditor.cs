using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Forms.Editor;

namespace VisualBasicDebugger.Managers.Editors {
    public class BaseEditor {
        private IMainView _view;

        public BaseEditor(IMainView view) {
            _view = view;
        }
    }
}
