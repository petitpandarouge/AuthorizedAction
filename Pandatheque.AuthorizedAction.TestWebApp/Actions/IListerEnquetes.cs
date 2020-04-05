using Pandatheque.AuthorizedAction.TestWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.TestWebApp.Actions
{
    public interface IListerEnquetes
    {
        Task<ICollection<Enquete>> ExecuteAsync();
    }
}
