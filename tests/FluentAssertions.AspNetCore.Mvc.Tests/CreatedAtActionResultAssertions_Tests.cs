using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    
    public class CreatedAtActionResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;
        private const string TestValue = "testValue";

        [Fact]
        public void WithActionName_GivenExpectedActionName_ShouldPass()
        {
            var expectedActionName = "expectedAction";
            var result = new CreatedAtActionResult(expectedActionName, string.Empty, null, null);

            result.Should().BeCreatedAtActionResult().WithActionName(expectedActionName);
        }

        [Fact]
        public void WithActionName_GivenUnexpectedActionName_ShouldFail()
        {
            var result = new CreatedAtActionResult("someOtherAction", string.Empty, null, null);
            string failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "CreatedAtActionResult.ActionName", "expectedAction", "someOtherAction");

            Action a = () => result.Should().BeCreatedAtActionResult().WithActionName("expectedAction", Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(
                failureMessage);
        }

        [Fact]
        public void WithControllerName_GivenExpectedControllerName_ShouldPass()
        {
            var expectedControllerName = "expectedController";
            var result = new CreatedAtActionResult(string.Empty, expectedControllerName, null, null);

            result.Should().BeCreatedAtActionResult().WithControllerName(expectedControllerName);
        }

        [Fact]
        public void WithControllerName_GivenUnexpectedControllerName_ShouldFail()
        {
            var result = new CreatedAtActionResult(string.Empty, "someOtherController", null, null);
            string failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "CreatedAtActionResult.ControllerName", "expectedController", "someOtherController");

            Action a = () => result.Should().BeCreatedAtActionResult().WithControllerName("expectedController", Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenKeyDoesntExist_ShouldFail()
        {
            var expectedKey = "expectedKey";

            var routeValues = new {myKey = "MyValue"};
            var result = new CreatedAtActionResult(string.Empty, string.Empty, routeValues, null);
            string failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButKeyNotFound(
                "CreatedAtActionResult.RouteValues", "Val", expectedKey);

            Action a = () => result.Should().BeCreatedAtActionResult().WithRouteValue(expectedKey, "Val", Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenExpectedKeyValuePair_ShouldPass()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new {expectedKey = expectedValue};
            var result = new CreatedAtActionResult(string.Empty, string.Empty, routeValues, null);

            result.Should().BeCreatedAtActionResult().WithRouteValue(expectedKey, expectedValue);
        }

        [Fact]
        public void WithRouteValue_GivenUnexpectedValue_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = "someOtherValue" };
            var result = new CreatedAtActionResult(string.Empty, string.Empty, routeValues, null);
            string failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY(
                "CreatedAtActionResult.RouteValues", expectedKey, expectedValue, "someOtherValue");

            Action a = () => result.Should().BeCreatedAtActionResult().WithRouteValue(expectedKey, expectedValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().CreatedAtAction(string.Empty, string.Empty, null, TestValue);
            result.Should().BeCreatedAtActionResult().ValueAs<string>().Should().Be(TestValue);
        }

        [Fact]
        public void ValueAs_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().CreatedAtAction(string.Empty, string.Empty, null, TestValue);
            Action a = () => result.Should().BeCreatedAtActionResult().ValueAs<string>().Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().CreatedAtAction(string.Empty, string.Empty, null, TestValue);
            Action a = () => result.Should().BeCreatedAtActionResult().ValueAs<int>().Should().Be(2);
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new CreatedAtActionResult(string.Empty, string.Empty, null, null);
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull("CreatedAtActionResult.Value", typeof(object).FullName);

            Action a = () => result.Should().BeCreatedAtActionResult().ValueAs<object>();

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
