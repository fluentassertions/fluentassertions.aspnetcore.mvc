using System.Web.Mvc;

namespace FluentAssertions.Mvc3.Samples.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult List()
        {
            return View("Index");
        }
    }
}
