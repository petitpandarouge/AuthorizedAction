namespace TestWebApp.AuthorizationAction
{
    /// <summary>
    /// Interface defining a global policy checker for a given action.
    /// </summary>
    /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
    /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
    public interface IAuthorizedActionChecker<TPolicyContext, TAction>
        where TAction : class
    {
        #region Methods

        /// <summary>
        /// Checks if the policies are satisfied for the given action.
        /// </summary>
        /// <param name="context">The policies checking context.</param>
        /// <returns>The policies checking result.</returns>
        IPolicyResult<TAction> CheckPolicies(TPolicyContext context);

        #endregion // Methods
    }
}
