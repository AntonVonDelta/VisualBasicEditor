using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Utils.ConsolePrint {
    public class ConsoleBlock {
        private readonly List<string> _lines;

        public int Length {
            get {
                return _lines.Select(el => el.Length).Max();
            }
        }

        public ConsoleBlock(string line) {
            _lines = new List<string>() { line };
        }
        public ConsoleBlock(List<string> lines) {
            _lines = lines;
        }

        public string Get(int i) {
            if (i < _lines.Count) return _lines[i];
            return null;
        }

        public void AddTitle(string title) {
            string padding = new string(' ', Length / 2 - title.Length / 2);
            _lines.Insert(0, padding + title + padding);
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
                var leftData = left.Get(i);
                var middleData = middle.Get(i) ?? "";
                var rightData = right.Get(i) ?? "";

                data.Add(leftData + middleData + rightData);
            }

            for (; i < right._lines.Count; i++) {
                var leftData = left.Get(i) ?? "";
                var middleData = middle.Get(i) ?? "";
                var rightData = right.Get(i);

                data.Add(leftData + middleData + rightData);
            }

            return new ConsoleBlock(data);
        }

        public override string ToString() {
            return string.Join("\r\n", _lines);
        }
    }
}
