using Microsoft.AspNetCore.Mvc;
using Pandatheque.AuthorizedAction;
using System.Diagnostics;
using TestWebApp.Actions;
using TestWebApp.Models;
using TestWebApp.Policies.Context;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorizedActionChecker<CloturerEnquetePolicyContext, ICloturerEnquete> cloturerEnqueteChecker;

        public HomeController(IAuthorizedActionChecker<CloturerEnquetePolicyContext, ICloturerEnquete> cloturerEnqueteChecker)
        {
            this.cloturerEnqueteChecker = cloturerEnqueteChecker;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CloturerEnquete()
        {
            CloturerEnquetePolicyContext context = new CloturerEnquetePolicyContext
            {
                Utilisateur = Utilisateur.CreateAdmin(),
                Enquete = Enquete.Create()
            };

            IPolicyResult<ICloturerEnquete> result = this.cloturerEnqueteChecker.CheckPolicies(context);
            if (result.Allowed)
            {
                result.Action.Execute(context.Enquete, context.Utilisateur);
                return this.View(context.Enquete);
            }

            return this.View("Unauthorized");
        }
    }
}
