using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBasicDebugger.Utils {
    public class CheckpointStack<T> where T : class {
        private Stack<List<T>> _store = new Stack<List<T>>();

        public CheckpointStack() {

        }

        public void Add(T data) {
            _store.Peek().Add(data);
        }

        public bool Contains(Predicate<T> predicate) {
            foreach (var scope in _store) {
                foreach (var data in scope) {
                    if (predicate(data)) return true;
                }
            }

            return false;
        }

        public T Get(Predicate<T> predicate) {
            foreach (var scope in _store) {
                foreach (var data in scope) {
                    if (predicate(data)) return data;
                }
            }

            return null;
        }

        public void AddCheckpoint() {
            _store.Push(new List<T>());
        }

        public void ReverseCheckpoint() {
            _store.Pop();
        }
    }
}
