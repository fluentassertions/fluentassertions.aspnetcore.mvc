using FluentAssertions.Mvc.Tests.Fakes;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class ViewResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;

        #region Public Methods

        [Fact]
        public void WithViewName_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new ViewResult {
                ViewName = "index",
            };

            result.Should().BeViewResult().WithViewName("index");
        }

        [Fact]
        public void WithViewName_GivenUnexpectedValue_ShouldFail()
        {
            var actualViewName = "index";
            var expectedViewName = "xyz";
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("ViewResult.ViewName", expectedViewName, actualViewName);
            ActionResult result = new ViewResult {
                ViewName = actualViewName,
            };

            Action action = () => result.Should().BeViewResult().WithViewName(expectedViewName, Reason, ReasonArgs);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithTempData_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().ViewWithOneTempData();

            result.Should().BeViewResult().WithTempData("key1", "value1");
        }

        [Fact]
        public void WithTempData_GivenNullTempData_ShouldFail()
        {
            var result = new ViewResult();
            var failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButFoundNull("ViewResult.TempData", "value1", "key1");

            Action a = () => result.Should().BeViewResult().WithTempData("key1", "value1", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithTempData_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().ViewWithOneTempData();

            Action a = () => result.Should().BeViewResult().WithTempData("key1", "xyz", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage("Expected ViewResult.TempData to contain value \"xyz\" at key \"key1\" because it is 10 but found \"value1\".");
        }

        [Fact]
        public void WithTempData_GivenUnexpectedKey_ShouldFail()
        {
            var result = new TestController().ViewWithOneTempData();
            var failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButKeyNotFound(
                    "ViewResult.TempData", "value1", "xyz");

            Action a = () => result.Should().BeViewResult().WithTempData("xyz", "value1", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithViewData_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().ViewWithOneViewData();

            result.Should().BeViewResult().WithViewData("key1", "value1");
        }

        [Fact]
        public void WithTempData_GivenNullViewData_ShouldFail()
        {
            var result = new ViewResult();

            Action a = () => result.Should().BeViewResult().WithViewData("key1", "value1", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage("Expected ViewResult.ViewData to contain value \"value1\" at key \"key1\" because it is 10, but it is <null>.");
        }

        [Fact]
        public void WithViewData_GivenUnexpectedValue_ShouldFail()
        {
            var key = "key1";
            var expectedValue = "abc";

            var result = new TestController().ViewWithOneViewData();

            Action a = () => result.Should().BeViewResult().WithViewData(key, expectedValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage("Expected ViewResult.ViewData to contain value \"abc\" at key \"key1\" because it is 10 but found \"value1\".");
        }

        [Fact]
        public void WithViewData_GivenUnexpectedKey_ShouldFail()
        {
            var expectedKey = "xyz";

            var result = new TestController().ViewWithTwoViewData();

            Action a = () => result.Should().BeViewResult().WithViewData(expectedKey, "value1", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage("Expected ViewResult.ViewData to contain value \"value1\" at key \"xyz\" because it is 10, but the key was not found.");
        }

        [Fact]
        public void Model_ShouldReturnSameModelAsViewResult()
        {
            var model = new object();
            var result = new TestController().ViewSimpleModel(model);

            result.Should().BeViewResult().Model.Should().BeSameAs(model);
        }

        [Fact]
        public void ModelAs_CastingRight_ShouldPass()
        {
            var result = new TestController().ViewSimpleModel();

            result.Should().BeViewResult().ModelAs<string>().Should().Be("hello");
        }

        [Fact]
        public void ModelAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().ViewSimpleModel();

            Action a = () => result.Should().BeViewResult().ModelAs<int>().Should().Be(2);
            a.Should().Throw<Exception>()
                .WithMessage("Expected ViewResult.Model to be of type System.Int32 but was System.String.");
        }

        [Fact]
        public void ModelAs_Null_ShouldFail()
        {
            ActionResult result = new ViewResult();
            string failureMessage = "Expected ViewResult.Model to be of type System.Object, but no value was supplied."; ;

            Action a = () => result.Should().BeViewResult().ModelAs<Object>();

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithDefaultViewName_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new ViewResult {
                ViewName = String.Empty
            };

            result.Should().BeViewResult().WithDefaultViewName();
        }

        [Fact]
        public void WithDefaultViewName_GivenUnexpectedValue_ShouldFail()
        {
            string viewName = "Something";
            var failureMessage = "Expected default view because it is 10, but view \"Something\" was rendered.";

            ActionResult result = new ViewResult {
                ViewName = viewName
            };

            Action action = () => result.Should().BeViewResult().WithDefaultViewName("it is 10");

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        #endregion Public Methods
    }
}