using System;

namespace Pandatheque.AuthorizedAction
{
    /// <summary>
    /// Interface defining a policy context.
    /// </summary>
    public interface IPolicyContext
    {
        #region Properties

        /// <summary>
        /// Gets the context time stamp.
        /// </summary>
        DateTime TimeStamp { get; }

        #endregion // Properties
    }
}
