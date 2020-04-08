//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DataStructuresAndAlgorithms.Datastructures.Trees
//{
//    class Tree
//    {
//    }
//}

using System;
using System.Collections;
using System.Collections.Generic;
using DataStructuresAndAlgorithms.Datastructures.Trees;

namespace DataStructures.Trees {

    public class BinaryTree<T> : Abstractions.AbstractDisposable, ITree<T> {

        private List<T> _collection;

        /// <summary>
        /// Defines the current size of the tree.
        /// </summary>
        /// <returns></returns>
        public int Size => this._collection.Count - 1;

        /// <summary>
        /// Defines the root of the tree.
        /// </summary>
        /// <returns></returns>
        public T Root => this._collection[0];

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
            this._collection = new List<T>()
            {
                default
            };
        }

        /// <summary>
        /// Initializes the array to a 1-indexed array with the given list.
        /// </summary>
        /// <param name="Collection">The collection to be placed in the tree.</param>
        public void InitializeTree(IEnumerable<T> Collection) {
            this.InitializeTree();
            this._collection.AddRange(Collection);
        }



        /// <summary>
        /// Retrieves the parent to the current index: CurrentIndex / 2
        /// </summary>
        /// <param name="Index">The index which parent to retrieve.</param>
        /// <returns></returns>
        public int GetParent(int Index) => System.Convert.ToInt32(Math.Floor(Index / (double)2));

        /// <summary>
        /// Retrieves the left child node index
        /// </summary>
        /// <param name="Index">Defines the index of the current node.</param>
        /// <returns></returns>
        public int GetLeftNode(int index) => index * 2;

        /// <summary>
        /// Retrieves the right child node index.
        /// </summary>
        /// <param name="Index">Defines the index of the current node.</param>
        /// <returns></returns>
        public int GetRightNode(int index) => (2 * index) + 1;

        /// <summary>
        /// Defines if a given index as a parent.
        /// </summary>
        /// <param name="index">The current index</param>
        /// <returns></returns>
        public bool HasParent(int index) {
            var output = this.GetParent(index);
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
            return output < this._collection.Count & output > 0;
        }

        /// <summary>
        /// Retrieves the value of the index.
        /// </summary>
        /// <param name="Index">Defines the current index.</param>
        /// <returns></returns>
        public T GetIndexValue(int Index) => this._collection[Index];

        /// <summary>
        /// Sets the value of the index.
        /// </summary>
        /// <param name="Index">The index to place the new value.</param>
        /// <param name="Value">The Value to be placed on the given index.</param>
        public void SetIndexValue(int Index, T Value) => this._collection[Index] = Value;
        
        /// <summary>
        /// Retrieves the specific index.
        /// </summary>
        /// <param name="Index">The index to look up.</param>
        /// <returns></returns>
        public T GetIndex(int Index) => this._collection[Index];

        /// <summary>
        /// Adds an element to the tree.
        /// </summary>
        /// <param name="Element">The element to be added</param>
        public void Add(T Element) => this._collection.Add(Element);

        /// <summary>
        /// Removes an element from the tree.
        /// </summary>
        /// <param name="Element">The element to be removed.</param>
        public void Remove(T Element) => this._collection.Remove(Element);

        /// <summary>
        /// Removes the value of the given index.
        /// </summary>
        /// <param name="Index">The index to be removed.</param>
        public void Remove(int Index) =>  this._collection.RemoveAt(Index);

        /// <summary>
        /// Clears all elements from the tree.
        /// </summary>
        public void Clear() {
            this._collection.Clear();
            this.InitializeTree();
        }

        public IEnumerator<T> GetEnumerator() => this._collection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this._collection.GetEnumerator();

    }
}
