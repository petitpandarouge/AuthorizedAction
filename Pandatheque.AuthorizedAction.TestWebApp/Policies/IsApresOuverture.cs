using System;
using Pandatheque.AuthorizedAction;
using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies
{
    public class IsApresOuverture : APolicy<IEnquetePolicyContext>, IIsApresOuverture
    {
        public override bool Check(IEnquetePolicyContext context)
        {
            return context.Enquete.DateOuverture <= DateTime.Now;
        }
    }
}
