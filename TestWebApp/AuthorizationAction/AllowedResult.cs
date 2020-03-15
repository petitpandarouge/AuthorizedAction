namespace TestWebApp.AuthorizationAction
{
    /// <summary>
    /// Class defining the allowed result when checking policies.
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public class AllowedResult<TAction> : IPolicyResult<TAction>
        where TAction : class
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AllowedResult{TAction}"/> class.
        /// </summary>
        public AllowedResult(TAction action)
        {
            this.Action = action;
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
