using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Models
{
    public class Enquete
    {
        public DateTime DateOuverture { get; set; }

        public DateTime? DateCloture { get; set; }

        public DateTime DateFermeture { get; set; }

        public static Enquete Create()
        {
            return new Enquete
            {
                DateOuverture = new DateTime(2020, 3, 1),
                DateFermeture = new DateTime(2020, 3, 31)
            };
        }

        public void Cloturer()
        {
            this.DateCloture = DateTime.Now;
        }
    }
}
