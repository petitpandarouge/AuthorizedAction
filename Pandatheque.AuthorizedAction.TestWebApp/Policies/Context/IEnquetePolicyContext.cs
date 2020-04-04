using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pandatheque.AuthorizedAction.TestWebApp.Models;

namespace Pandatheque.AuthorizedAction.TestWebApp.Policies.Context
{
    public interface IEnquetePolicyContext : IPolicyContext
    {
        #region Properties

        Enquete Enquete { get; }

        #endregion // Properties
    }
}
