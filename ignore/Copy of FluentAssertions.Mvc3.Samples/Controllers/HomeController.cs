using System.Web.Mvc;
using FluentAssertions.Mvc3.Samples.Models;

namespace FluentAssertions.Mvc3.Samples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData["Message"] = "Welcome!";

            var model = new WelcomeModel
            {
                UserName = "Jonny Briggs",
                UserAge = 41
            };

            return View("Welcome", model);
        }
    }
}
