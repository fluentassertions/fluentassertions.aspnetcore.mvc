using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class AcceptedAtActionResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;
        private const string TestValue = "testValue";

        [Fact]
        public void WithActionName_GivenExpectedActionName_ShouldPass()
        {
            var expectedActionName = "expectedAction";
            var result = new AcceptedAtActionResult(expectedActionName, string.Empty, null, null);

            result.Should().BeAcceptedAtActionResult().WithActionName(expectedActionName);
        }

        [Fact]
        public void WithActionName_GivenUnexpectedActionName_ShouldFail()
        {
            var result = new AcceptedAtActionResult("someOtherAction", string.Empty, null, null);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "AcceptedAtActionResult.ActionName", "expectedAction", "someOtherAction");

            Action a = () => result.Should().BeAcceptedAtActionResult().WithActionName("expectedAction", Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithControllerName_GivenExpectedControllerName_ShouldPass()
        {
            var expectedControllerName = "expectedController";
            var result = new AcceptedAtActionResult(string.Empty, expectedControllerName, null, null);

            result.Should().BeAcceptedAtActionResult().WithControllerName(expectedControllerName);
        }

        [Fact]
        public void WithControllerName_GivenUnexpectedControllerName_ShouldFail()
        {
            var result = new AcceptedAtActionResult(string.Empty, "someOtherController", null, null);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "AcceptedAtActionResult.ControllerName", "expectedController", "someOtherController");

            Action a = () => result.Should().BeAcceptedAtActionResult().WithControllerName("expectedController", Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenExpectedKeyValuePair_ShouldPass()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = expectedValue };
            var result = new AcceptedAtActionResult(string.Empty, string.Empty, routeValues, null);

            result.Should().BeAcceptedAtActionResult().WithRouteValue(expectedKey, expectedValue);
        }

        [Fact]
        public void WithRouteValue_GivenKeyDoesntExist_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButKeyNotFound
                ("AcceptedAtActionResult.RouteValues", "MyValue", expectedKey);
            var routeValues = new { myKey = "MyValue" };
            var result = new AcceptedAtActionResult(string.Empty, string.Empty, routeValues, null);

            Action a = () => result.Should().BeAcceptedAtActionResult().WithRouteValue(expectedKey, "MyValue", Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenUnexpectedKeyValuePair_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = "someOtherValue" };
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY(
                "AcceptedAtActionResult.RouteValues", expectedKey, expectedValue, "someOtherValue");
            var result = new AcceptedAtActionResult(string.Empty, string.Empty, routeValues, null);

            Action a = () => result.Should().BeAcceptedAtActionResult().WithRouteValue(expectedKey, expectedValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_GivenAcceptedAtActionResult_ShouldHaveTheSameValue()
        {
            var result = new TestController().AcceptedAtAction(string.Empty, string.Empty, null, TestValue);
            result.Should().BeAcceptedAtActionResult().ValueAs<string>().Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().AcceptedAtAction(string.Empty, string.Empty, null, TestValue);
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                "AcceptedAtActionResult.Value", typeof(int), typeof(string));

            Action a = () => result.Should().BeAcceptedAtActionResult().ValueAs<int>();

            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new AcceptedAtActionResult(string.Empty, string.Empty, null, null);
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "AcceptedAtActionResult.Value", typeof(object));

            Action a = () => result.Should().BeAcceptedAtActionResult().ValueAs<object>();

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
