using System;
using Pandatheque.AuthorizedAction;
using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies
{
    public class IsAvantFermeture : APolicy<IEnquetePolicyContext>, IIsAvantFermeture
    {
        public override bool Check(IEnquetePolicyContext context)
        {
            return DateTime.Now < context.Enquete.DateFermeture;
        }
    }
}
