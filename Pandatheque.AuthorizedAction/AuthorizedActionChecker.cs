using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Pandatheque.AuthorizedAction
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
        /// Stores the logger.
        /// </summary>
        private ILogger<AuthorizedActionChecker<TPolicyContext, TAction>> logger;

        /// <summary>
        /// Stores the service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Stores the specific actions list.
        /// </summary>
        private List<IAuthorizedSpecificActionChecker<TPolicyContext, TAction>> specificActions;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedActionChecker{TPolicyContext, TAction}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The global service provider.</param>
        public AuthorizedActionChecker(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
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
            if (this.logger == null)
            {
                // Getting the logger lazilly at the first call.
                this.logger = this.serviceProvider.GetService<ILogger<AuthorizedActionChecker<TPolicyContext, TAction>>>();
            }

            this.logger.LogDebug($"Checking the policies of the {typeof(TAction).FullName} action.");

            if (this.specificActions == null)
            {
                // Getting the specific actions checkers lazilly at the first call.
                this.specificActions = new List<IAuthorizedSpecificActionChecker<TPolicyContext, TAction>>(this.serviceProvider.GetServices<IAuthorizedSpecificActionChecker<TPolicyContext, TAction>>());
            }

            // Returning the first specific action that checks all its policies.
            foreach (IAuthorizedSpecificActionChecker<TPolicyContext, TAction> specificAction in this.specificActions)
            {
                IPolicyResult<TAction> result = specificAction.CheckPolicies(context);
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
