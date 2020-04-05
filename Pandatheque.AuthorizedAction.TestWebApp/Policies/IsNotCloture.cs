using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies
{
    public class IsNotCloture : APolicy<IEnquetePolicyContext>, IIsNotCloture
    {
        public override Task<bool> CheckAsync(IEnquetePolicyContext context)
        {
            return Task.FromResult(context.Enquete.DateCloture.HasValue == false);
        }
    }
}
