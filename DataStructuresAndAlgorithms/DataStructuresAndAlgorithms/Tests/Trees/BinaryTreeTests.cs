using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Datastructures.Trees.Tests {

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
