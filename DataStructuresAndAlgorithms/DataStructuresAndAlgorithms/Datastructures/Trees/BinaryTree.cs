//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DataStructuresAndAlgorithms.Datastructures.Trees
//{
//    class Tree
//    {
//    }
//}

using DataStructuresAndAlgorithms.Datastructures.Trees;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.Datastructures.Trees {

    public class BinaryTree<T> : Abstractions.AbstractDisposable, ITree<T> {

        private List<T> Collection;

        /// <summary>
        /// Defines the current size of the tree.
        /// </summary>
        /// <returns></returns>
        public int Size {
            get {
                return this.Collection.Count - 1;
            }
        }

        /// <summary>
        /// Defines the root of the tree.
        /// </summary>
        /// <returns></returns>
        public T Root {
            get {
                return this.Collection[0];
            }
        }



        /// <summary>
        /// Initializes a new Binary Tree.
        /// </summary>
        public BinaryTree() {
            this.InitializeTree();
        }

        /// <summary>
        /// Initializes the array to a 1-indexed 
        /// </summary>
        public void InitializeTree() {
            this.Collection = new List<T>()
            {
                default
            };
        }

        /// <summary>
        /// Initializes the array to a 1-indexed array with the given list.
        /// </summary>
        /// <param name="Collection">The collection to be placed in the tree.</param>
        public void InitializeTree(IEnumerable<T> Collection) {
            InitializeTree();
            this.Collection.AddRange(Collection);
        }



        /// <summary>
        /// Retrieves the parent to the current index: CurrentIndex / 2
        /// </summary>
        /// <param name="Index">The index which parent to retrieve.</param>
        /// <returns></returns>
        public int GetParent(int Index) {
            return System.Convert.ToInt32(Math.Floor(Index / (double)2));
        }

        /// <summary>
        /// Retrieves the left child node index
        /// </summary>
        /// <param name="Index">Defines the index of the current node.</param>
        /// <returns></returns>
        public int GetLeftNode(int Index) => Index * 2;

        /// <summary>
        /// Retrieves the right child node index.
        /// </summary>
        /// <param name="Index">Defines the index of the current node.</param>
        /// <returns></returns>
        public int GetRightNode(int Index) => Index * 2 + 1;

        /// <summary>
        /// Defines if a given index as a parent.
        /// </summary>
        /// <param name="Index">The current index</param>
        /// <returns></returns>
        public bool HasParent(int Index) {
            var output = GetParent(Index);
            return output < this.Size & output > 0;
        }

        /// <summary>
        /// Defines if a given index as a left child node.
        /// </summary>
        /// <param name="Index">The current index</param>
        /// <returns></returns>
        public bool HasLeftNode(int Index) {
            var output = this.GetLeftNode(Index);
            return output < this.Size & output > 0;
        }

        /// <summary>
        /// Defines if a given index as a right child node.
        /// </summary>
        /// <param name="Index">The current index</param>
        /// <returns></returns>
        public bool HasRightNode(int Index) {
            var output = this.GetRightNode(Index);
            return output < this.Collection.Count & output > 0;
        }

        /// <summary>
        /// Retrieves the value of the index.
        /// </summary>
        /// <param name="Index">Defines the current index.</param>
        /// <returns></returns>
        public T GetIndexValue(int Index) {
            return this.Collection[Index];
        }

        /// <summary>
        /// Sets the value of the index.
        /// </summary>
        /// <param name="Index">The index to place the new value.</param>
        /// <param name="Value">The Value to be placed on the given index.</param>
        public void SetIndexValue(int Index, T Value) {
            this.Collection[Index] = Value;
        }


        /// <summary>
        /// Retrieves the specific index.
        /// </summary>
        /// <param name="Index">The index to look up.</param>
        /// <returns></returns>
        public T GetIndex(int Index) => this.Collection[Index];

        /// <summary>
        /// Adds an element to the tree.
        /// </summary>
        /// <param name="Element">The element to be added</param>
        public void Add(T Element) => this.Collection.Add(Element);

        /// <summary>
        /// Removes an element from the tree.
        /// </summary>
        /// <param name="Element">The element to be removed.</param>
        public void Remove(T Element) => this.Collection.Remove(Element);

        /// <summary>
        /// Removes the value of the given index.
        /// </summary>
        /// <param name="Index">The index to be removed.</param>
        public void Remove(int Index) {
            this.Collection.RemoveAt(Index);
        }

        /// <summary>
        /// Clears all elements from the tree.
        /// </summary>
        public void Clear() {
            this.Collection.Clear();
            InitializeTree();
        }

        public IEnumerator<T> GetEnumerator() => this.Collection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.Collection.GetEnumerator();

    }
}
