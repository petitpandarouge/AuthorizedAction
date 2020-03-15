using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace TestWebApp.AuthorizationAction
{
    /// <summary>
    /// Class defining a global policy checker for a given sub action.
    /// </summary>
    /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
    /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
    public class AuthorizedSubActionChecker<TPolicyContext, TAction, TSpecificAction> : IAuthorizedSubActionChecker<TPolicyContext, TAction, TSpecificAction>
        where TAction : class
        where TSpecificAction : class, TAction
    {
        #region Fields

        /// <summary>
        /// Stores the services collection.
        /// </summary>
        private readonly IServiceCollection services;

        /// <summary>
        /// Stores the policies.
        /// </summary>
        private readonly PolicyCollection policies;
        
        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedActionChecker{TPolicyContext, TAction}"/> class.
        /// </summary>
        /// <param name="policies">The policies to satisfy.</param>
        /// <param name="services">The services collection.</param>
        public AuthorizedSubActionChecker(PolicyCollection policies, IServiceCollection services)
        {
            this.policies = policies;
            this.services = services;
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
            if (this.policies.Check(context))
            {
                ServiceProvider serviceProvider = this.services.BuildServiceProvider();
                return new AllowedResult<TAction>(serviceProvider.GetRequiredService<TSpecificAction>());
            }

            return NotAllowedResult<TAction>.Default;
        }

        #endregion // Methods

        #endregion // IAuthorizedActionChecker<TPolicyContext, TAction>
    }
}
