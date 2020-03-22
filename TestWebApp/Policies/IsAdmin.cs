using Pandatheque.AuthorizedAction;
using TestWebApp.Models;
using TestWebApp.Policies.Context;

namespace TestWebApp.Policies
{
    public class IsAdmin : APolicy<IUtilisateurPolicyContext>, IIsAdmin
    {
        public override bool Check(IUtilisateurPolicyContext context)
        {
            return context.Utilisateur.Profile == Profile.Administrateur;
        }
    }
}
