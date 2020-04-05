using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies
{
    public class IsNowApresOuverture : APolicy<IEnquetePolicyContext>, IIsNowApresOuverture
    {
        public override Task<bool> CheckAsync(IEnquetePolicyContext context)
        {
            return Task.FromResult(context.Enquete.DateOuverture <= context.TimeStamp);
        }
    }
}
