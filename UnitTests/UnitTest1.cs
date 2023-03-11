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
            var e = new Element() { Name = "Test1" };

            tree.Add(new Element() { Name = "Test" });

            //Console.WriteLine(tree.ToString());

            tree.Add(new Element() { Name = "Test1" });
            tree.Add(new Element() { Name = "Test2" });
            tree.Add(new Element() { Name = "Test3" });
            tree.Add(e);
            tree.Add(new Element() { Name = "Test5555" });
            Console.WriteLine(tree.ToString()+"\r\n");
            Assert.AreEqual(32, tree.Result.Count);

            tree.UpdateEntry(e, new Element() { Name = "b" });
            tree.Add(new Element() { Name = "Test678" });
            Console.WriteLine(tree.ToString());
            Assert.AreEqual(35, tree.Result.Count);
        }
    }
}
