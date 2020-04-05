using Microsoft.AspNetCore.Mvc;
using Pandatheque.AuthorizedAction.TestWebApp.Actions;
using Pandatheque.AuthorizedAction.TestWebApp.Models;
using Pandatheque.AuthorizedAction.TestWebApp.Policies.Context;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

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

        public async Task<IActionResult> CloturerEnquete()
        {
            CloturerEnquetePolicyContext context = new CloturerEnquetePolicyContext
            {
                Utilisateur = Utilisateur.CreateAdmin(),
                Enquete = Enquete.Create()
            };

            IPolicyResult<ICloturerEnquete> result = await this.cloturerEnqueteChecker.CheckPoliciesAsync(context).ConfigureAwait(false);
            if (result.Allowed)
            {
                result.Action.Execute(context.Enquete, context.Utilisateur);
                return this.View(context.Enquete);
            }

            return this.View("Unauthorized");
        }

        public async Task<IActionResult> ListerEnquetes()
        {
            IPolicyResult<IListerEnquetes> result = await this.listerEnquetesChecker.CheckPoliciesAsync(new VoidPolicyContext()).ConfigureAwait(false);
            if (result.Allowed)
            {
                ICollection<Enquete> enquetes = await result.Action.ExecuteAsync();
                return this.View(enquetes);
            }

            return this.View("Unauthorized");
        }
    }
}
