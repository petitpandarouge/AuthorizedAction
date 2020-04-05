using System;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction
{
    /// <summary>
    /// Base class defining a policy.
    /// </summary>
    /// <typeparam name="TContext">The type of the context used to check the policy.</typeparam>
    public abstract class APolicy<TContext> : IPolicy<TContext>
        where TContext : class, IPolicyContext
    {
        #region IPolicy

        #region Methods

        /// <summary>
        /// Checks if the policy is satisfied.
        /// </summary>
        /// <param name="context">The policy checking context.</param>
        /// <returns>True if the policy is satisfied, false otherwise.</returns>
        async Task<bool> IPolicy.CheckAsync(object context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            TContext typedContext = context as TContext;
            if (typedContext == null)
            {
                string thisTypeName = this.GetType().FullName;
                string contextTypeName = typeof(TContext).FullName;
                throw new InvalidCastException($"The context given to a {thisTypeName} policy must of type {contextTypeName}.");
            }

            return await this.CheckAsync(typedContext).ConfigureAwait(false);
        }

        #endregion // Methods

        #endregion // IPolicy

        #region IPolicy<TContext>

        #region Methods

        /// <summary>
        /// Checks if the policy is satisfied.
        /// </summary>
        /// <param name="context">The policy checking context.</param>
        /// <returns>True if the policy is satisfied, false otherwise.</returns>
        public abstract Task<bool> CheckAsync(TContext context);

        #endregion // Methods

        #endregion // IPolicy<TContext>
    }
}
