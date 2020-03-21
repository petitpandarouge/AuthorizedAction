using TestWebApp.Models;

namespace TestWebApp.Actions
{
    public interface ICloturerEnquete
    {
        #region Methods

        void Execute(Enquete enquete, Utilisateur utilisateur);

        #endregion // Methods
    }
}
