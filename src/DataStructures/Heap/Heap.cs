using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using DataStructures.Heap.Interfaces;
using DataStructures.Trees;
using Native.Enums;
using Native.GenericImplementations;

namespace DataStructures.Heap {
    public class Heap<T> : IHeap<T> {

        /// <summary>
        /// Defines the method to compare instances of T.
        /// </summary>
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// Defines the tree-structure which the heap is based upon.
        /// </summary>
        private readonly BinaryTree<T> _internBinaryTree;

        /// <summary>
        /// Defines the order of the heap (min or max)
        /// </summary>
        public SortOrder Order { get; }

        /// <summary>
        /// Defines the current root of the heap.
        /// </summary>
        public T Root => this._internBinaryTree.Root;

        /// <summary>
        /// Creates a new instance of the heap.
        /// </summary>
        /// <param name="order">Defines the order of data.</param>
        /// <param name="comparer">Defines the method to compare the data.</param>
        public Heap(SortOrder order, IComparer<T> comparer) {
            this.Order = order;
            this._comparer = new CompositeComparer<T>(comparer, (i) => i * (int) order);;

            this._internBinaryTree = new BinaryTree<T>();
        }

        public void Insert(T element) {
            var index = this._internBinaryTree.Append(element);
            InterpolateUp(index);
        }


        public void DeleteRoot() {

            var rootIndex = this._internBinaryTree.RootIndex;
            var lastIndex = this._internBinaryTree.Size;

            Swap(rootIndex, lastIndex);
            this._internBinaryTree.RemoveLastEntry();

            if (this._internBinaryTree.Any()) {
                this.InterpolateDown(rootIndex);
            }
        }

        /// <summary>
        /// Moves the given index up the tree such that potential parent and/or children satisfies the order.
        /// </summary>
        /// <param name="index">Defines the index to Interpolate up from.</param>
        private void InterpolateUp(int index) {

            var currentValue = this._internBinaryTree.GetValue(index);

            if (this._internBinaryTree.HasParent(index)) {
                var parentIndex = this._internBinaryTree.GetParent(index);
                var parentValue = this._internBinaryTree.GetValue(parentIndex);

                // TODO: MKR refactor this, such that a compare result does not match on == 1.
                if (this._comparer.Compare(currentValue, parentValue) == 1) {
                    Swap(index, parentIndex);
                    this.InterpolateUp(parentIndex);
                } 
            }
        }

        /// <summary>
        /// Moves the given index down the tree such that potential parent and/or children satisfies the order.
        /// </summary>
        /// <param name="index">Defines the index to Interpolate down from</param>
        private void InterpolateDown(int index) {

            var currentValue = this._internBinaryTree.GetValue(index);
            
            var leftIndex = this._internBinaryTree.GetLeftNodeIndex(index);
            var rightIndex = this._internBinaryTree.GetRightNodeIndex(index);

            if (this._internBinaryTree.HasLeftNode(index)) {
                
                var leftValue = this._internBinaryTree.GetValue(leftIndex);
                var swappingIndex = leftIndex;
                var swappingValue = leftValue;
                
                if (this._internBinaryTree.HasRightNode(index)) {
                    var rightValue = this._internBinaryTree.GetValue(rightIndex);

                    if (this._comparer.Compare(rightValue, leftValue) == 1) {
                        swappingIndex = rightIndex;
                        swappingValue = rightValue;
                    } 
                }

                if (this._comparer.Compare(swappingValue, currentValue) == 1) {
                    Swap(index, swappingIndex);
                    InterpolateDown(swappingIndex);
                }
            }
        }
        
        /// <summary>
        /// Swaps two indecencies of the internal tree.
        /// </summary>
        private void Swap(int indexX, int indexY) {
            var x = this._internBinaryTree.GetValue(indexX);
            var y = this._internBinaryTree.GetValue(indexY);

            this._internBinaryTree.SetIndexValue(indexX, y);
            this._internBinaryTree.SetIndexValue(indexY, x);
        }

        /// <summary>
        /// Retrieves the enumerator of the internal tree structure.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => this._internBinaryTree.GetEnumerator();
        
        /// <summary>
        /// Retrieves the enumerator of the internal tree structure.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => this._internBinaryTree.GetEnumerator();
    }
}
