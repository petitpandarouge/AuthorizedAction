using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace TestWebApp.AuthorizationAction
{
    /// <summary>
    /// Class defining a policy collection.
    /// </summary>
    public class PolicyCollection : HashSet<IPolicy>
    {
        #region Methods

        /// <summary>
        /// Build a policy collection from the policy types using the given service provider.
        /// </summary>
        /// <param name="policyTypes">The types of the policies to satisfy.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns></returns>
        public static PolicyCollection Build(HashSet<Type> policyTypes, IServiceProvider serviceProvider)
        {
            PolicyCollection policies = new PolicyCollection();

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
            foreach (IPolicy policy in this)
            {
                if (policy.Check(context) == false)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion // Methods
    }
}
