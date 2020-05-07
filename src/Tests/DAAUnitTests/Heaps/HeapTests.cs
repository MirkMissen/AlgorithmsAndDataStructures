using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Heap;
using DataStructures.Heap.Interfaces;
using Native.Enums;
using Native.GenericImplementations;
using NUnit.Framework;

namespace DataStructuresUnitTests.Heaps {

    [TestFixture]
    class HeapTests {

        // TDD approach.
        private IHeap<int> GetHeap(SortOrder order) {
            var heap = new Heap<int>(order, new FunctionalComparator<int>((i) => i));
            Assert.IsTrue(heap.Order.Equals(order));
            return heap;
        }

        [Test]
        public void GetRoot_max() {
            var heap = GetHeap(SortOrder.Descending);
            heap.Insert(50);
            heap.Insert(100);
            heap.Insert(25);
            heap.Insert(33);
            Assert.IsTrue(heap.Root == 100);
        }
        
        [Test]
        public void GetRoot_min() {
            var heap = GetHeap(SortOrder.Ascending);
            heap.Insert(50);
            heap.Insert(100);
            heap.Insert(25);
            heap.Insert(33);
            Assert.IsTrue(heap.Root == 25);
        }
        
        [Test]
        public void IterateData_max() {
            var heap = GetHeap(SortOrder.Descending);
            heap.Insert(50);
            heap.Insert(100);
            heap.Insert(25);
            heap.Insert(33);

            var first = heap.Root;
            heap.DeleteRoot();
            var second = heap.Root;
            heap.DeleteRoot();
            var third = heap.Root;
            heap.DeleteRoot();
            var fourth = heap.Root;

            Assert.IsTrue(first == 100);
            Assert.IsTrue(second == 50);
            Assert.IsTrue(third == 33);
            Assert.IsTrue(fourth == 25);
        }
        
        [Test]
        public void IterateData_min() {
            
            var heap = GetHeap(SortOrder.Ascending);
            heap.Insert(50);
            heap.Insert(100);
            heap.Insert(25);
            heap.Insert(33);

            var first = heap.Root;
            heap.DeleteRoot();
            var second = heap.Root;
            heap.DeleteRoot();
            var third = heap.Root;
            heap.DeleteRoot();
            var fourth = heap.Root;

            Assert.IsTrue(first == 25);
            Assert.IsTrue(second == 33);
            Assert.IsTrue(third == 50);
            Assert.IsTrue(fourth == 100);
        }

        [Test]
        public void GetEnumeratorGeneric() {
            
            var heap = GetHeap(SortOrder.Ascending);
            heap.Insert(50);
            heap.Insert(100);
            heap.Insert(25);
            heap.Insert(33);

            var list = heap.ToList();

            // The output is now a list, which is 0-indexed.
            Assert.IsTrue(list.Count == 4);

            Assert.IsTrue(list[0] == 25);
            Assert.IsTrue(list[1] == 33);
            Assert.IsTrue(list[2] == 50);
            Assert.IsTrue(list[3] == 100);
        }

        [Test]
        public void GetEnumerator() {
            
            var heap = GetHeap(SortOrder.Ascending);
            heap.Insert(50);
            heap.Insert(100);
            heap.Insert(25);
            heap.Insert(33);

            var enumerable = (IEnumerable) heap;

            var enumerator = enumerable.GetEnumerator();
            
            enumerator.MoveNext();
            Assert.IsTrue((int)enumerator.Current == 25);
            enumerator.MoveNext();
            Assert.IsTrue((int)enumerator.Current == 33);
            enumerator.MoveNext();
            Assert.IsTrue((int)enumerator.Current == 50);
            enumerator.MoveNext();
            Assert.IsTrue((int)enumerator.Current == 100);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [Test]
        public void MassiveLoadTest() {

            // Constant seed to ensure constant test.
            Random r = new Random(1);

            var heap = GetHeap(SortOrder.Ascending);

            for (int i = 0; i < 100000; i++) {
                heap.Insert(r.Next(100));
            }

            var last = int.MinValue;
            while (heap.Any()) {
                Assert.IsTrue(last <= heap.Root);
                last = heap.Root;
                heap.DeleteRoot();
            }

        }

    }
}
