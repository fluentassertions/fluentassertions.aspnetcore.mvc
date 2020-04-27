using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    
    public class AcceptedAtActionResultAssertions_Tests
    {
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
            Action a = () => result.Should().BeAcceptedAtActionResult().WithActionName("expectedAction");
            a.Should().Throw<Exception>().WithMessage("Expected AcceptedAtActionResult.ActionName to be \"expectedAction\" but was \"someOtherAction\"");
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
            Action a = () => result.Should().BeAcceptedAtActionResult().WithControllerName("expectedController");
            a.Should().Throw<Exception>().WithMessage("Expected AcceptedAtActionResult.ControllerName to be \"expectedController\" but was \"someOtherController\"");
        }

        [Fact]
        public void WithRouteValue_GivenKeyDoesntExist_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var failureMessage = FailureMessageHelper.Format(FailureMessages.AcceptedAtActionResult_RouteValues_ContainsKey, expectedKey);

            var routeValues = new {myKey = "MyValue"};
            var result = new AcceptedAtActionResult(string.Empty, string.Empty, routeValues, null);

            Action a = () => result.Should().BeAcceptedAtActionResult().WithRouteValue(expectedKey, "");
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenExpectedKeyValuePair_ShouldPass()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new {expectedKey = expectedValue};

            var result = new AcceptedAtActionResult(string.Empty, string.Empty, routeValues, null);
            result.Should().BeAcceptedAtActionResult().WithRouteValue(expectedKey, expectedValue);
        }

        [Fact]
        public void HaveValue_GivenUnexpectedKeyValuePair_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = "someOtherValue" };
            var failureMessage = FailureMessageHelper.Format(FailureMessages.AcceptedAtActionResult_RouteValues_HaveValue, expectedKey, expectedValue, "someOtherValue");

            var result = new AcceptedAtActionResult(string.Empty, string.Empty, routeValues, null);
            Action a = () => result.Should().BeAcceptedAtActionResult().WithRouteValue(expectedKey, expectedValue);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().AcceptedAtAction(string.Empty, string.Empty, null, TestValue);
            result.Should().BeAcceptedAtActionResult().ValueAs<string>().Should().Be(TestValue);
        }

        [Fact]
        public void ValueAs_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().AcceptedAtAction(string.Empty, string.Empty, null, TestValue);
            Action a = () => result.Should().BeAcceptedAtActionResult().ValueAs<string>().Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().AcceptedAtAction(string.Empty, string.Empty, null, TestValue);
            Action a = () => result.Should().BeAcceptedAtActionResult().ValueAs<int>().Should().Be(2);
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new AcceptedAtActionResult(string.Empty, string.Empty, null, null);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonNullWasSuppliedFailMessage, "AcceptedAtActionResult.Value", typeof(object).Name);
            Action a = () => result.Should().BeAcceptedAtActionResult().ValueAs<object>();
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
