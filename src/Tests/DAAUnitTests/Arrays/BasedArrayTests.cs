using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Array;
using NuGet.Frameworks;
using NUnit.Framework;

namespace DataStructuresUnitTests.Arrays {

    [TestFixture]
    class BasedArrayTests {

        [Test]
        public void BasedArrayFromArray() {
            string[] s = new[] {""};
            var array = new BasedArray<string>(0, () => s);
            Assert.IsTrue(array[0] == "");
        }
        
        [Test]
        public void BasedArrayFromList() {
            var s = new List<string>() {""};
            var array = new BasedArray<string>(0, () => s);
            Assert.IsTrue(array[0] == "");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void IsBasedOnSpecifiedIndex(int basedIndex) {
            var list = new List<string> {"Hello", "There"};
            var array = new BasedArray<string>(basedIndex, () => list);

            Assert.IsTrue(array[basedIndex].Equals("Hello"));
            Assert.IsTrue(array[basedIndex + 1].Equals("There"));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void AccessBoundaries(int basedIndex) {
            var list = new List<string> {"Hello", "There"};
            var array = new BasedArray<string>(basedIndex, () => list.ToArray());
            
            string value = null;
            Assert.Throws<ArgumentOutOfRangeException>(() => value = array[basedIndex + 2]);
            Assert.Throws<ArgumentOutOfRangeException>(() => value = array[basedIndex - 1]);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void SetValues(int basedIndex) {
            var list = new List<string> {"Hello", "There"};
            var array = new BasedArray<string>(basedIndex, () => list);

            array[basedIndex] = "T1";
            array[basedIndex + 1] = "T2";

            Assert.IsTrue(array[basedIndex].Equals("T1"));
            Assert.IsTrue(array[basedIndex + 1].Equals("T2"));
        }
        
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void AsEnumerable(int basedIndex) {
            var list = new List<string> {"Hello", "There"};
            var array = new BasedArray<string>(basedIndex, () => list.ToArray());
            
            // using linq, hence the GetEnumerator.
            Assert.IsTrue(array.Count().Equals(2));
            Assert.IsTrue(((IEnumerable) array).GetEnumerator() != null);
        }


    }
}
