using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs.Interfaces {

    /// <summary>
    /// Defines the base of a graph.
    /// </summary>
    /// <typeparam name="T">Defines the data type contained by each node.</typeparam>
    public interface IGraph<T> {

        /// <summary>
        /// Defines the nodes available in the graph.
        /// </summary>
        IEnumerable<IGraphNode<T>> Nodes { get; }

        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="node"></param>
        void AddNode(IGraphNode<T> node);

        /// <summary>
        /// Removes a single node from the graph.
        /// </summary>
        /// <param name="node"></param>
        void RemoveNode(IGraphNode<T> node);

    }
}
