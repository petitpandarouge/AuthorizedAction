namespace TestWebApp.AuthorizationAction
{
    /// <summary>
    /// Interface defining a global policy checker for a given sub action.
    /// </summary>
    /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
    /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
    /// <typeparam name="TSpecificAction">The type of the specific authorized action to execute.</typeparam>
    public interface IAuthorizedSubActionChecker<TPolicyContext, TAction, TSpecificAction> : IAuthorizedActionChecker<TPolicyContext, TAction>
        where TAction : class
        where TSpecificAction : class, TAction
    {
    }
}
