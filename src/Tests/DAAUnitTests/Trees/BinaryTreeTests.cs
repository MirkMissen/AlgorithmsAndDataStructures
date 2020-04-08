using DataStructures.Trees;
using DataStructuresAndAlgorithms.Datastructures.Trees;
using NUnit.Framework;

namespace DataStructuresUnitTests.Trees {

    [TestFixture, Category("Test")]
    class BinaryTreeTests {

        [Test]
        public void Test() {
            var tree = new BinaryTree<string>();
            tree.Add("a");
            tree.Add("b");
            tree.GetIndex(2).Equals("a");
            tree.GetIndex(1).Equals("b");
        }

    }
}
