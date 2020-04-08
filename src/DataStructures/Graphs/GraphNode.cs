using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataStructures.Graphs.Interfaces;
using Native.Enums;

namespace DataStructures.Graphs {
    
    /// <summary>
    /// Defines a simple graph-node.
    /// </summary>
    public class GraphNode<T> : IGraphNode<T> {
        

        /// <summary>
        /// Defines the private collection of vertices.
        /// </summary>
        private readonly List<IGraphVertex<T>> _vertices = new List<IGraphVertex<T>>();
        
        /// <summary>
        /// Defines the value of this node.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Defines the vertices connected to this node.
        /// </summary>
        public IEnumerable<IGraphVertex<T>> Vertices => this._vertices.ToArray();

        /// <summary>
        /// Creates a new graph node.
        /// </summary>
        /// <param name="value"></param>
        public GraphNode(T value) {
            this.Value = value;
        }

        /// <summary>
        /// Connects 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public IGraphVertex<T> ConnectNode(IGraphNode<T> node, IoDirection direction) {
            var vertex = this.Vertices.FirstOrDefault((x) => x.HasRelation(this, node));

            if (vertex == null) {
                vertex = new GraphVertex<T>(this, node, direction);
                this.RegisterVertex(vertex);
                node.RegisterVertex(vertex);
            }

            return vertex;
        }

        /// <summary>
        /// Registers the vertex on this node.
        /// </summary>
        /// <param name="vertex">The vertex to be contained in this node.</param>
        public void RegisterVertex(IGraphVertex<T> vertex) {
            _vertices.Add(vertex);
        }

        /// <summary>
        /// Detaches the vertex which contains a relation between this and the given node.
        /// </summary>
        /// <param name="node"></param>
        public void DetachNode(IGraphNode<T> node) {
            _vertices.RemoveAll((x) => x.HasRelation(this, node));
        }
    }
}
