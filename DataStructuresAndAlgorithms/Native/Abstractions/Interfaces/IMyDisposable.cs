using System;
using System.Collections.Generic;
using System.Text;

namespace Native.Abstractions.Interfaces
{
    /// <summary>
    /// Defines the contract for better functionalties of the <see cref="IDisposable"/> interface.
    /// </summary>
    public interface IMyDisposeable : IDisposable
    {

        /// <summary>
        /// Raised before disposing the object.
        /// </summary>
        event EventHandler Disposing;

        /// <summary>
        /// Raised after disposal of the object.
        /// </summary>
        event EventHandler Disposed;

        /// <summary>
        /// Retrives if the object has been disposed.
        /// </summary>
        /// <returns></returns>
        bool IsDisposed();
    }
}


