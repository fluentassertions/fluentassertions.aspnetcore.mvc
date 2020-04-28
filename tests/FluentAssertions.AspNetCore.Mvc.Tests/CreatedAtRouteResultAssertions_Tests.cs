using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    
    public class CreatedAtRouteResultAssertions_Tests
    {
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
            Action a = () => result.Should().BeCreatedAtRouteResult().WithRouteName("expectedRoute");
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "CreatedAtRouteResult.RouteName", "expectedRoute", "someOtherRoute");
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenKeyDoesntExist_ShouldFail()
        {
            var expectedKey = "expectedKey";            

            var routeValues = new {myKey = "MyValue"};
            var result = new CreatedAtRouteResult(string.Empty, routeValues, null);

            Action a = () => result.Should().BeCreatedAtRouteResult().WithRouteValue(expectedKey, "");
            a.Should().Throw<Exception>().WithMessage("sss");
        }

        [Fact]
        public void WithRouteValue_GivenExpectedKeyValuePair_ShouldPass()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new {expectedKey = expectedValue};

            var result = new CreatedAtRouteResult(string.Empty, routeValues, null);
            result.Should().BeCreatedAtRouteResult().WithRouteValue(expectedKey, expectedValue);
        }

        [Fact]
        public void HaveValue_GivenUnexpectedKeyValuePair_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = "someOtherValue" };

            var result = new CreatedAtRouteResult(string.Empty, routeValues, null);
            Action a = () => result.Should().BeCreatedAtRouteResult().WithRouteValue(expectedKey, expectedValue);
            a.Should().Throw<Exception>().WithMessage("sss");
        }

        [Fact]
        public void ValueAs_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().CreatedAtRoute(string.Empty, null, TestValue);
            result.Should().BeCreatedAtRouteResult().ValueAs<string>().Should().Be(TestValue);
        }

        [Fact]
        public void ValueAs_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().CreatedAtRoute(string.Empty, null, TestValue);
            Action a = () => result.Should().BeCreatedAtRouteResult().ValueAs<string>().Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().CreatedAtRoute(string.Empty, null, TestValue);
            Action a = () => result.Should().BeCreatedAtRouteResult().ValueAs<int>().Should().Be(2);
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new CreatedAtRouteResult(string.Empty, null, null);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonNullWasSuppliedFailMessage, "CreatedAtRouteResult.Value", typeof(object).Name);
            Action a = () => result.Should().BeCreatedAtRouteResult().ValueAs<object>();
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
