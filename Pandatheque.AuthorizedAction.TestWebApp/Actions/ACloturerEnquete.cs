using Pandatheque.AuthorizedAction.TestWebApp.Models;

namespace Pandatheque.AuthorizedAction.TestWebApp.Actions
{
    public abstract class ACloturerEnquete : ICloturerEnquete
    {
        public void Execute(Enquete enquete, Utilisateur utilisateur)
        {
            enquete.Cloturer(utilisateur);
        }
    }
}
