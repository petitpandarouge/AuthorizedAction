using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;

namespace TestWebApp.AuthorizationAction.Extensions.DependencyInjection
{
    /// <summary>
    /// Interface defining the authorization action checker builder.
    /// </summary>
    /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
    /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
    public interface IAuthorizedActionCheckerBuilder<TPolicyContext, TAction>
        where TAction: class
    {
        #region Methods

        /// <summary>
        /// Adds a check order of the given policy.
        /// </summary>
        /// <typeparam name="TPolicy">The type of the context used to check the policies.</typeparam>
        /// <returns>The authorization action checker builder.</returns>
        IAuthorizedActionCheckerBuilder<TPolicyContext, TAction> Check<TPolicy>()
            where TPolicy : IPolicy;

        /// <summary>
        /// Adds an execute order of the given action.
        /// </summary>
        /// <typeparam name="TSpecificAction">The specific action.</typeparam>
        /// <returns>The authorization action checker builder.</returns>
        IAuthorizedActionCheckerBuilder<TPolicyContext, TAction> ThenExecute<TSpecificAction>()
            where TSpecificAction : class, TAction;

        #endregion // Methods
    }
}
