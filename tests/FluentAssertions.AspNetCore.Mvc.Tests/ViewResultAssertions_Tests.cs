using System;
using FluentAssertions.Mvc.Tests.Fakes;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    [TestFixture]
    public class ViewResultAssertions_Tests
    {
        private FakeController _controller = new FakeController();

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
            var result = new TestController().ViewWithOneTempData();

            result.Should().BeViewResult().WithTempData("key1", "value1");
        }

        [Test]
        public void WithTempData_GivenTwoExpectedValues_ShouldPass()
        {
            var result = new TestController().ViewWithTwoTempData();

            result.Should().BeViewResult()
                .WithTempData("key1", "value1")
                .WithTempData("key2", "value2");
        }

        [Test]
        public void WithTempData_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().ViewWithOneTempData();

            Action a = () => result.Should().BeViewResult().WithTempData("key1", "xyz");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void WithTempData_GivenUnexpectedKey_ShouldFail()
        {
            var result = new TestController().ViewWithOneTempData();

            Action a = () => result.Should().BeViewResult().WithTempData("xyz", "value1");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void WithViewData_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().ViewWithOneViewData();

            result.Should().BeViewResult().WithViewData("key1", "value1");
        }

        [Test]
        public void WithViewData_GivenTwoExpectedValues_ShouldPass()
        {
            var result = new TestController().ViewWithTwoViewData();

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

            var result = new TestController().ViewWithOneViewData();

            Action a = () => result.Should().BeViewResult().WithViewData(key, expectedValue);

            a.ShouldThrow<Exception>()
                .WithMessage(failureMessage);
        }

        [Test]
        public void WithViewData_GivenUnexpectedKey_ShouldFail()
        {
            var actualKey = "key1";
            var expectedKey = "xyz";

            var result = new TestController().ViewWithTwoViewData();

            var failureMessage = FailureMessageHelper.Format(FailureMessages.ViewResultBase_ViewData_ContainsKey, expectedKey, actualKey);

            Action a = () => result.Should().BeViewResult().WithViewData(expectedKey, "value1");

            a.ShouldThrow<Exception>()
                .WithMessage(failureMessage);
        }

        [Test]
        public void Model_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().ViewSimpleModel();

            result.Should().BeViewResult().Model.Should().Be("hello");
        }

        [Test]
        public void Model_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().ViewSimpleModel();

            Action a = () => result.Should().BeViewResult().Model.Should().Be("xyx");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void ModelAs_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().ViewSimpleModel();

            result.Should().BeViewResult().ModelAs<string>().Should().Be("hello");
        }

        [Test]
        public void ModelAs_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().ViewSimpleModel();

            Action a = () => result.Should().BeViewResult().ModelAs<string>().Should().Be("xyx");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void ModelAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().ViewSimpleModel();

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
