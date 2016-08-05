using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAssertions.Mvc.Tests
{
    public class TestController : Controller
    {
        public TestController()
        {
            TempData = new Mock<ITempDataDictionary>().Object;
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
            TempData.Add("key1", "value1");
            return View();
        }

        public ViewResult ViewWithTwoTempData()
        {
            TempData.Add("key1", "value1");
            TempData.Add("key2", "value2");
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
