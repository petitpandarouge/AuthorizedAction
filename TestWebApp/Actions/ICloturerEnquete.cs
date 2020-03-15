using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Models;

namespace TestWebApp.Actions
{
    public interface ICloturerEnquete
    {
        #region Methods

        void Execute(Enquete enquete);

        #endregion // Methods
    }
}
