using System;
using Pandatheque.AuthorizedAction;
using TestWebApp.Policies.Context;

namespace TestWebApp.Policies
{
    public class IsApresOuverture : APolicy<IEnquetePolicyContext>, IIsApresOuverture
    {
        public override bool Check(IEnquetePolicyContext context)
        {
            return context.Enquete.DateOuverture <= DateTime.Now;
        }
    }
}
