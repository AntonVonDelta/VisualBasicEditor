using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Parser {
    public class ParserCustomErrorHandler : BaseErrorListener {
        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e) {
            throw new SyntaxParsingException(
                line,
                offendingSymbol.StartIndex,
                offendingSymbol.StopIndex,
                offendingSymbol.Text,
                msg
            );
        }
    }
}
