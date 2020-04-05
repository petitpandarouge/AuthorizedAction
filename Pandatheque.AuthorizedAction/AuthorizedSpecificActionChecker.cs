using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction
{
    /// <summary>
    /// Class defining a global policy checker for a given sub action.
    /// </summary>
    /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
    /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
    /// <typeparam name="TSpecificAction">The type of the speicific action to execute.</typeparam>
    internal class AuthorizedSpecificActionChecker<TPolicyContext, TAction, TSpecificAction> : IAuthorizedSpecificActionChecker<TPolicyContext, TAction, TSpecificAction>
        where TPolicyContext : class, IPolicyContext
        where TAction : class
        where TSpecificAction : class, TAction
    {
        #region Fields

        /// <summary>
        /// Stores the logger.
        /// </summary>
        private ILogger<AuthorizedSpecificActionChecker<TPolicyContext, TAction, TSpecificAction>> logger;

        /// <summary>
        /// Stores the service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Stores the policy type for the current specific action.
        /// </summary>
        private readonly HashSet<Type> policyTypes;

        /// <summary>
        /// Stores the policies.
        /// </summary>
        private PolicyCollection policies;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedSpecificActionChecker{TPolicyContext, TAction, TSpecificAction}"/> class.
        /// </summary>
        /// <param name="policyTypes">The types of the policies to satisfy.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public AuthorizedSpecificActionChecker(HashSet<Type> policyTypes, IServiceProvider serviceProvider)
        {
            this.policyTypes = policyTypes ?? throw new ArgumentNullException(nameof(policyTypes));
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
                this.logger = this.serviceProvider.GetService<ILogger<AuthorizedSpecificActionChecker<TPolicyContext, TAction, TSpecificAction>>>();
            }

            this.logger.LogDebug($"Checking the policies of the {this.SpecificActionType.FullName} specific action.");

            if (this.policies == null)
            {
                // Getting the policies lazilly at the first call.
                this.policies = PolicyCollection.Build(policyTypes, serviceProvider);
            }

            // Returning the specific action if it satisfies all the policies.
            bool result = await this.policies.CheckAsync(context).ConfigureAwait(false);
            if (result)
            {
                this.logger.LogDebug($"All the policies are satisfied. The {this.SpecificActionType.FullName} specific action execution is allowed.");
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
        public Type SpecificActionType 
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
