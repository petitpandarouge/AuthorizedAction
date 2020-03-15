using Microsoft.Extensions.DependencyInjection;

namespace TestWebApp.AuthorizationAction.Extensions.DependencyInjection
{
    /// <summary>
    /// Services collection collection for the authorized action dependency injection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        #region Methods

        /// <summary>
        /// Adds a policy in the services collection.
        /// </summary>
        /// <typeparam name="TPolicy">The type of the policy.</typeparam>
        /// <typeparam name="TImplementation">The type of the policy implementation.</typeparam>
        /// <param name="services">The extended service collection.</param>
        public static void AddPolicy<TPolicy, TImplementation>(this IServiceCollection services)
            where TPolicy : class, IPolicy
            where TImplementation : class, TPolicy
        {
            services.AddScoped<TPolicy, TImplementation>();
        }

        /// <summary>
        /// Adds an authorized action in the services collection.
        /// </summary>
        /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
        /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
        /// <param name="services">The extended service collection.</param>
        /// <returns>The authorization action checker builder.</returns>
        public static IAuthorizedActionCheckerBuilder<TPolicyContext, TAction> AddAuthorizedAction<TPolicyContext, TAction>(this IServiceCollection services)
            where TAction : class
        {
            return new AuthorizedActionCheckerBuilder<TPolicyContext, TAction>(services);
        }

        #endregion // Methods
    }
}
