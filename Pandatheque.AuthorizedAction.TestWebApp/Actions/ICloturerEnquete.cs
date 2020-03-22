using Pandatheque.AuthorizedAction.TestWebApp.Models;

namespace Pandatheque.AuthorizedAction.TestWebApp.Actions
{
    public interface ICloturerEnquete
    {
        #region Methods

        void Execute(Enquete enquete, Utilisateur utilisateur);

        #endregion // Methods
    }
}
