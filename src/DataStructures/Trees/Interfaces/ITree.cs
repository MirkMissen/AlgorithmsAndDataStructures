using System.Collections.Generic;

namespace DataStructures.Trees.Interfaces {

    /// <summary>
    /// Defines basic instructions which all trees must be able to execute.
    /// </summary>
    public interface ITree<out T> : IEnumerable<T> {

        /// <summary>
        /// Defines the root element.
        /// </summary>
        /// <returns></returns>
        T Root { get; }

        /// <summary>
        /// Retrieves the element at the given index.
        /// </summary>
        /// <param name="index">The index to look up</param>
        /// <returns></returns>
        T GetValue(int index);

        /// <summary>
        /// Clears all elements from the tree.
        /// </summary>
        void Clear();
    }
}
