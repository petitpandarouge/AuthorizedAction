using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Pandatheque.AuthorizedAction
{
    /// <summary>
    /// Class defining a policy collection.
    /// </summary>
    internal class PolicyCollection : HashSet<IPolicy>
    {
        #region Fields

        /// <summary>
        /// Stores the logger.
        /// </summary>
        private ILogger<PolicyCollection> logger;

        /// <summary>
        /// Stores the service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyCollection"/> class.
        /// </summary>
        /// <param name="serviceProvider">The global service provider</param>
        public PolicyCollection(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Build a policy collection from the policy types using the given service provider.
        /// </summary>
        /// <param name="policyTypes">The types of the policies to satisfy.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns></returns>
        public static PolicyCollection Build(HashSet<Type> policyTypes, IServiceProvider serviceProvider)
        {
            PolicyCollection policies = new PolicyCollection(serviceProvider);

            foreach (Type policyType in policyTypes)
            {
                policies.Add(serviceProvider.GetRequiredService(policyType) as IPolicy);
            }

            return policies;
        }

        /// <summary>
        /// Checks if the policy collection is satisfied.
        /// </summary>
        /// <param name="context">The policies context.</param>
        /// <returns>True if all the policies are satified, false otherwise.</returns>
        public bool Check(object context)
        {
            if (this.logger == null)
            {
                // Getting the logger lazilly at the first call.
                this.logger = this.serviceProvider.GetService<ILogger<PolicyCollection>>();
            }

            foreach (IPolicy policy in this)
            {
                if (policy.Check(context) == false)
                {
                    this.logger.LogDebug($"The {policy.GetType().FullName} policy is NOT satisfied.");
                    return false;
                }

                this.logger.LogDebug($"The {policy.GetType().FullName} policy is satisfied.");
            }

            return true;
        }

        #endregion // Methods
    }
}
