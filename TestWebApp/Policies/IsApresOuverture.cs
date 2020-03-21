using System;
using TestWebApp.AuthorizationAction;
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
