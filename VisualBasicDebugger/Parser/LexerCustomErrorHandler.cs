using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Parser {
    public class LexerCustomErrorHandler : IAntlrErrorListener<int> {
        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e) {
            throw new SyntaxParsingException(
                    line,
                    0,
                    0,
                    "",
                    msg
                );
        }
    }
}
