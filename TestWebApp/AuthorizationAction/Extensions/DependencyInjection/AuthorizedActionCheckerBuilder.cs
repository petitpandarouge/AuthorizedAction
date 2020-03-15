using Microsoft.Extensions.DependencyInjection;
using System;
using TestWebApp.AuthorizationAction.DependencyInjection;

namespace TestWebApp.AuthorizationAction.Extensions.DependencyInjection
{
    internal class AuthorizedActionCheckerBuilder<TPolicyContext, TAction> : IAuthorizedActionCheckerBuilder<TPolicyContext, TAction>
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

            this.services = services;
            this.serviceProvider = services.BuildServiceProvider();
        }

        #endregion // Constructors

        #region IAuthorizedActionCheckerBuilder

        #region Methods

        /// <summary>
        /// Adds a check order of the given policy.
        /// </summary>
        /// <typeparam name="TPolicy">The type of the context used to check the policies.</typeparam>
        /// <returns>The authorization action checker builder.</returns>
        public IAuthorizedActionCheckerBuilder<TPolicyContext, TAction> Check<TPolicy>()
            where TPolicy : IPolicy
        {

            return this;
        }

        /// <summary>
        /// Adds an execute order of the given action.
        /// </summary>
        /// <typeparam name="TPolicy"></typeparam>
        /// <returns></returns>
        public IAuthorizedActionCheckerBuilder<TPolicyContext, TAction> ThenExecute<TSpecificAction>()
            where TSpecificAction : TAction
        {
            // Creating the checker in the services collections.
            //this.services.AddScoped<IAuthorizedActionChecker<TPolicyContext, TAction>>();

            return this;
        }

        #endregion // Methods

        #endregion // IAuthorizedActionCheckerBuilder
    }
}
