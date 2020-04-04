using System;

namespace Pandatheque.AuthorizedAction
{
    /// <summary>
    /// Base class for a policy context.
    /// </summary>
    public abstract class APolicyContext : IPolicyContext
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="APolicyContext"/> class.
        /// </summary>
        protected APolicyContext()
        {
            this.TimeStamp = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="APolicyContext"/> class.
        /// </summary>
        /// <param name="timeStamp">The time stamp.</param>
        protected APolicyContext(DateTime timeStamp)
        {
            this.TimeStamp = timeStamp;
        }

        #endregion // Constructors

        #region IPolicyContext

        #region Properties

        /// <summary>
        /// Gets the context time stamp.
        /// </summary>
        public DateTime TimeStamp { get; private set; }

        #endregion // Properties

        #endregion // IPolicyContext
    }
}
