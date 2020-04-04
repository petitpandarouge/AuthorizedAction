using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies
{
    public class IsNowApresOuverture : APolicy<IEnquetePolicyContext>, IIsNowApresOuverture
    {
        public override bool Check(IEnquetePolicyContext context)
        {
            return context.Enquete.DateOuverture <= context.TimeStamp;
        }
    }
}
