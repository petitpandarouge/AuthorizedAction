using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Models;

namespace TestWebApp.Policies.Context
{
    public interface IEnquetePolicyContext
    {
        #region Properties

        Enquete Enquete { get; }

        #endregion // Properties
    }
}
