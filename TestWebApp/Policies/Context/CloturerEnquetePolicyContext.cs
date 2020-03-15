using TestWebApp.Models;

namespace TestWebApp.Policies.Context
{
    public class CloturerEnquetePolicyContext : IUtilisateurPolicyContext
    {
        public Utilisateur Utilisateur { get; set; }
    }
}
