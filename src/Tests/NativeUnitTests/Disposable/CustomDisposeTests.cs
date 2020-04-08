using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NativeUnitTests.Disposable {

    [TestFixture]
    class CustomDisposeTests {


        [Test]
        public void EventsRaised() {

            var d = new Disposable();
            
            var disposing = false;
            var disposed = false;

            d.Disposing += (s, e) => disposing = true;
            d.Disposed += (s, e) => disposed = true;

            d.Dispose();

            Assert.IsTrue(d.IsDisposed());
            Assert.IsTrue(disposed);
            Assert.IsTrue(disposing);
        }
        
        private class Disposable : Native.Abstractions.AbstractDisposable {
            protected override void Dispose(bool disposing) {
                try {
                    // nothing.
                }
                finally {
                    base.Dispose(disposing);
                }
            }
        }

    }
}
