﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Models;

namespace TestWebApp.Actions
{
    public abstract class ACloturerEnquete : ICloturerEnquete
    {
        public void Execute(Enquete enquete)
        {
            this.LogProfile();
            enquete.Cloturer();
        }

        protected abstract void LogProfile();
    }
}
