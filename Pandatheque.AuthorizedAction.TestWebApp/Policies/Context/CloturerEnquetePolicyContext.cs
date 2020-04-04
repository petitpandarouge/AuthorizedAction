using Pandatheque.AuthorizedAction.TestWebApp.Models;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies.Context
{
    public class CloturerEnquetePolicyContext : APolicyContext, IUtilisateurPolicyContext, IEnquetePolicyContext
    {
        #region Properties

        public Utilisateur Utilisateur { get; set; }

        public Enquete Enquete { get; set; }

        #endregion // Properties
    }
}
