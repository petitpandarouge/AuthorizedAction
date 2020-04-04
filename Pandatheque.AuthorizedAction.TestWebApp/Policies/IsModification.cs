using Pandatheque.AuthorizedAction.TestWebApp.Models;
using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies
{
    public class IsModification : APolicy<IUtilisateurPolicyContext>, IIsModification
    {
        public override bool Check(IUtilisateurPolicyContext context)
        {
            return context.Utilisateur.Profile == Profile.Modification;
        }
    }
}
