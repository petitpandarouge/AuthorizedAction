using TestWebApp.AuthorizationAction;
using TestWebApp.Policies.Context;

namespace TestWebApp.Policies
{
    public interface IIsApresOuverture : IPolicy<IEnquetePolicyContext>
    {
    }
}
