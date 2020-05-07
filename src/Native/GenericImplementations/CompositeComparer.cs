using System;
using System.Collections.Generic;
using System.Text;

namespace Native.GenericImplementations {
    public class CompositeComparer<T> : IComparer<T> {

        private readonly IComparer<T> _comparer;
        private readonly Func<int, int> _formatterFunc;

        /// <summary>
        /// Defines a composite comparer, which uses another comparer and alters the output from it.
        /// The original use for it was as negator.
        /// </summary>
        /// <param name="comparer">Defines the composing comparer.</param>
        /// <param name="formatterFunc">Defines the function to alter the output of the composing comparer.</param>
        public CompositeComparer(IComparer<T> comparer, Func<int, int> formatterFunc) {
            this._comparer = comparer;
            this._formatterFunc = formatterFunc;
        }

        public int Compare(T x, T y) {
            return this._formatterFunc.Invoke(this._comparer.Compare(x, y));
        }
    }
}
