using Native.Abstractions.Interfaces;
using System;

namespace Abstractions
{

    /// <summary>
    /// Defines a generic implementation of the IDisposable interface.
    /// </summary>
    public abstract class AbstractDisposable : IMyDisposeable
    {

        /// <summary>
        /// Raised before disposing this object.
        /// </summary>
        public event EventHandler Disposing;

        /// <summary>
        /// Raised when this object has been disposed.
        /// </summary>
        public event EventHandler Disposed;

        /// <summary>
        /// Defines if this instance has been disposed.
        /// </summary>
        private bool _isDisposed; // To detect redundant calls

        /// <summary>
        /// Override this to do further disposal.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._isDisposed)
            {
                if (disposing)
                {
                }
            }
            this._isDisposed = true;
        }

        /// <summary>
        ///         ''' Disposes this instance.
        ///         ''' </summary>
        public void Dispose()
        {
            Disposing.Invoke(this, EventArgs.Empty);
            this.Dispose(true);
            Disposed.Invoke(this, EventArgs.Empty);
        }

        public bool IsDisposed() => this._isDisposed;
    }
}
