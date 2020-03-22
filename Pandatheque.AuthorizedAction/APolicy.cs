using System;

namespace Pandatheque.AuthorizedAction
{
    public abstract class APolicy<TContext> : IPolicy<TContext>
        where TContext : class 
    {
        #region IPolicy

        #region Methods

        /// <summary>
        /// Checks if the policy is satisfied.
        /// </summary>
        /// <param name="context">The policy checking context.</param>
        /// <returns>True if the policy is satisfied, false otherwise.</returns>
        bool IPolicy.Check(object context)
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

            return this.Check(typedContext);
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
        public abstract bool Check(TContext context);

        #endregion // Methods

        #endregion // IPolicy<TContext>
    }
}
