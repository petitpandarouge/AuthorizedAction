using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace TestWebApp.AuthorizationAction
{
    /// <summary>
    /// Class defining a global policy checker for a given action.
    /// </summary>
    /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
    /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
    public class AuthorizedActionChecker<TPolicyContext, TAction> : IAuthorizedActionChecker<TPolicyContext, TAction>
        where TAction : class
    {
        #region Fields

        /// <summary>
        /// Stores the specific actions list.
        /// </summary>
        private readonly List<IAuthorizedSpecificActionChecker<TPolicyContext, TAction>> specificActions;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedActionChecker{TPolicyContext, TAction}"/> class.
        /// </summary>
        /// <param name="provider">The global service provider.</param>
        public AuthorizedActionChecker(IServiceProvider provider)
        {
            // Getting the specific actions checkers
            this.specificActions = new List<IAuthorizedSpecificActionChecker<TPolicyContext, TAction>>(provider.GetServices<IAuthorizedSpecificActionChecker<TPolicyContext, TAction>>());
        }

        #endregion // Constructors

        #region IAuthorizedActionChecker<TPolicyContext, TAction>

        #region Methods

        /// <summary>
        /// Checks if the policies are satisfied for the given action.
        /// </summary>
        /// <param name="context">The policies checking context.</param>
        /// <returns>The policies checking result.</returns>
        public IPolicyResult<TAction> CheckPolicies(TPolicyContext context)
        {
            foreach (IAuthorizedActionChecker<TPolicyContext, TAction> subAction in this.specificActions)
            {
                IPolicyResult<TAction> result = subAction.CheckPolicies(context);
                if (result.Allowed)
                {
                    return result;
                }
            }

            return NotAllowedResult<TAction>.Default;
        }

        #endregion // Methods

        #endregion // IAuthorizedActionChecker<TPolicyContext, TAction>
    }
}
