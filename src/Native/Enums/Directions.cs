using System;
using System.Collections.Generic;
using System.Text;

namespace Native.Enums {

    /// <summary>
    /// Defines a direction from a source to target.
    /// </summary>
    public enum IoDirection {

        /// <summary>
        /// Defines no direction
        /// </summary>
        None = 0,

        /// <summary>
        /// Defines an in-going connection.
        /// </summary>
        In = 1,

        /// <summary>
        /// Defines an out-going connection.
        /// </summary>
        Out = 2,

        /// <summary>
        /// Defines an in- and out-going connection
        /// </summary>
        Both = 3
    }


}
