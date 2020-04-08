using System;
using System.Collections.Generic;
using System.Text;
using Native.Enums;

namespace DataStructures.Graphs.Interfaces {

    /// <summary>
    /// Defines a vertex within a graph.
    /// </summary>
    /// <typeparam name="T">Defines the data type contained by each node.</typeparam>
    public interface IGraphVertex<T> {

        /// <summary>
        /// Defines one of the connected nodes.
        /// (lack of better description, this is the "client" side of the IoDirection.)
        /// </summary>
        IGraphNode<T> Connector { get; }

        /// <summary>
        /// Defines one of the connected nodes.
        /// (lack of better description, this is the "server" side of the IoDirection.)
        /// </summary>
        IGraphNode<T> Serving { get; }

        /// <summary>
        /// Defines the <see cref="Connector"/> connection to the <see cref="Serving"/>.
        /// </summary>
        IoDirection IoDirection { get; }

        /// <summary>
        /// Defines if the vertex is of the two given nodes.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool HasRelation(IGraphNode<T> x, IGraphNode<T> y);

        /// <summary>
        /// Defines if the given node (<see cref="Connector"/> or <see cref="Serving"/>) can access the other.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        bool CanAccessCounterPart(IGraphNode<T> node);

        /// <summary>
        /// Retrieves the counter part to the given node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        IGraphNode<T> GetCounterPart(IGraphNode<T> node);
    }
}
