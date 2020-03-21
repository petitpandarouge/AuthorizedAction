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
    internal class AuthorizedSpecificActionChecker<TPolicyContext, TAction, TSpecificAction> : IAuthorizedSpecificActionChecker<TPolicyContext, TAction, TSpecificAction>
        where TAction : class
        where TSpecificAction : class, TAction
    {
        #region Fields

        /// <summary>
        /// Stores the service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Stores the policies.
        /// </summary>
        private readonly PolicyCollection policies;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedSpecificActionChecker{TPolicyContext, TAction, TSpecificAction}"/> class.
        /// </summary>
        /// <param name="policies">The policies to satisfy.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public AuthorizedSpecificActionChecker(PolicyCollection policies, IServiceProvider serviceProvider)
        {
            this.policies = policies;
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
            if (this.policies.Check(context))
            {
                return new AllowedResult<TAction>(this.serviceProvider.GetRequiredService<TSpecificAction>());
            }

            return NotAllowedResult<TAction>.Default;
        }

        #endregion // Methods

        #endregion // IAuthorizedActionChecker<TPolicyContext, TAction>

        #region IAuthorizedSpecificActionChecker<TPolicyContext, TAction>

        #region Properties

        /// <summary>
        /// Gets the specific action type.
        /// </summary>
        Type IAuthorizedSpecificActionChecker<TPolicyContext, TAction>.SpecificActionType 
        { 
            get
            {
                return typeof(TSpecificAction);
            }
        }

        #endregion // Properties

        #endregion // IAuthorizedSpecificActionChecker<TPolicyContext, TAction>
    }
}
