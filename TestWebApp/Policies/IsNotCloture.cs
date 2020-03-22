using System;
using Pandatheque.AuthorizedAction;
using TestWebApp.Policies.Context;

namespace TestWebApp.Policies
{
    public class IsNotCloture : APolicy<IEnquetePolicyContext>, IIsNotCloture
    {
        public override bool Check(IEnquetePolicyContext context)
        {
            return context.Enquete.DateCloture.HasValue == false;
        }
    }
}
