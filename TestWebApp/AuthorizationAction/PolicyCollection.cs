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
