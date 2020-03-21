using Microsoft.Extensions.DependencyInjection;
using System;

namespace TestWebApp.AuthorizationAction.Extensions.DependencyInjection
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
        /// Stores the service provider.
        /// </summary>
        private readonly ServiceProvider serviceProvider;

        /// <summary>
        /// Stores the policies.
        /// </summary>
        private readonly PolicyCollection policies;

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

            this.policies = new PolicyCollection();
            this.services = services;
            this.serviceProvider = services.BuildServiceProvider();

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
        public IAuthorizedActionCheckerBuilder<TPolicyContext, TAction> Check<TPolicy>()
            where TPolicy : IPolicy
        {
            // Registering the policy.
            this.policies.Add(this.serviceProvider.GetRequiredService<TPolicy>());

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

            // Registering the specific action checker.
            this.services.AddScoped<IAuthorizedSpecificActionChecker<TPolicyContext, TAction>>(serviceProvider => new AuthorizedSpecificActionChecker<TPolicyContext, TAction, TSpecificAction>(this.policies, serviceProvider));

            // Cleanning the policies collection for the next specific action.
            this.policies.Clear();

            return this;
        }

        #endregion // Methods

        #endregion // IAuthorizedActionCheckerBuilder<TPolicyContext, TAction>
    }
}
