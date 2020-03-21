using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Models
{
    public class Utilisateur
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public Profile Profile { get; set; }

        public static Utilisateur CreateAdmin()
        {
            return new Utilisateur
            {
                Nom = "Porté",
                Prenom = "Damien",
                Profile = Profile.Administrateur
            };
        }
    }
}
