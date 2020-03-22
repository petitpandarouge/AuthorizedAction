using Pandatheque.AuthorizedAction;
using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies
{
    public interface IIsNotCloture : IPolicy<IEnquetePolicyContext>
    {
    }
}
