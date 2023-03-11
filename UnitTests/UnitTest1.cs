using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VisualBasicDebugger.Utils;

namespace UnitTests {
    [TestClass]
    public class UnitTestMerkle {
        class Element {
            public string Name { get; set; }

            public override string ToString() {
                return Name;
            }
        }

        class Transform {
            public int Count { get; set; }

            public override string ToString() {
                return Count.ToString();
            }
        }

        Transform transform(Element el) {
            return new Transform() { Count = el.Name.Length };
        }

        Transform reduce(Transform a, Transform b) {
            return new Transform() { Count = a.Count + b.Count };
        }


        [TestMethod]
        public void Test1() {
            MerkleTree<Element, Transform> tree = new MerkleTree<Element, Transform>(transform, reduce);

            tree.Add(new Element() { Name = "Test" });
            tree.Add(new Element() { Name = "Test1" });
            tree.Add(new Element() { Name = "Test2" });
            tree.Add(new Element() { Name = "Test3" });
            tree.Add(new Element() { Name = "Test4" });
            tree.Add(new Element() { Name = "Test5" });
            tree.Add(new Element() { Name = "Test6" });

            Console.WriteLine(tree.Result.Count);

        }
    }
}
