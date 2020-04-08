using System;
using System.Collections.Generic;
using Native.Abstractions.Interfaces;

namespace Native.Abstractions {

    /// <summary>
    /// Defines a generic implementation of the IDisposable interface.
    /// </summary>
    public abstract class AbstractDisposable : IMyDisposeable {

        /// <summary>
        /// Raised before disposing this object.
        /// </summary>
        public event EventHandler Disposing = delegate { };

        /// <summary>
        /// Raised when this object has been disposed.
        /// </summary>
        public event EventHandler Disposed = delegate { };

        /// <summary>
        /// Defines if this instance has been disposed.
        /// </summary>
        private bool _isDisposed; // To detect redundant calls

        /// <summary>
        /// Override this to do further disposal.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) {
            if (!this._isDisposed) {
                if (disposing) {
                }
            }
            
            this._isDisposed = true;
        }

        /// <summary>
        ///         ''' Disposes this instance.
        ///         ''' </summary>
        public void Dispose() {
            this.Disposing.Invoke(this, EventArgs.Empty);
            this.Dispose(true);
            this.Disposed.Invoke(this, EventArgs.Empty);
        }

        public bool IsDisposed() => this._isDisposed;
    }
}
