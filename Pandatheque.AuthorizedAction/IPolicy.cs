namespace Pandatheque.AuthorizedAction
{
    /// <summary>
    /// Interface defining a policy.
    /// </summary>
    /// <typeparam name="TContext">The type of the context used to check the policy.</typeparam>
    public interface IPolicy<TContext> : IPolicy
        where TContext : class, IPolicyContext
    {
        #region Methods

        /// <summary>
        /// Checks if the policy is satisfied.
        /// </summary>
        /// <param name="context">The policy checking context.</param>
        /// <returns>True if the policy is satisfied, false otherwise.</returns>
        bool Check(TContext context);

        #endregion // Methods
    }

    /// <summary>
    /// Interface used to define a policy without the genericity aspect.
    /// </summary>
    public interface IPolicy
    {
        #region Methods

        /// <summary>
        /// Checks if the policy is satisfied.
        /// </summary>
        /// <param name="context">The policy checking context.</param>
        /// <returns>True if the policy is satisfied, false otherwise.</returns>
        bool Check(object context);

        #endregion // Methods
    }
}
