using Pandatheque.AuthorizedAction;
using TestWebApp.Policies.Context;

namespace TestWebApp.Policies
{
    public interface IIsAdmin : IPolicy<IUtilisateurPolicyContext>
    {
    }
}
