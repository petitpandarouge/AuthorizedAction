using Pandatheque.AuthorizedAction.TestWebApp.Models;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies.Context
{
    public interface IUtilisateurPolicyContext
    {
        #region Properties

        Utilisateur Utilisateur { get; }

        #endregion // Properties
    }
}
