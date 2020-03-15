using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Actions
{
    public class CloturerEnqueteAdmin : ACloturerEnquete
    {
        protected override void LogProfile()
        {
            Console.WriteLine("Admin cloture enquète.");
        }
    }
}
