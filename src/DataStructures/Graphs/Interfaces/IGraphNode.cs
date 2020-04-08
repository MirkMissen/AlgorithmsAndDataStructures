using System;
using System.Collections.Generic;
using System.Text;
using Native.Enums;

namespace DataStructures.Graphs.Interfaces {

    /// <summary>
    /// Defines a node within a graph.
    /// </summary>
    /// <typeparam name="T">Defines the data type contained by each node.</typeparam>
    public interface IGraphNode<T> {

        /// <summary>
        /// Defines the value of the node.
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Retrieves the vertices connected to this node.
        /// </summary>
        IEnumerable<IGraphVertex<T>> Vertices { get; }

        /// <summary>
        /// Connects the node to this.
        /// </summary>
        /// <param name="node">The node to be connected.</param>
        /// <param name="direction">Defines which way the graph can navigate between the nodes.</param>
        IGraphVertex<T> ConnectNode(IGraphNode<T> node, IoDirection direction);

        /// <summary>
        /// Registers a vertex in this node.
        /// </summary>
        /// <param name="vertex"></param>
        void RegisterVertex(IGraphVertex<T> vertex);

        /// <summary>
        /// Detaches the node from this.
        /// </summary>
        /// <param name="node">The node to be detached.</param>
        void DetachNode(IGraphNode<T> node);

    }
}
