﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction
{
    /// <summary>
    /// Class defining a global policy checker for a given action.
    /// </summary>
    /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
    /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
    internal class AuthorizedActionChecker<TPolicyContext, TAction> : IAuthorizedActionChecker<TPolicyContext, TAction>
        where TPolicyContext : class, IPolicyContext
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
        /// Stores the specific action checkers list.
        /// </summary>
        private List<IAuthorizedSpecificActionChecker<TPolicyContext, TAction>> specificActionCheckers;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedActionChecker{TPolicyContext, TAction}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The global service provider.</param>
        public AuthorizedActionChecker(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        #endregion // Constructors

        #region IAuthorizedActionChecker<TPolicyContext, TAction>

        #region Methods

        /// <summary>
        /// Checks if the policies are satisfied for the given action.
        /// </summary>
        /// <param name="context">The policies checking context.</param>
        /// <returns>The policies checking result.</returns>
        public async Task<IPolicyResult<TAction>> CheckPoliciesAsync(TPolicyContext context)
        {
            if (this.logger == null)
            {
                // Getting the logger lazilly at the first call.
                this.logger = this.serviceProvider.GetService<ILogger<AuthorizedActionChecker<TPolicyContext, TAction>>>();
            }

            this.logger.LogDebug($"Checking the policies of the {typeof(TAction).FullName} action.");

            if (this.specificActionCheckers == null)
            {
                // Getting the specific actions checkers lazilly at the first call.
                this.specificActionCheckers = new List<IAuthorizedSpecificActionChecker<TPolicyContext, TAction>>(this.serviceProvider.GetServices<IAuthorizedSpecificActionChecker<TPolicyContext, TAction>>());
            }

            // Returning the first specific action that checks all its policies.
            foreach (IAuthorizedSpecificActionChecker<TPolicyContext, TAction> specificActionChecker in this.specificActionCheckers)
            {
                IPolicyResult<TAction> result = await specificActionChecker.CheckPoliciesAsync(context).ConfigureAwait(false);
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
