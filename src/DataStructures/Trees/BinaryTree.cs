using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Native.Abstractions;

namespace DataStructures.Trees {

    /// <summary>
    /// The Binary-Tree is created for appending new elements to the end.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : AbstractDisposable, ITree<T> {
        
        /// <summary>
        /// Internal 1-indexed collection.
        /// </summary>
        private List<T> _collection;
        
        /// <summary>
        /// Defines the index of the root element.
        /// </summary>
        public readonly int RootIndex = 1;
        
        /// <summary>
        /// Defines the current size of the tree.
        /// </summary>
        /// <returns></returns>
        public int Size => this._collection.Count - 1;
        
        /// <summary>
        /// Defines the root of the tree.
        /// </summary>
        /// <returns></returns>
        public T Root => this._collection[RootIndex];
        
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
        /// Retrieves the parent to the current index: CurrentIndex / 2
        /// </summary>
        /// <param name="index">The index which parent to retrieve.</param>
        /// <returns></returns>
        public int GetParent(int index) => Convert.ToInt32(Math.Floor(index / (double)2));

        /// <summary>
        /// Retrieves the left child node index
        /// </summary>
        /// <param name="index">Defines the index of the current node.</param>
        /// <returns></returns>
        public int GetLeftNodeIndex(int index) => index * 2;

        /// <summary>
        /// Retrieves the right child node index.
        /// </summary>
        /// <param name="index">Defines the index of the current node.</param>
        /// <returns></returns>
        public int GetRightNodeIndex(int index) => (2 * index) + 1;

        /// <summary>
        /// Defines if a given index as a parent.
        /// </summary>
        /// <param name="index">The current index</param>
        /// <returns></returns>
        public bool HasParent(int index) {
            var output = this.GetParent(index);
            return output < this.Size + 1 & output > 0;
        }

        /// <summary>
        /// Defines if a given index as a left child node.
        /// </summary>
        /// <param name="index">The current index</param>
        /// <returns></returns>
        public bool HasLeftNode(int index) {
            var output = this.GetLeftNodeIndex(index);
            return output < this._collection.Count & output > 0;
        }

        /// <summary>
        /// Defines if a given index as a right child node.
        /// </summary>
        /// <param name="index">The current index</param>
        /// <returns></returns>
        public bool HasRightNode(int index) {
            var output = this.GetRightNodeIndex(index);
            return output < this._collection.Count & output > 0;
        }
        
        /// <summary>
        /// Sets the value of the index.
        /// </summary>
        /// <param name="index">The index to place the new value.</param>
        /// <param name="value">The value to be placed on the given index.</param>
        public void SetIndexValue(int index, T value) => this._collection[index] = value;
        
        /// <summary>
        /// Retrieves the specific index.
        /// </summary>
        /// <param name="index">The index to look up.</param>
        /// <returns></returns>
        public T GetValue(int index) => this._collection[index];

        /// <summary>
        /// Adds the element to the end of the tree. Returns the index of which it was placed.
        /// </summary>
        /// <param name="element">The element to be added</param>
        public int Append(T element) {
            this._collection.Add(element);
            return this._collection.Count - 1;
        }

        /// <summary>
        /// Removes an element from the tree.
        /// </summary>
        public void RemoveLastEntry() => this._collection.RemoveAt(this._collection.Count - 1);

        /// <summary>
        /// Clears all elements from the tree.
        /// </summary>
        public void Clear() {
            this._collection.Clear();
            this.InitializeTree();
        }

        public IEnumerator<T> GetEnumerator() => this._collection.Skip(1).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this._collection.Skip(1).GetEnumerator();

    }
}
