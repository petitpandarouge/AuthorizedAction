﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.TestWebApp.Models
{
    public class Enquete
    {
        public DateTime DateOuverture { get; set; }

        public DateTime? DateCloture { get; set; }

        public DateTime DateFermeture { get; set; }

        public Utilisateur UtilisateurModification { get; set; }

        public static Enquete Create()
        {
            return new Enquete
            {
                DateOuverture = new DateTime(2020, 3, 1),
                DateFermeture = new DateTime(2020, 3, 31)
            };
        }

        public void Cloturer(Utilisateur utilisateur)
        {
            this.DateCloture = DateTime.Now;
            this.UtilisateurModification = utilisateur;
        }
    }
}