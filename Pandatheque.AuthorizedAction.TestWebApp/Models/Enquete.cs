using System;

namespace Pandatheque.AuthorizedAction.TestWebApp.Models
{
    public class Enquete
    {
        public int Id { get; set; }

        public DateTime DateOuverture { get; set; }

        public DateTime? DateCloture { get; set; }

        public DateTime DateFermeture { get; set; }

        public Utilisateur UtilisateurModification { get; set; }

        public bool CanCloture { get; set; } = false;

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
