using System;
using Pandatheque.AuthorizedAction;
using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies
{
    public class IsNotCloture : APolicy<IEnquetePolicyContext>, IIsNotCloture
    {
        public override bool Check(IEnquetePolicyContext context)
        {
            return context.Enquete.DateCloture.HasValue == false;
        }
    }
}
