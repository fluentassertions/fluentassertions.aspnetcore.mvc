using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class TestController : Controller
    {
        private Mock<ITempDataDictionary> _mockTempDataDictionary;

        public TestController()
        {
            _mockTempDataDictionary = new Mock<ITempDataDictionary>();
            TempData = _mockTempDataDictionary.Object;
        }

        public PartialViewResult PartialViewSimpleModel(object model = null)
        {
            return PartialView(model: model ?? "hello");
        }

        public ViewResult ViewSimpleModel(object model = null)
        {
            return View(model: model ?? "hello");
        }

        public ActionResult ViewWithOneTempData()
        {
            var mock = new Mock<ITempDataDictionary>();
            mock.Setup(t => t.ContainsKey("key1")).Returns(true);
            object value1 = "value1";
            mock.Setup(t => t["key1"]).Returns(value1);
            mock.Setup(t => t.TryGetValue("key1", out value1)).Returns(true);
            TempData = mock.Object;
            return View();
        }

        public ActionResult PartialViewWithOneTempData()
        {
            var mock = new Mock<ITempDataDictionary>();
            mock.Setup(t => t.ContainsKey("key1")).Returns(true);
            object value1 = "value1";
            mock.Setup(t => t["key1"]).Returns(value1);
            mock.Setup(t => t.TryGetValue("key1", out value1)).Returns(true);
            TempData = mock.Object;
            return PartialView();
        }

        public ViewResult ViewWithTwoTempData()
        {
            var mock = new Mock<ITempDataDictionary>();
            mock.Setup(t => t.ContainsKey("key1")).Returns(true);
            mock.Setup(t => t.ContainsKey("key2")).Returns(true);
            mock.Setup(t => t["key1"]).Returns("value1");
            mock.Setup(t => t["key2"]).Returns("value2");

            TempData = mock.Object;
            return View();
        }

        public ActionResult ViewWithOneViewData()
        {
            ViewData.Add("key1", "value1");
            return View();
        }

        public ActionResult PartialViewWithOneViewData()
        {
            ViewData.Add("key1", "value1");
            return PartialView();
        }

        public ViewResult ViewWithTwoViewData()
        {
            ViewData["key1"] = "value1";
            ViewData["key2"] = "value2";
            return View();
        }

        public JsonResult JsonSimpleValue()
        {
            return Json(data: "hello");
        }
    }
}
