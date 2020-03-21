using TestWebApp.Models;
using TestWebApp.Policies.Context;

namespace TestWebApp.Policies
{
    public class IsModification : AUtilisateurPolicy, IIsModification
    {
        public override bool Check(IUtilisateurPolicyContext context)
        {
            return context.Utilisateur.Profile == Profile.Modification;
        }
    }
}
