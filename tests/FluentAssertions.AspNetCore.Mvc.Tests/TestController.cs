using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;

namespace FluentAssertions.Mvc.Tests
{
    public class TestController : Controller
    {
        private Mock<ITempDataDictionary> _mockTempDataDictionary;

        public TestController()
        {
            _mockTempDataDictionary = new Mock<ITempDataDictionary>();
            TempData = _mockTempDataDictionary.Object;
        }

        public PartialViewResult PartialViewSimpleModel()
        {
            return PartialView(model: "hello");
        }

        public ViewResult ViewSimpleModel()
        {
            return View(model: "hello");
        }

        public ViewResult ViewWithOneTempData()
        {
            var mock = new Mock<ITempDataDictionary>();
            mock.Setup(t => t.ContainsKey("key1")).Returns(true);
            mock.Setup(t => t["key1"]).Returns("value1");
            TempData = mock.Object;
            return View();
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

        public ViewResult ViewWithOneViewData()
        {
            ViewData.Add("key1", "value1");
            return View();
        }

        public ViewResult ViewWithTwoViewData()
        {
            ViewData["key1"] = "value1";
            ViewData["key2"] = "value2";
            return View();
        }
    }
}
