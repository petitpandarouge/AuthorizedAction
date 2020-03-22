using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Pandatheque.AuthorizedAction.Extensions.DependencyInjection
{
    /// <summary>
    /// Class defining the authorization action checker builder.
    /// </summary>
    /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
    /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
    internal class AuthorizedActionCheckerBuilder<TPolicyContext, TAction> : IAuthorizedActionCheckerBuilder<TPolicyContext, TAction>
        where TAction : class
    {
        #region Fields

        /// <summary>
        /// Stores the services collection.
        /// </summary>
        private readonly IServiceCollection services;

        /// <summary>
        /// Stores the policy type for the current specific action.
        /// </summary>
        private HashSet<Type> policyTypes;

        /// <summary>
        /// Stores the map between a specific action type and its policy types.
        /// </summary>
        private readonly ConcurrentDictionary<Type, HashSet<Type>> specificActionTypeToPolicyTypes;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedActionCheckerBuilder{TPolicyContext, TAction}"/> class.
        /// </summary>
        /// <param name="services">The services collection.</param>
        public AuthorizedActionCheckerBuilder(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            this.policyTypes = new HashSet<Type>();
            this.specificActionTypeToPolicyTypes = new ConcurrentDictionary<Type, HashSet<Type>>();
            this.services = services;

            // Registering the main checker.
            this.services.AddScoped<IAuthorizedActionChecker<TPolicyContext, TAction>, AuthorizedActionChecker<TPolicyContext, TAction>>();            
        }

        #endregion // Constructors

        #region IAuthorizedActionCheckerBuilder<TPolicyContext, TAction>

        #region Methods

        /// <summary>
        /// Adds a check order of the given policy.
        /// </summary>
        /// <typeparam name="TPolicy">The type of the context used to check the policies.</typeparam>
        /// <returns>The authorization action checker builder.</returns>
        public IAuthorizedActionCheckerBuilder<TPolicyContext, TAction> CheckPolicy<TPolicy>()
            where TPolicy : IPolicy
        {
            // Registering the policy type.
            this.policyTypes.Add(typeof(TPolicy));

            return this;
        }

        /// <summary>
        /// Adds an execute order of the given action.
        /// </summary>
        /// <typeparam name="TSpecificAction">The specific action.</typeparam>
        /// <returns>The authorization action checker builder.</returns>
        public IAuthorizedActionCheckerBuilder<TPolicyContext, TAction> ThenExecute<TSpecificAction>()
            where TSpecificAction : class, TAction
        {
            // Registering the specific action.
            this.services.AddScoped<TSpecificAction>();

            //  Registering the policy types for the specific action.
            Type specificActionType = typeof(TSpecificAction);
            this.specificActionTypeToPolicyTypes[specificActionType] = this.policyTypes;

            // Registering the specific action checker.
            this.services.AddScoped<IAuthorizedSpecificActionChecker<TPolicyContext, TAction>>(serviceProvider => new AuthorizedSpecificActionChecker<TPolicyContext, TAction, TSpecificAction>(this.specificActionTypeToPolicyTypes[specificActionType], serviceProvider));

            // Initializing the policy types collection for the next specific action.
            this.policyTypes = new HashSet<Type>();

            return this;
        }

        #endregion // Methods

        #endregion // IAuthorizedActionCheckerBuilder<TPolicyContext, TAction>
    }
}
