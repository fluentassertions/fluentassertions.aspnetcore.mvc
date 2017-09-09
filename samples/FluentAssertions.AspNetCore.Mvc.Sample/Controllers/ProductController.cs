using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.AspNetCore.Mvc.Sample.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult List()
        {
            return View("Index");
        }
    }
}
