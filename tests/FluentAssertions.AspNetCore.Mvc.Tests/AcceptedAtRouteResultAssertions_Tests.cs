using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    
    public class AcceptedAtRouteResultAssertions_Tests
    {
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
            Action a = () => result.Should().BeAcceptedAtRouteResult().WithRouteName("expectedRoute");
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "AcceptedAtRouteResult.RouteName", "expectedRoute", "someOtherRoute");
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenKeyDoesntExist_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var failureMessage = FailureMessageHelper.Format(FailureMessages.AcceptedAtRouteResult_RouteValues_ContainsKey, expectedKey);

            var routeValues = new {myKey = "MyValue"};
            var result = new AcceptedAtRouteResult(string.Empty, routeValues, null);

            Action a = () => result.Should().BeAcceptedAtRouteResult().WithRouteValue(expectedKey, "");
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenExpectedKeyValuePair_ShouldPass()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new {expectedKey = expectedValue};

            var result = new AcceptedAtRouteResult(string.Empty, routeValues, null);
            result.Should().BeAcceptedAtRouteResult().WithRouteValue(expectedKey, expectedValue);
        }

        [Fact]
        public void HaveValue_GivenUnexpectedKeyValuePair_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = "someOtherValue" };
            var failureMessage = FailureMessageHelper.Format(FailureMessages.AcceptedAtRouteResult_RouteValues_HaveValue, expectedKey, expectedValue, "someOtherValue");

            var result = new AcceptedAtRouteResult(string.Empty, routeValues, null);
            Action a = () => result.Should().BeAcceptedAtRouteResult().WithRouteValue(expectedKey, expectedValue);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().AcceptedAtRoute(string.Empty, null, TestValue);
            result.Should().BeAcceptedAtRouteResult().ValueAs<string>().Should().Be(TestValue);
        }

        [Fact]
        public void ValueAs_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().AcceptedAtRoute(string.Empty, null, TestValue);
            Action a = () => result.Should().BeAcceptedAtRouteResult().ValueAs<string>().Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().AcceptedAtRoute(string.Empty, null, TestValue);
            Action a = () => result.Should().BeAcceptedAtRouteResult().ValueAs<int>().Should().Be(2);
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new AcceptedAtRouteResult(string.Empty, null, null);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonNullWasSuppliedFailMessage, "AcceptedAtRouteResult.Value", typeof(object).Name);
            Action a = () => result.Should().BeAcceptedAtRouteResult().ValueAs<object>();
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
