using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Managers {
    public enum MessageType {
        Info,
        Warniing,
        Error
    }

    public class ProcessingMessage {
        public MessageType MessageType { get; set; }
        public string Message { get; set; }
        public SourceReference Reference { get; set; }
    }
}
