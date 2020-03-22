using System;
using Pandatheque.AuthorizedAction;
using TestWebApp.Policies.Context;

namespace TestWebApp.Policies
{
    public class IsAvantFermeture : APolicy<IEnquetePolicyContext>, IIsAvantFermeture
    {
        public override bool Check(IEnquetePolicyContext context)
        {
            return DateTime.Now < context.Enquete.DateFermeture;
        }
    }
}
