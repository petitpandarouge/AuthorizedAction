using TestWebApp.Models;
using TestWebApp.Policies.Context;

namespace TestWebApp.Policies
{
    public class IsAdmin : IIsAdmin
    {
        public bool Check(IUtilisateurPolicyContext context)
        {
            return context.Utilisateur.Profile == Profile.Administrateur;
        }
    }
}
