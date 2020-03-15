using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;

namespace TestWebApp.AuthorizationAction.Extensions.DependencyInjection
{
    public interface IAuthorizedActionCheckerBuilder<TPolicyContext, TAction>
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
        /// <typeparam name="TPolicy"></typeparam>
        /// <returns></returns>
        IAuthorizedActionCheckerBuilder<TPolicyContext, TAction> ThenExecute<TSpecificAction>()
            where TSpecificAction : TAction;

        #endregion // Methods
    }
}
