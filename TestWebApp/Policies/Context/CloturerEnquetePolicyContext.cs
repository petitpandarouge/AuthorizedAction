using TestWebApp.Models;

namespace TestWebApp.Policies.Context
{
    public class CloturerEnquetePolicyContext : IUtilisateurPolicyContext, IEnquetePolicyContext
    {
        #region Properties

        public Utilisateur Utilisateur { get; set; }

        public Enquete Enquete { get; set; }

        #endregion // Properties
    }
}
