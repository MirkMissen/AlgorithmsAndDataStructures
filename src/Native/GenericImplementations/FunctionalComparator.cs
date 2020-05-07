using System;
using System.Collections.Generic;
using System.Text;

namespace Native.GenericImplementations {

    /// <summary>
    /// Defines a generic-functional comparator, which can comparer a specific entity type.
    /// </summary>
    public class FunctionalComparator<T> : IComparer<T> {

        /// <summary>
        /// Refers to a callback, which can get the comparable property of the given type.
        /// </summary>
        private readonly Func<T, IComparable> _comparableElement;

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="comparableElement">Defines a callback, which can get the comparable property of the given type</param>
        public FunctionalComparator(Func<T, IComparable> comparableElement) {
            this._comparableElement = comparableElement;
        }
        
        /// <summary>
        /// Compares the given values.
        /// </summary>
        public int Compare(T x, T y) {
            var _x = _comparableElement(x);
            var _y = _comparableElement(y);
            return _x.CompareTo(_y);
        }
    }
}
