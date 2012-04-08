using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;
using FluentAssertions.Mvc3;
using FluentAssertions.Mvc3.Tests.Fakes;

namespace FluentAssertions.Mvc3.Tests
{
    [TestFixture]
    public class ViewResultAssertions_Tests
    {
        private FakeController _controller = new FakeController();

        [Test]
        public void WithMasterName_GivenExpectedValue_ShouldPass()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                MasterName = "master",
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            result.Should().BeView().WithMasterName("master");
        }

        [Test]
        public void WithMasterName_GivenUnexpectedValue_ShouldFail()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                MasterName = "master",
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            Action action = () => result.Should().BeView().WithMasterName("xyz");
            action.ShouldThrow<Exception>();
        }

        [Test]
        public void WithViewName_GivenExpectedValue_ShouldPass()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                ViewName = "index",
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            result.Should().BeView().WithViewName("index");
        }

        [Test]
        public void WithViewName_GivenUnexpectedValue_ShouldFail()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                ViewName = "index",
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            Action action = () => result.Should().BeView().WithViewName("xyz");
            action.ShouldThrow<Exception>();
        }

        [Test]
        public void WithTempData_GivenExpectedValue_ShouldPass()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                TempData = new TempDataDictionary {{ "key1", "value1" }}
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            result.Should().BeView().WithTempData("key1", "value1");
        }

        [Test]
        public void WithTempData_GivenTwoExpectedValues_ShouldPass()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                TempData = new TempDataDictionary
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                }
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            result.Should().BeView()
                    .WithTempData("key1", "value1")
                    .WithTempData("key2", "value2");
        }

        [Test]
        public void WithTempData_GivenUnexpectedValue_ShouldFail()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                TempData = new TempDataDictionary { { "key1", "value1" } }
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            Action a = () => result.Should().BeView().WithTempData("key1", "xyz");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void WithTempData_GivenUnexpectedKey_ShouldFail()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                TempData = new TempDataDictionary { { "key1", "value1" } }
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            Action a = () => result.Should().BeView().WithTempData("xyz", "value1");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void WithViewData_GivenExpectedValue_ShouldPass()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                ViewData = new ViewDataDictionary { { "key1", "value1" } }
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            result.Should().BeView().WithViewData("key1", "value1");
        }

        [Test]
        public void WithViewData_GivenTwoExpectedValues_ShouldPass()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                ViewData = new ViewDataDictionary
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                }
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            result.Should().BeView()
                    .WithViewData("key1", "value1")
                    .WithViewData("key2", "value2");
        }

        [Test]
        public void WithViewData_GivenUnexpectedValue_ShouldFail()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                ViewData = new ViewDataDictionary { { "key1", "value1" } }
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            Action a = () => result.Should().BeView().WithViewData("key1", "xyz");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void WithViewData_GivenUnexpectedKey_ShouldFail()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                ViewData = new ViewDataDictionary { { "key1", "value1" } }
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            Action a = () => result.Should().BeView().WithViewData("xyz", "value1");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void Model_GivenExpectedValue_ShouldPass()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            result.Should().BeView().Model.Should().Be("hello");
        }

        [Test]
        public void Model_GivenUnexpectedValue_ShouldFail()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            Action a = () => result.Should().BeView().Model.Should().Be("xyx");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void ModelAs_GivenExpectedValue_ShouldPass()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            result.Should().BeView().ModelAs<string>().Should().Be("hello");
        }

        [Test]
        public void ModelAs_GivenUnexpectedValue_ShouldFail()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            Action a = () => result.Should().BeView().ModelAs<string>().Should().Be("xyx");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void ModelAs_GivenWrongType_ShouldFail()
        {
            //ARRAGE
            _controller.IndexReturn = new ViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };

            //ACT
            ActionResult result = _controller.Index();

            //ASSERT
            result.Should().BeView().ModelAs<int>().Should().Be(2);
            Action a = () => result.Should().BeView().ModelAs<int>().Should().Be(2);
            a.ShouldThrow<Exception>();
        }
    }
}
