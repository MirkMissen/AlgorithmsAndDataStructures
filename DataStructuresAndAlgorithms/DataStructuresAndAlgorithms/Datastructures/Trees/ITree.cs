using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Datastructures.Trees
{
    /// <summary>
    /// Defines the contract defining a tree.
    /// </summary>
    public interface ITree<T> : IEnumerable<T>
    {

        /// <summary>
        /// Defines the root element.
        /// </summary>
        /// <returns></returns>
        T Root { get; }

        /// <summary>
        /// Retrieves the element at the given index.
        /// </summary>
        /// <param name="Index">The index to look up</param>
        /// <returns></returns>
        T GetIndex(int Index);

        /// <summary>
        /// Adds an element to the tree.
        /// </summary>
        /// <param name="Element">The element to be added</param>
        void Add(T Element);

        /// <summary>
        /// Removes an element from the tree.
        /// </summary>
        /// <param name="Element">The element to be removed.</param>
        void Remove(T Element);

        /// <summary>
        /// Removes the value of the given index.
        /// </summary>
        /// <param name="Index">The index to be removed.</param>
        void Remove(int Index);

        /// <summary>
        /// Clears all elements from the tree.
        /// </summary>
        void Clear();
    }
}
