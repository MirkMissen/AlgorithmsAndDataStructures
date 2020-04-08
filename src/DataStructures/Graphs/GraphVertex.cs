using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.Graphs.Interfaces;
using Native.Enums;

namespace DataStructures.Graphs {
    public class GraphVertex<T> : IGraphVertex<T> {

        /// <summary>
        /// Defines the connector, i.e. point of reference in relation to <see cref="IoDirection"/>.
        /// </summary>
        public IGraphNode<T> Connector { get; }

        /// <summary>
        /// Defines the serving part.
        /// </summary>
        public IGraphNode<T> Serving { get; }

        /// <summary>
        /// Defines the connection direction in relation to the <see cref="Connector"/> to the <see cref="Serving"/>.
        /// </summary>
        public IoDirection IoDirection { get; }

        /// <summary>
        /// Defines if this vertex contains a relation between x and y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool HasRelation(IGraphNode<T> x, IGraphNode<T> y) {
            return (this.Connector.Equals(x) && this.Serving.Equals(y)) || 
                   (this.Connector.Equals(y) && this.Serving.Equals(x));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="connector">Defines the point of reference in relation to the <see cref="direction"/></param>
        /// <param name="serving">Defines the pointed instance.</param>
        /// <param name="direction">Defines the connection direction in relation to the <see cref="Connector"/> to the <see cref="Serving"/>.</param>
        public GraphVertex(IGraphNode<T> connector, IGraphNode<T> serving, IoDirection direction) {
            this.Connector = connector;
            this.Serving = serving;
            this.IoDirection = direction;
        }
        
        
        /// <summary>
        /// Defines if the given node (<see cref="Connector"/> or <see cref="Serving"/>) can access the other.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool CanAccessCounterPart(IGraphNode<T> node) {
            if (node.Equals(this.Connector)) {
                return this.IoDirection.HasFlag(IoDirection.Out);
            } else if (node.Equals(this.Serving)) {
                return this.IoDirection.HasFlag(IoDirection.In);
            }
            else {
                throw new ArgumentException($"The given node cannot be matched with either {nameof(this.Connector)} or {this.Serving}");
            }
        }
        
        /// <summary>
        /// Retrieves the counter part to the given node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IGraphNode<T> GetCounterPart(IGraphNode<T> node) {
            if (node.Equals(this.Connector)) {
                return this.Serving;
            } else if (node.Equals(this.Serving)) {
                return this.Connector;
            }
            else {
                throw new ArgumentException($"The given node cannot be matched with either {nameof(this.Connector)} or {this.Serving}");
            }
        }
    }
}
