﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Actions
{
    public class CloturerEnqueteModification : ACloturerEnquete
    {
        protected override void LogProfile()
        {
            Console.WriteLine("Modification cloture enquète.");
        }
    }
}