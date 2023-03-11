using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Utils.ConsolePrint {
    public class ConsoleBlock {
        private readonly List<string> _lines = new List<string>();

        public int Length {
            get {
                return _lines.Select(el => el.Length).Max();
            }
        }

        public ConsoleBlock(List<string> lines) {
            _lines = lines;
        }


        public static ConsoleBlock Empty(int spacesCount, int rows) {
            List<string> data = new List<string>();
            string line = new string(' ', spacesCount);

            for (int i = 0; i < rows; i++) data.Add(line);
            return new ConsoleBlock(data);
        }

        public static ConsoleBlock Concat(ConsoleBlock left, ConsoleBlock middle, ConsoleBlock right) {
            List<string> data = new List<string>();
            int i;

            for (i = 0; i < left._lines.Count; i++) {
                var left = left._lines[i];
                var middle=
                if (i >= right._lines.Count) break;

                data.Add()
            }

        }
    }
}
