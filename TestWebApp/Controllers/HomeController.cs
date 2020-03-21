using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TestWebApp.Actions;
using TestWebApp.AuthorizationAction;
using TestWebApp.Models;
using TestWebApp.Policies.Context;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IAuthorizedActionChecker<CloturerEnquetePolicyContext, ICloturerEnquete> cloturerEnqueteChecker;

        public HomeController(ILogger<HomeController> logger, IAuthorizedActionChecker<CloturerEnquetePolicyContext, ICloturerEnquete> cloturerEnqueteChecker)
        {
            this.logger = logger;
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
                Utilisateur = Utilisateur.CreateAdmin()
            };

            Enquete enquete = Enquete.Create();

            IPolicyResult<ICloturerEnquete> result = this.cloturerEnqueteChecker.CheckPolicies(context);
            if (result.Allowed)
            {
                result.Action.Execute(enquete, context.Utilisateur);
                return this.View(enquete);
            }

            return this.View("Unauthorized");
        }
    }
}
