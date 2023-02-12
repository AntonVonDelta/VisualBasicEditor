using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Parser {
    public class SyntaxParsingException : Exception {
        public int Line { get; private set; }
        public int StartPostion { get; private set; }
        public int StopPosition { get; private set; }
        public string Symbol { get; private set; }

        public SyntaxParsingException(int line, int startPosition, int stopPosition, string symbol, string message) : base(message) {
            Line = line;
            StartPostion = startPosition;
            StopPosition = stopPosition;
            Symbol = symbol;
        }
    }
}
