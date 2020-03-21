using System;

namespace TestWebApp.AuthorizationAction
{
    /// <summary>
    /// Interface defining a global policy checker for a given specific action.
    /// </summary>
    /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
    /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
    internal interface IAuthorizedSpecificActionChecker<TPolicyContext, TAction> : IAuthorizedActionChecker<TPolicyContext, TAction>
        where TAction : class
    {
        #region Properties

        /// <summary>
        /// Gets the specific action type.
        /// </summary>
        Type SpecificActionType { get; }

        #endregion // Properties
    }

    /// <summary>
    /// Interface defining a global policy checker for a given specific action.
    /// </summary>
    /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
    /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
    /// <typeparam name="TSpecificAction">The type of the specific authorized action to execute.</typeparam>
    internal interface IAuthorizedSpecificActionChecker<TPolicyContext, TAction, TSpecificAction> : IAuthorizedSpecificActionChecker<TPolicyContext, TAction>
        where TAction : class
        where TSpecificAction : class, TAction
    {
    }
}
