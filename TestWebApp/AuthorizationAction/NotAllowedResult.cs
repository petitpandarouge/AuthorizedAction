namespace TestWebApp.AuthorizationAction
{
    /// <summary>
    /// Class defining the not allowed result when checking policies.
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public class NotAllowedResult<TAction> : IPolicyResult<TAction>
        where TAction : class
    {
        #region Properties

        /// <summary>
        /// Stores the default value of the not allowed result.
        /// </summary>
        public static NotAllowedResult<TAction> Default => new NotAllowedResult<TAction>();

        #endregion // Properties

        #region AllowedResult<TAction>

        #region Properties

        /// <summary>
        /// Gets the flag indicating if the action can be executed.
        /// </summary>
        public bool Allowed { get => false; } 

        /// <summary>
        /// Gets the action to execute.
        /// </summary>
        public TAction Action { get => null; }

        #endregion // Properties

        #endregion // AllowedResult<TAction>
    }
}
