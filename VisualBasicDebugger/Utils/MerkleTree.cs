using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicDebugger.Utils.ConsolePrint;

namespace VisualBasicDebugger.Utils {
    public class MerkleTree<T, U> where U : class {
        class Entry {
            private readonly Entry _child1;
            private readonly Entry _child2;
            private readonly U _data;
            private readonly int _level;

            public Entry Child1 { get => _child1; }
            public Entry Child2 { get => _child2; }
            public U Data { get => _data; }
            public int Level { get => _level; }
            public bool IsLeaf { get => _child1 == null && _child2 == null; }

            public Entry(Entry child1, Entry child2, U data, int level) {
                _child1 = child1;
                _child2 = child2;
                _data = data;
                _level = level;
            }

            public new ConsoleBlock ToString() {
                int padding = 4;
                string title = _data.ToString();
                ConsoleBlock leftBranch;
                ConsoleBlock rightBranch;
                ConsoleBlock lowerLine;

                if (IsLeaf) return new ConsoleBlock(_data.ToString());

                leftBranch = _child1.ToString();
                rightBranch = _child2?.ToString() ?? new ConsoleBlock("<null>");

                // Total length should preferably be even
                if (title.Length % 2 != 0) padding += 1;

                lowerLine = ConsoleBlock.Concat(leftBranch, ConsoleBlock.Empty(padding, 1000), rightBranch);
                lowerLine.AddTitle(_data.ToString());

                return lowerLine;
            }
        }

        private readonly Func<T, U> _transformer;
        private readonly Func<U, U, U> _reducer;
        private readonly Dictionary<T, Entry> _mapKeyToFirstEntry = new Dictionary<T, Entry>();
        private readonly Dictionary<Entry, Entry> _mapChildToParent = new Dictionary<Entry, Entry>();
        private Entry _root;


        public U Result { get => _root.Data; }

        public MerkleTree(Func<T, U> transformer, Func<U, U, U> reducer) {
            _transformer = transformer;
            _reducer = reducer;
        }

        /// <summary>
        /// Adds an element to the merkle tree. The object itself is used as a key for
        /// future updates.
        /// </summary>
        public void Add(T element) {
            Entry newEntry;

            if (element == null)
                throw new Exception("Element cannot be null because the transformer cannot support it");

            newEntry = CreateLeaf(element);

            if (_root == null) {
                _root = CreateChainToLeaf(newEntry, 2);
                _mapChildToParent[_root] = null;
            } else {
                AddLeaf(newEntry);
            }
        }

        public void UpdateEntry(T oldElement, T newElement) {
            Entry oldEntry;
            Entry newEntry;
            U newElementValue = _transformer(newElement);

            if (newElementValue == null)
                throw new Exception("Value of transformed element cannot be null because the reducer cannot support it");

            oldEntry = _mapKeyToFirstEntry[oldElement];
            _mapKeyToFirstEntry.Remove(oldElement);

            newEntry = CreateLeaf(newElement);

            UpdateEntry(oldEntry, newEntry);
        }
        private void UpdateEntry(Entry oldEntry, Entry newEntry) {
            Entry parentEntry = _mapChildToParent[oldEntry];

            // Update map references
            _mapChildToParent.Remove(oldEntry);

            if (parentEntry != null) {
                Entry child1;
                Entry child2;
                Entry newParent;

                if (parentEntry.Child1 == oldEntry) {
                    child1 = newEntry;
                    child2 = parentEntry.Child2;
                } else {
                    child1 = parentEntry.Child1;
                    child2 = newEntry;
                }

                newParent = CreateReducedEntry(child1, child2);
                UpdateEntry(parentEntry, newParent);
            } else {
                // The current node being replaced is the root
                // Therefore it has no parent and no reduction is needed

                _root = newEntry;
                _mapChildToParent[_root] = null;
            }
        }


        private void AddLeaf(Entry leaf) {
            Entry freeParentNode = FindFreeEntry(_root);

            if (freeParentNode == null) {
                // Make room at the top
                var newChildNode = CreateChainToLeaf(leaf, _root.Level + 1);

                _root = CreateReducedEntry(_root, newChildNode);
                _mapChildToParent[_root] = null;
            } else {
                var newChildNode = CreateChainToLeaf(leaf, freeParentNode.Level);
                var newParentNode = CreateReducedEntry(freeParentNode.Child1, newChildNode);

                UpdateEntry(freeParentNode, newParentNode);
            }
        }
        private Entry FindFreeEntry(Entry startNode) {
            var currentNode = startNode;

            while (true) {
                Entry leftBranchFreeEntry;

                if (currentNode.IsLeaf) return null;
                if (currentNode.Child2 != null) {
                    currentNode = currentNode.Child2;
                    continue;
                }

                // At this point we don't know if we could find a free node 
                // on the left branch. Search for one then
                leftBranchFreeEntry = FindFreeEntry(currentNode.Child1);
                if (leftBranchFreeEntry == null) return currentNode;
                else return leftBranchFreeEntry;
            }
        }

        private Entry CreateLeaf(T element) {
            Entry result;
            var elementValue = _transformer(element);

            if (elementValue == null)
                throw new Exception("Value of transformed element cannot be null because the reducer cannot support it");

            result = new Entry(null, null, elementValue, 0);
            _mapKeyToFirstEntry[element] = result;

            return result;
        }
        /// <summary>
        /// Creates chain of entries up to the level counting up to parent level.
        /// Maps the newly created nodes to their newly created parent.
        /// </summary>
        private Entry CreateChainToLeaf(Entry leaf, int parentLevel) {
            Entry result = leaf;

            Debug.Assert(parentLevel > 0, "Incorrect level given");

            for (int i = 0; i < parentLevel - 1; i++) {
                var currentNode = result;

                result = new Entry(currentNode, null, currentNode.Data, i + 1);
                _mapChildToParent[currentNode] = result;
            }

            return result;
        }
        private Entry CreateReducedEntry(Entry child1, Entry child2) {
            U result;
            Entry newNode;
            int currentLevel;

            Debug.Assert(child2 == null || child1.Level == child2.Level, "Level mismatch in merkle tree reducer");

            currentLevel = child1.Level;

            if (child2 != null) {
                result = _reducer(child1.Data, child2.Data);

                newNode = new Entry(child1, child2, result, currentLevel + 1);
                _mapChildToParent[child1] = newNode;
                _mapChildToParent[child2] = newNode;
            } else {
                newNode = new Entry(child1, null, child1.Data, currentLevel + 1);
                _mapChildToParent[child1] = newNode;
            }

            return newNode;
        }

        public override string ToString() {
            return _root.ToString().ToString();
        }
    }
}
