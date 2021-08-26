using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class AcceptedAtRouteResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;
        private const string TestValue = "testValue";

        [Fact]
        public void WithRouteName_GivenExpectedRouteName_ShouldPass()
        {
            var expectedRouteName = "expectedRoute";
            var result = new AcceptedAtRouteResult(expectedRouteName, null, null);
            result.Should().BeAcceptedAtRouteResult().WithRouteName(expectedRouteName);
        }

        [Fact]
        public void WithRouteName_GivenUnexpectedRouteName_ShouldFail()
        {
            var result = new AcceptedAtRouteResult("someOtherRoute", null, null);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "AcceptedAtRouteResult.RouteName", "expectedRoute", "someOtherRoute");

            Action a = () => result.Should().BeAcceptedAtRouteResult().WithRouteName("expectedRoute", Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenKeyDoesntExist_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var routeValues = new { myKey = "MyValue" };
            var result = new AcceptedAtRouteResult(string.Empty, routeValues, null);
            var failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButKeyNotFound(
                "AcceptedAtRouteResult.RouteValues", "Val", expectedKey);

            Action a = () => result.Should().BeAcceptedAtRouteResult().WithRouteValue(expectedKey, "Val", Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenExpectedKeyValuePair_ShouldPass()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = expectedValue };

            var result = new AcceptedAtRouteResult(string.Empty, routeValues, null);

            result.Should().BeAcceptedAtRouteResult().WithRouteValue(expectedKey, expectedValue);
        }

        [Fact]
        public void HaveValue_GivenUnexpectedKeyValuePair_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = "someOtherValue" };
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY(
                "AcceptedAtRouteResult.RouteValues", expectedKey, expectedValue, "someOtherValue");
            var result = new AcceptedAtRouteResult(string.Empty, routeValues, null);

            Action a = () => result.Should().BeAcceptedAtRouteResult().WithRouteValue(expectedKey, expectedValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_GivenAcceptedAtRouteResult_ShouldHaveTheSameValue()
        {
            var result = new TestController().AcceptedAtRoute(string.Empty, null, TestValue);

            result.Should().BeAcceptedAtRouteResult().ValueAs<string>().Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().AcceptedAtRoute(string.Empty, null, TestValue);
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                "AcceptedAtRouteResult.Value", typeof(int), typeof(string));

            Action a = () => result.Should().BeAcceptedAtRouteResult().ValueAs<int>();

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new AcceptedAtRouteResult(string.Empty, null, null);
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "AcceptedAtRouteResult.Value", typeof(object));

            Action a = () => result.Should().BeAcceptedAtRouteResult().ValueAs<object>();

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
