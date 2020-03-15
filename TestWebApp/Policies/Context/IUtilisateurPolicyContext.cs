using TestWebApp.Models;

namespace TestWebApp.Policies.Context
{
    public interface IUtilisateurPolicyContext
    {
        #region Properties

        Utilisateur Utilisateur { get; }

        #endregion // Properties
    }
}
