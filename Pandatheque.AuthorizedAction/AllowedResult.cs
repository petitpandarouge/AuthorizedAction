using System;

namespace Pandatheque.AuthorizedAction
{
    /// <summary>
    /// Class defining the allowed result when checking policies.
    /// </summary>
    /// <typeparam name="TAction">The type of the allowed action.</typeparam>
    public class AllowedResult<TAction> : IPolicyResult<TAction>
        where TAction : class
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AllowedResult{TAction}"/> class.
        /// </summary>
        /// <param name="action">The allowed action.</param>
        public AllowedResult(TAction action)
        {
            this.Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        #endregion // Constructors

        #region AllowedResult<TAction>

        #region Properties

        /// <summary>
        /// Gets the flag indicating if the action can be executed.
        /// </summary>
        public bool Allowed { get => true; } 

        /// <summary>
        /// Gets the action to execute.
        /// </summary>
        public TAction Action { get; private set; }

        #endregion // Properties

        #endregion // AllowedResult<TAction>
    }
}
