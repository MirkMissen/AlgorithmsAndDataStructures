using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Array {

    /// <summary>
    /// An array based on a specific index. A regular array is zero-based, however some application requires another base.
    /// </summary>
    public class BasedArray<T> : IEnumerable<T> {

        /// <summary>
        /// Defines the specific base.
        /// </summary>
        private readonly int _base;

        /// <summary>
        /// Defines an internal collection which this data-structure will be an abstraction of.
        /// </summary>
        private readonly Func<IList<T>> _datasSource;
        
        /// <summary>
        /// Initializes a new instance with a specific base.
        /// </summary>
        /// <param name="arrayBase">A regular array is zero-based.</param>
        /// <param name="dataSource">Defines the data source of the original instance.</param>
        public BasedArray(int arrayBase, Func<IList<T>> dataSource) {
            this._base = arrayBase;
            this._datasSource = dataSource;
        }
        
        /// <summary>
        /// Accesses the specific index.
        /// </summary>
        /// <param name="index">The index of the element to get or set.</param>
        /// <returns></returns>
        public T this[int index] {
            get => this._datasSource.Invoke()[index - this._base];
            set => this._datasSource.Invoke()[index - this._base] = value;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the contents of this based array.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => this._datasSource.Invoke().GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through the contents of this based array.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => this._datasSource.Invoke().GetEnumerator();
    }
}
