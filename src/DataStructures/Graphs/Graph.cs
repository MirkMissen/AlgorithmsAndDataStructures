using DataStructures.Graphs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Graphs {

    /// <summary>
    /// Defines a simple implementation for a graph.
    /// </summary>
    public class Graph<T> : IGraph<T> {

        /// <summary>
        /// Defines the private instance of nodes.
        /// </summary>
        private readonly List<IGraphNode<T>> _nodes = new List<IGraphNode<T>>();

        /// <summary>
        /// Defines the nodes of the graph.
        /// </summary>
        public IEnumerable<IGraphNode<T>> Nodes => this._nodes.ToArray();

        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(IGraphNode<T> node) {
            if (this.Nodes.Contains(node)) {
                throw new ArgumentException($"The graph already contains the node: {node.ToString()}");
            }
            this._nodes.Add(node);
        }

        /// <summary>
        /// Removes a node from the graph.
        /// </summary>
        /// <param name="node"></param>
        public void RemoveNode(IGraphNode<T> node) {
            this._nodes.Remove(node);
            foreach (var element in this.Nodes) {
                element.DetachNode(node);
            }
        }
    }
}
