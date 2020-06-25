using FluentAssertions.AspNetCore.Mvc.Sample.Models;
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

        #region ActionResult<T>
        [HttpGet]
        public ActionResult<ProductViewModel> GetActionResultOfT(
            ProductViewModel data, bool error)
        {
            if (error)
            {
                return BadRequest(data);
            }
            return data;
        }
        #endregion
    }
}
