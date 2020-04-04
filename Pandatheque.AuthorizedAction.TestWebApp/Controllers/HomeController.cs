using Microsoft.AspNetCore.Mvc;
using Pandatheque.AuthorizedAction.TestWebApp.Actions;
using Pandatheque.AuthorizedAction.TestWebApp.Models;
using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pandatheque.AuthorizedAction.TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorizedActionChecker<CloturerEnquetePolicyContext, ICloturerEnquete> cloturerEnqueteChecker;
        private readonly IAuthorizedActionChecker<VoidPolicyContext, IListerEnquetes> listerEnquetesChecker;

        public HomeController(
            IAuthorizedActionChecker<CloturerEnquetePolicyContext, ICloturerEnquete> cloturerEnqueteChecker,
            IAuthorizedActionChecker<VoidPolicyContext, IListerEnquetes> listerEnquetesChecker)
        {
            this.cloturerEnqueteChecker = cloturerEnqueteChecker;
            this.listerEnquetesChecker = listerEnquetesChecker;
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

        public IActionResult ListerEnquetes()
        {
            IPolicyResult<IListerEnquetes> result = this.listerEnquetesChecker.CheckPolicies(new VoidPolicyContext());
            if (result.Allowed)
            {
                ICollection<Enquete> enquetes = result.Action.Execute();
                return this.View(enquetes);
            }

            return this.View("Unauthorized");
        }
    }
}
