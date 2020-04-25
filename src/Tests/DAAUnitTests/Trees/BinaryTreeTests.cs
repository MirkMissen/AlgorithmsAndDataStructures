using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Trees;
using NuGet.Frameworks;
using NUnit.Framework;

namespace DataStructuresUnitTests.Trees {

    [TestFixture, Category("ShouldAddElementsToTree_1Indexed")]
    class BinaryTreeTests {

        [Test]
        public void ShouldAddElementsToTree_1Indexed() {
            BinaryTree<string> tree = new BinaryTree<string>();
            tree.Append("a");
            tree.Append("b");
            Assert.IsTrue(tree.GetIndex(1).Equals("a"));
            Assert.IsTrue(tree.GetIndex(2).Equals("b"));
        }

        [Test]
        public void ShouldClearTree() { 
            
            BinaryTree<string> tree = new BinaryTree<string>();
            tree.Append("Hello");

            var count1 = tree.Count();
            tree.Clear();
            var count2 = tree.Count();

            Assert.IsTrue(count1 == 1);
            Assert.IsTrue(count2 == 0);
        }

        [Test]
        public void SettingMustHaveChildrenAndParents() {
            
            var tree = new BinaryTree<string>();

            // root
            tree.Append("root");

            // children of root
                tree.Append("root_left_child");
                tree.Append("root_right_child");

            // children of root_left_child
                    tree.Append("root_left_left_child");
                    tree.Append("root_left_right_child");

                    // child of root_right_child
                    tree.Append("root_right_left_child");

            // Root is index 1 and has no parent and two children.
            Assert.IsTrue(tree.Root.Equals("root"));
            Assert.IsTrue(tree.Root.Equals(tree.GetIndex(1)));
            Assert.IsTrue(tree.HasParent(1) == false);

            var leftChildIndex = tree.GetLeftNodeIndex(1);
            var rightChildIndex = tree.GetRightNodeIndex(1);
            Assert.IsTrue(tree.GetIndex(leftChildIndex).Equals("root_left_child"));
            Assert.IsTrue(tree.GetIndex(rightChildIndex).Equals("root_right_child"));

            Assert.IsTrue(tree.HasParent(leftChildIndex));
            Assert.IsTrue(tree.GetParent(leftChildIndex).Equals(1));
            Assert.IsTrue(tree.HasParent(rightChildIndex));
            Assert.IsTrue(tree.GetParent(rightChildIndex).Equals(1));

            Assert.IsTrue(tree.HasLeftNode(leftChildIndex));
            Assert.IsTrue(tree.HasRightNode(leftChildIndex));
            
            Assert.IsTrue(tree.GetIndex(tree.GetLeftNodeIndex(leftChildIndex)).Equals("root_left_left_child"));
            Assert.IsTrue(tree.GetIndex(tree.GetRightNodeIndex(leftChildIndex)).Equals("root_left_right_child"));
            
            Assert.IsTrue(tree.HasLeftNode(rightChildIndex));
            Assert.IsFalse(tree.HasRightNode(rightChildIndex));

            Assert.IsTrue(tree.GetIndex(tree.GetLeftNodeIndex(rightChildIndex)).Equals("root_right_left_child"));
            Assert.Throws<ArgumentOutOfRangeException>(() => tree.GetIndex(tree.GetRightNodeIndex(rightChildIndex)));
        }

        [Test]
        public void EnumerableAccess() {

            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Append(1);
            tree.Append(2);
            tree.Append(3);

            var list = (IEnumerable) tree;
            var iterated = new List<int>();

            foreach (var o in list) {
                iterated.Add((int)o);
            }
            
            Assert.IsTrue(iterated[0] == 1);
            Assert.IsTrue(iterated[1] == 2);
            Assert.IsTrue(iterated[2] == 3);
            Assert.IsTrue(iterated.Count == 3);
        }

        [Test]
        public void EnumerableAccess_generic() {

            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Append(1);
            tree.Append(2);
            tree.Append(3);
            var list = tree.ToList();

            Assert.IsTrue(list[0] == 1);
            Assert.IsTrue(list[1] == 2);
            Assert.IsTrue(list[2] == 3);
            Assert.IsTrue(list.Count == 3);
        }

        [Test]
        public void AlterIndex() {
            
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Append(1);
            tree.Append(500);
            tree.Append(3);

            var pre_index2 = tree.GetIndex(2);
            tree.SetIndexValue(2, 2);
            var post_index2 = tree.GetIndex(2);

            Assert.IsTrue(pre_index2 == 500);
            Assert.IsTrue(post_index2 == 2);
        }

        [Test]
        public void RemoveLastEntry() {
            
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Append(1);
            tree.Append(500);
            tree.Append(3);

            Assert.IsTrue(tree.Last() == 3);
            Assert.IsTrue(tree.Size == 3);

            tree.RemoveLastEntry();

            Assert.IsTrue(tree.Last() == 500);
            Assert.IsTrue(tree.Size == 2);
        }

    }
}
