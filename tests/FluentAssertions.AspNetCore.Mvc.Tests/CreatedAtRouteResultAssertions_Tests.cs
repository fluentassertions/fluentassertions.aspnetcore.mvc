using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class CreatedAtRouteResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;
        private const string TestValue = "testValue";

        [Fact]
        public void WithRouteName_GivenExpectedRouteName_ShouldPass()
        {
            var expectedRouteName = "expectedRoute";
            var result = new CreatedAtRouteResult(expectedRouteName, null, null);
            result.Should().BeCreatedAtRouteResult().WithRouteName(expectedRouteName);
        }

        [Fact]
        public void WithRouteName_GivenUnexpectedRouteName_ShouldFail()
        {
            var result = new CreatedAtRouteResult("someOtherRoute", null, null);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("CreatedAtRouteResult.RouteName", "expectedRoute", "someOtherRoute");

            Action a = () => result.Should().BeCreatedAtRouteResult().WithRouteName("expectedRoute", Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenKeyDoesntExist_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var routeValues = new { myKey = TestValue };
            var result = new CreatedAtRouteResult(string.Empty, routeValues, null);
            var failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButKeyNotFound(
                "CreatedAtRouteResult.RouteValues", TestValue, expectedKey);

            Action a = () => result.Should().BeCreatedAtRouteResult().WithRouteValue(expectedKey, TestValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenExpectedKeyValuePair_ShouldPass()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = expectedValue };
            var result = new CreatedAtRouteResult(string.Empty, routeValues, null);

            result.Should().BeCreatedAtRouteResult().WithRouteValue(expectedKey, expectedValue);
        }

        [Fact]
        public void WithRouteValue_GivenUnexpectedKeyValuePair_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = "someOtherValue" };
            var result = new CreatedAtRouteResult(string.Empty, routeValues, null);
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY(
                "CreatedAtRouteResult.RouteValues", expectedKey, expectedValue, "someOtherValue");

            Action a = () => result.Should().BeCreatedAtRouteResult().WithRouteValue(expectedKey, expectedValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_GivenCreatedAtRouteResult_ShouldHaveTheSameValue()
        {
            var result = new TestController().CreatedAtRoute(string.Empty, null, TestValue);

            result.Should().BeCreatedAtRouteResult().ValueAs<string>().Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new CreatedAtRouteResult(string.Empty, null, null);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull("CreatedAtRouteResult.Value", typeof(object));

            Action a = () => result.Should().BeCreatedAtRouteResult().ValueAs<object>();

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            ActionResult result = new CreatedAtRouteResult(string.Empty, null, "");
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                "CreatedAtRouteResult.Value", typeof(int), typeof(string));

            Action a = () => result.Should().BeCreatedAtRouteResult().ValueAs<int>().Should().Be(2);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
    }
}
