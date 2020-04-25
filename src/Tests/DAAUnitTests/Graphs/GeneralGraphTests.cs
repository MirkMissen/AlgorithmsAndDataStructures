using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Graphs;
using Native.Enums;
using NuGet.Frameworks;
using NUnit.Framework;

namespace DataStructuresUnitTests.Graphs {

    [TestFixture]
    class GeneralGraphTests {

        [Test]
        public void HasValues() {
            var graph = new Graph<int>();

            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);

            graph.AddNode(node1);
            graph.AddNode(node2);

            node1.ConnectNode(node2, IoDirection.Both);

            Assert.IsTrue(node1.Value == 1);
            Assert.IsTrue(node2.Value == 2);
        }

        [Test]
        public void CannotAddTheSameNode() {
            var graph = new Graph<int>();

            var node1 = new GraphNode<int>(1);

            graph.AddNode(node1);
            Assert.Throws<ArgumentException>(() => graph.AddNode(node1));
        }

        [Test]
        public void ConnectNodesByVertex() {

            var graph = new Graph<int>();

            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);

            graph.AddNode(node1);
            graph.AddNode(node2);

            var vertex = node1.ConnectNode(node2, IoDirection.Both);

            Assert.IsTrue(vertex.Connector.Equals(node1));
            Assert.IsTrue(vertex.Serving.Equals(node2));
            Assert.IsTrue(vertex.IoDirection.Equals(IoDirection.Both));

            Assert.IsTrue(node1.Vertices.Count() == 1);
            Assert.IsTrue(node2.Vertices.Count() == 1);
        }

        [Test]
        public void RemoveNode() {
            var graph = new Graph<int>();

            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);

            graph.AddNode(node1);
            graph.AddNode(node2);

            node1.ConnectNode(node2, IoDirection.Both);

            graph.RemoveNode(node1);
            Assert.IsFalse(node2.Vertices.Any());
        }

        [Test]
        public void DoubleRegister() {
            var graph = new Graph<int>();

            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);

            graph.AddNode(node1);
            graph.AddNode(node2);

            var vertex1 = node1.ConnectNode(node2, IoDirection.Both);
            var vertex2 = node1.ConnectNode(node2, IoDirection.Both);

            Assert.IsTrue(vertex1.Equals(vertex2));
        }

        [Test]
        public void Direction_In() {
            var graph = new Graph<int>();

            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);

            graph.AddNode(node1);
            graph.AddNode(node2);

            var vertex = node1.ConnectNode(node2, IoDirection.Out);
            
            Assert.IsTrue(vertex.Connector.Equals(node1));
        }

        [Test]
        public void Vertex_GetCounterPart() {
            var graph = new Graph<int>();

            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);

            graph.AddNode(node1);
            graph.AddNode(node2);

            var vertex = node1.ConnectNode(node2, IoDirection.Out);

            Assert.IsTrue(vertex.GetCounterPart(node1).Equals(node2));
            Assert.IsTrue(vertex.GetCounterPart(node2).Equals(node1));
            Assert.Throws<ArgumentException>(() => vertex.GetCounterPart(node3));
        }

        [Test]
        public void Vertex_CanAccess_out() {
            var graph = new Graph<int>();

            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);

            graph.AddNode(node1);
            graph.AddNode(node2);

            var vertex = node1.ConnectNode(node2, IoDirection.Out);

            Assert.IsTrue(vertex.CanAccessCounterPart(node1));
            Assert.IsFalse(vertex.CanAccessCounterPart(node2));
            Assert.Throws<ArgumentException>(() => vertex.CanAccessCounterPart(node3));
        }

        [Test]
        public void Vertex_CanAccess_in() {
            var graph = new Graph<int>();

            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);

            graph.AddNode(node1);
            graph.AddNode(node2);

            var vertex = node1.ConnectNode(node2, IoDirection.In);

            Assert.IsTrue(vertex.CanAccessCounterPart(node2));
            Assert.IsFalse(vertex.CanAccessCounterPart(node1));
            Assert.Throws<ArgumentException>(() => vertex.CanAccessCounterPart(node3));
        }

    }
}
