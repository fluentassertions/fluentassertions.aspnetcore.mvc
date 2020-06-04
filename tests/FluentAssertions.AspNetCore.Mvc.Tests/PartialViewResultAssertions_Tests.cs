using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class PartialViewResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;

        [Fact]
        public void WithDefaultViewName_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new PartialViewResult
            {
                ViewName = String.Empty
            };

            result.Should().BePartialViewResult().WithDefaultViewName();
        }

        [Fact]
        public void WithDefaultViewName_GivenUnexpectedValue_ShouldFail()
        {
            ActionResult result = new PartialViewResult
            {
                ViewName = "Something"
            };
            var failureMessage = "Expected default view because it is 10, but view \"Something\" was rendered.";

            Action action = () => result.Should().BePartialViewResult().WithDefaultViewName(Reason, ReasonArgs);

            action.Should()
                .Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void Model_ShouldReturnSameModelAsPartialViewResult()
        {
            var model = new object();
            var result = new TestController().PartialViewSimpleModel(model);

            result.Should().BePartialViewResult().Model.Should().BeSameAs(model);
        }

        [Fact]
        public void ModelAs_CastingRight_ShouldPass()
        {
            var result = new TestController().PartialViewSimpleModel();

            result.Should().BePartialViewResult().ModelAs<string>().Should().Be("hello");
        }

        [Fact]
        public void ModelAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().PartialViewSimpleModel();

            Action a = () => AssertionsExtensions.Should(result).BePartialViewResult().ModelAs<int>().Should().Be(2);

            a.Should().Throw<Exception>()
                .WithMessage("Expected PartialViewResult.Model to be of type System.Int32 but was System.String.");
        }

        [Fact]
        public void ModelAs_Null_ShouldFail()
        {
            ActionResult result = new PartialViewResult();
            const string failureMessage = "Expected PartialViewResult.Model to be of type System.Object, but no value was supplied.";

            Action a = () => AssertionsExtensions.Should(result).BePartialViewResult().ModelAs<Object>();

            a.Should().Throw<Exception>()
                    .WithMessage(failureMessage);
        }

        [Fact]
        public void WithViewName_GivenExpectedValue_ShouldPass()
        {
            var expected = "Expected";
            ActionResult result = new PartialViewResult {
                ViewName = expected
            };

            result.Should().BePartialViewResult().WithViewName(expected);
        }

        [Fact]
        public void WithViewName_GivenUnexpectedValue_ShouldFail()
        {
            var actual = "Unexpected";
            var expected = "Expected";
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("PartialViewResult.ViewName", expected, actual);
            ActionResult result = new PartialViewResult
            {
                ViewName = actual
            };

            Action action = () => result.Should().BePartialViewResult().WithViewName(expected, Reason, ReasonArgs);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithTempData_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().PartialViewWithOneTempData();

            result.Should().BePartialViewResult().WithTempData("key1", "value1");
        }

        [Fact]
        public void WithTempData_GivenNullTempData_ShouldFail()
        {
            var result = new PartialViewResult();

            Action a = () => result.Should().BePartialViewResult().WithTempData("key1", "value1", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage("Expected PartialViewResult.TempData to contain value \"value1\" at key \"key1\" because it is 10, but it is <null>."); ;
        }

        [Fact]
        public void WithTempData_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().PartialViewWithOneTempData();

            Action a = () => result.Should().BePartialViewResult().WithTempData("key1", "xyz", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage("Expected PartialViewResult.TempData to contain value \"xyz\" at key \"key1\" because it is 10 but found \"value1\".");
        }

        [Fact]
        public void WithTempData_GivenUnexpectedKey_ShouldFail()
        {
            var result = new TestController().PartialViewWithOneTempData();

            Action a = () => result.Should().BePartialViewResult().WithTempData("xyz", "value1", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage("Expected PartialViewResult.TempData to contain value \"value1\" at key \"xyz\" because it is 10, but the key was not found."); ;
        }

        [Fact]
        public void WithViewData_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().PartialViewWithOneViewData();

            result.Should().BePartialViewResult().WithViewData("key1", "value1");
        }

        [Fact]
        public void WithViewData_GivenNullViewData_ShouldFail()
        {
            var result = new PartialViewResult();

            Action a = () => result.Should().BePartialViewResult().WithViewData("key1", "value1", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage("Expected PartialViewResult.ViewData to contain value \"value1\" at key \"key1\" because it is 10, but it is <null>.");
        }

        [Fact]
        public void WithViewData_GivenUnexpectedValue_ShouldFail()
        {
            var key = "key1";
            var expectedValue = "abc";

            var result = new TestController().PartialViewWithOneViewData();

            Action a = () => result.Should().BePartialViewResult().WithViewData(key, expectedValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage("Expected PartialViewResult.ViewData to contain value \"abc\" at key \"key1\" because it is 10 but found \"value1\".");
        }

        [Fact]
        public void WithViewData_GivenUnexpectedKey_ShouldFail()
        {
            var expectedKey = "xyz";

            var result = new TestController().PartialViewWithOneViewData();

            Action a = () => result.Should().BePartialViewResult().WithViewData(expectedKey, "value1", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage("Expected PartialViewResult.ViewData to contain value \"value1\" at key \"xyz\" because it is 10, but the key was not found.");
        }

    }
}
