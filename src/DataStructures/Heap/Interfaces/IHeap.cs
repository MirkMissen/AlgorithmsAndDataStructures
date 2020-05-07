using System;
using System.Collections.Generic;
using System.Text;
using Native.Enums;

namespace DataStructures.Heap.Interfaces {

    /// <summary>
    /// Defines the basic contract for a Heap.
    /// </summary>
    /// <typeparam name="T">Defines the data-type contained within the heap.</typeparam>
    public interface IHeap<T> : IEnumerable<T> {
        
        /// <summary>
        /// Defines the order of which the heap is sorted. (minimum- or max heap)
        /// </summary>
        SortOrder Order { get; }

        /// <summary>
        /// Defines the root of the heap.
        /// </summary>
        T Root { get; }

        /// <summary>
        /// Inserts an element into the heap.
        /// </summary>
        /// <param name="element">The element to be inserted into the heap.</param>
        void Insert(T element);

        /// <summary>
        /// Deletes the root node.
        /// </summary>
        void DeleteRoot();

    }
}
