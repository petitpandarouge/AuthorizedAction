using System;
using System.Collections.Generic;

namespace TestWebApp.AuthorizationAction
{
    /// <summary>
    /// Class defining a global policy checker for a given action.
    /// </summary>
    /// <typeparam name="TPolicyContext">The type of the context used to check the policies.</typeparam>
    /// <typeparam name="TAction">The type of the authorized action to execute.</typeparam>
    public class AuthorizedActionChecker<TPolicyContext, TAction> : IAuthorizedActionChecker<TPolicyContext, TAction>
        where TAction : class
    {
        #region Fields

        /// <summary>
        /// Stores the sub actions list.
        /// </summary>
        private readonly HashSet<IAuthorizedActionChecker<TPolicyContext, TAction>> subActions;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedActionChecker{TPolicyContext, TAction}"/> class.
        /// </summary>
        public AuthorizedActionChecker()
        {
            this.subActions = new HashSet<IAuthorizedActionChecker<TPolicyContext, TAction>>();
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Adds a sub action to the action checker.
        /// </summary>
        /// <param name="subAction">The authorized sub action.</param>
        public void AddSubAction<TSpecificAction>(IAuthorizedSubActionChecker<TPolicyContext, TAction, TSpecificAction> subAction)
            where TSpecificAction : class, TAction
        {
            if (subAction == null)
            {
                throw new ArgumentNullException(nameof(subAction));
            }

            this.subActions.Add(subAction);
        }

        #endregion // Methods

        #region IAuthorizedActionChecker<TPolicyContext, TAction>

        #region Methods

        /// <summary>
        /// Checks if the policies are satisfied for the given action.
        /// </summary>
        /// <param name="context">The policies checking context.</param>
        /// <returns>The policies checking result.</returns>
        public IPolicyResult<TAction> CheckPolicies(TPolicyContext context)
        {
            foreach (IAuthorizedActionChecker<TPolicyContext, TAction> subAction in this.subActions)
            {
                IPolicyResult<TAction> result = subAction.CheckPolicies(context);
                if (result.Allowed)
                {
                    return result;
                }
            }

            return NotAllowedResult<TAction>.Default;
        }

        #endregion // Methods

        #endregion // IAuthorizedActionChecker<TPolicyContext, TAction>
    }
}
