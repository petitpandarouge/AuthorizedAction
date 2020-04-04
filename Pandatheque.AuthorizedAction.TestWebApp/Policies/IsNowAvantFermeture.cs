using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies
{
    public class IsNowAvantFermeture : APolicy<IEnquetePolicyContext>, IIsNowAvantFermeture
    {
        public override bool Check(IEnquetePolicyContext context)
        {
            return context.TimeStamp < context.Enquete.DateFermeture;
        }
    }
}
