﻿namespace Pandatheque.AuthorizedAction
{
    /// <summary>
    /// Result of the policy check.
    /// </summary>
    /// <typeparam name="TAction">The type of the action to execute if the policy check succeed.</typeparam>
    public interface IPolicyResult<TAction>
        where TAction : class
    {
        #region Properties

        /// <summary>
        /// Gets the flag indicating if the action can be executed.
        /// </summary>
        bool Allowed { get; }

        /// <summary>
        /// Gets the action to execute.
        /// </summary>
        TAction Action { get; }

        #endregion // Properties
    }
}
