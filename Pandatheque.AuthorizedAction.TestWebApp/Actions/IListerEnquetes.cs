using Pandatheque.AuthorizedAction.TestWebApp.Models;
using System.Collections.Generic;

namespace Pandatheque.AuthorizedAction.TestWebApp.Actions
{
    public interface IListerEnquetes
    {
        ICollection<Enquete> Execute();
    }
}
