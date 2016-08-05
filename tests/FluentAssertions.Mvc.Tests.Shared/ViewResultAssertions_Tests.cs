using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions.Mvc;
using FluentAssertions.Mvc.Tests.Fakes;
using FluentAssertions.Mvc.Tests.Helpers;
using NUnit.Framework;

#if NETCOREAPP1_0
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
#else
using System.Web.Mvc;
#endif

namespace FluentAssertions.Mvc.Tests
{
    [TestFixture]
    public class ViewResultAssertions_Tests
    {
        private FakeController _controller = new FakeController();

#if !NETCOREAPP1_0
        [Test]
        public void WithMasterName_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new ViewResult
            {
                MasterName = "master",
            };

            result.Should().BeViewResult().WithMasterName("master");
        }

        [Test]
        public void WithMasterName_GivenUnexpectedValue_ShouldFail()
        {
            var actualMasterName = "master";
            var expectedMasterName = "xyz";
            ActionResult result = new ViewResult
            {
                MasterName = actualMasterName,
            };
            var failureMessage = FailureMessageHelper.Format(FailureMessages.ViewResult_MasterName, expectedMasterName, actualMasterName);

            Action action = () => result.Should().BeViewResult().WithMasterName(expectedMasterName);

            action.ShouldThrow<Exception>()
                    .WithMessage(failureMessage);
        }
#endif

        [Test]
        public void WithViewName_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new ViewResult
            {
                ViewName = "index",
            };

            result.Should().BeViewResult().WithViewName("index");
        }

        [Test]
        public void WithViewName_GivenUnexpectedValue_ShouldFail()
        {
            var actualViewName = "index";
            var expectedViewName = "xyz";
            var failureMessage = FailureMessageHelper.Format(FailureMessages.ViewResultBase_ViewName, expectedViewName, actualViewName);
            ActionResult result = new ViewResult
            {
                ViewName = actualViewName,
            };

            Action action = () => result.Should().BeViewResult().WithViewName(expectedViewName);
            
            action.ShouldThrow<Exception>()
                    .WithMessage(failureMessage);
        }

        [Test]
        public void WithTempData_GivenExpectedValue_ShouldPass()
        {
#if NETCOREAPP1_0
            var result = new ViewResult();
            result.TempData.Add("key1", "value1");
#else
            ActionResult result = new ViewResult
            {
                TempData = new TempDataDictionary { { "key1", "value1" } }
            };
#endif

            result.Should().BeViewResult().WithTempData("key1", "value1");
        }

        [Test]
        public void WithTempData_GivenTwoExpectedValues_ShouldPass()
        {
#if NETCOREAPP1_0
            var result = new ViewResult();
            result.TempData.Add("key1", "value1");
            result.TempData.Add("key2", "value2");
#else
            ActionResult result = new ViewResult
            {
                TempData = new TempDataDictionary
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                }
            };
#endif

            result.Should().BeViewResult()
                    .WithTempData("key1", "value1")
                    .WithTempData("key2", "value2");
        }

        [Test]
        public void WithTempData_GivenUnexpectedValue_ShouldFail()
        {
#if NETCOREAPP1_0
            var result = new ViewResult();
            result.TempData.Add("key1", "value1");
#else
            ActionResult result = new ViewResult
            {
                TempData = new TempDataDictionary { { "key1", "value1" } }
            };
#endif

            Action a = () => result.Should().BeViewResult().WithTempData("key1", "xyz");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void WithTempData_GivenUnexpectedKey_ShouldFail()
        {
#if NETCOREAPP1_0
            var result = new ViewResult();
            result.TempData.Add("key1", "value1");
#else
            ActionResult result = new ViewResult
            {
                TempData = new TempDataDictionary { { "key1", "value1" } }
            };
#endif

            Action a = () => result.Should().BeViewResult().WithTempData("xyz", "value1");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void WithViewData_GivenExpectedValue_ShouldPass()
        {
#if NETCOREAPP1_0
            var result = new ViewResult();
            result.TempData.Add("key1", "value1");
#else
            ActionResult result = new ViewResult
            {
                TempData = new TempDataDictionary { { "key1", "value1" } }
            };
#endif

            result.Should().BeViewResult().WithViewData("key1", "value1");
        }

        [Test]
        public void WithViewData_GivenTwoExpectedValues_ShouldPass()
        {
#if NETCOREAPP1_0
            var result = new ViewResult();
            result.ViewData.Add("key1", "value1");
            result.ViewData.Add("key2", "value2");
#else
            ActionResult result = new ViewResult
            {
                ViewData = new ViewDataDictionary
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                }
            };
#endif

            result.Should().BeViewResult()
                    .WithViewData("key1", "value1")
                    .WithViewData("key2", "value2");
        }

        [Test]
        public void WithViewData_GivenUnexpectedValue_ShouldFail()
        {
            var key = "key1";
            var actualValue = "value1";
            var expectedValue = "abc";
            var failureMessage = FailureMessageHelper.Format(FailureMessages.ViewResultBase_ViewData_HaveValue, key, expectedValue, actualValue);

#if NETCOREAPP1_0
            var result = new ViewResult();
            result.ViewData.Add(key, actualValue);
#else
            ActionResult result = new ViewResult
            {
                ViewData = new ViewDataDictionary { { key, actualValue } }
            };
#endif

            Action a = () => result.Should().BeViewResult().WithViewData(key, expectedValue);

            a.ShouldThrow<Exception>()
                    .WithMessage(failureMessage);
        }

        [Test]
        public void WithViewData_GivenUnexpectedKey_ShouldFail()
        {
            var actualKey = "key1";
            var expectedKey = "xyz";

#if NETCOREAPP1_0
            var result = new ViewResult();
            result.ViewData.Add(actualKey, "value1");
#else
            ActionResult result = new ViewResult
            {
                ViewData = new ViewDataDictionary { { actualKey, "value1" } }
            };
#endif
            var failureMessage = FailureMessageHelper.Format(FailureMessages.ViewResultBase_ViewData_ContainsKey, expectedKey, actualKey);

            Action a = () => result.Should().BeViewResult().WithViewData(expectedKey, "value1");

            a.ShouldThrow<Exception>()
                    .WithMessage(failureMessage);
        }

        [Test]
        public void Model_GivenExpectedValue_ShouldPass()
        {
#if NETCOREAPP1_0
            var result = new ViewResult();
            result.ViewData.Model = "hello";
#else
            ActionResult result = new ViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };
#endif

            result.Should().BeViewResult().Model.Should().Be("hello");
        }
        
        [Test]
        public void Model_GivenUnexpectedValue_ShouldFail()
        {
#if NETCOREAPP1_0
            var result = new ViewResult();
            result.ViewData.Model = "hello";
#else
            ActionResult result = new ViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };
#endif

            Action a = () => result.Should().BeViewResult().Model.Should().Be("xyx");
            a.ShouldThrow<Exception>();
        }
        
        [Test]
        public void ModelAs_GivenExpectedValue_ShouldPass()
        {
#if NETCOREAPP1_0
            var result = new ViewResult();
            result.ViewData.Model = "hello";
#else
            ActionResult result = new ViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };
#endif

            result.Should().BeViewResult().ModelAs<string>().Should().Be("hello");
        }

        [Test]
        public void ModelAs_GivenUnexpectedValue_ShouldFail()
        {
#if NETCOREAPP1_0
            var result = new ViewResult();
            result.ViewData.Model = "hello";
#else
            ActionResult result = new ViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };
#endif

            Action a = () => result.Should().BeViewResult().ModelAs<string>().Should().Be("xyx");
            a.ShouldThrow<Exception>();
        }
        
        [Test]
        public void ModelAs_GivenWrongType_ShouldFail()
        {
#if NETCOREAPP1_0
            var result = new ViewResult();
            result.ViewData.Model = "hello";
#else
            ActionResult result = new ViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };
#endif

            Action a = () => result.Should().BeViewResult().ModelAs<int>().Should().Be(2);
            a.ShouldThrow<Exception>();
        }
        
        [Test]
        public void ModelAs_Null_ShouldFail()
        {
            ActionResult result = new ViewResult();
            string failureMessage = FailureMessageHelper.Format(FailureMessages.ViewResultBase_NullModel, typeof(Object).Name);

            Action a = () => result.Should().BeViewResult().ModelAs<Object>();
            
            a.ShouldThrow<Exception>()
                    .WithMessage(failureMessage);
        }
        
        [Test]
        public void WithDefaultViewName_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new ViewResult
            {
                ViewName = String.Empty
            };

            result.Should().BeViewResult().WithDefaultViewName();
        }

        [Test]
        public void WithDefaultViewName_GivenUnexpectedValue_ShouldFail()
        {
            string viewName = "index";
            string failureMessage = FailureMessageHelper.Format(FailureMessages.ViewResultBase_WithDefaultViewName, viewName);

            ActionResult result = new ViewResult
            {
                ViewName = viewName
            };

            Action action = () => result.Should().BeViewResult().WithDefaultViewName();

            action.ShouldThrow<Exception>()
                    .WithMessage(failureMessage);
        }
    }
}
