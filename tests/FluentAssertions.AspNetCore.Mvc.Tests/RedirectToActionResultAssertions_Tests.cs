using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class RedirectToActionResultAssertions_Tests
    {
        [Fact]
        public void WithActionName_GivenExpectedActionName_ShouldPass()
        {
            var expectedActionName = "expectedAction";
            RedirectToActionResult result = new RedirectToActionResult(expectedActionName, string.Empty, null);

            result.Should().BeRedirectToActionResult()
                .WithActionName(expectedActionName);
        }

        [Fact]
        public void WithActionName_GivenUnexpectedActionName_ShouldFail()
        {
            RedirectToActionResult result = new RedirectToActionResult("someOtherAction", string.Empty, null);

            Action a = () => result.Should().BeRedirectToActionResult()
                .WithActionName("expectedAction", "it is {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectToActionResult.ActionName", "expectedAction", "someOtherAction"));
        }

        [Fact]
        public void WithControllerName_GivenExpectedControllerName_ShouldPass()
        {
            var expectedControllerName = "expectedController";
            RedirectToActionResult result = new RedirectToActionResult(string.Empty, expectedControllerName, null);

            result.Should().BeRedirectToActionResult()
                .WithControllerName(expectedControllerName);
        }

        [Fact]
        public void WithControllerName_GivenUnexpectedControllerName_ShouldFail()
        {
            RedirectToActionResult result = new RedirectToActionResult(string.Empty, "someOtherController", null);

            Action a = () => result.Should().BeRedirectToActionResult()
                .WithControllerName("expectedController", "it is {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectToActionResult.ControllerName", "expectedController", "someOtherController"));
        }

        [Fact]
        public void WithFragment_GivenExpectedFragment_ShouldPass()
        {
            var expectedFragment = "expectedFragment";
            RedirectToActionResult result = new RedirectToActionResult(string.Empty, string.Empty, null, false, expectedFragment);

            result.Should().BeRedirectToActionResult()
                .WithFragment(expectedFragment);
        }

        [Fact]
        public void WithFragment_GivenUnexpectedFragment_ShouldFail()
        {
            RedirectToActionResult result = new RedirectToActionResult(string.Empty, string.Empty, null, false, "someOtherFragment");

            Action a = () => result.Should().BeRedirectToActionResult()
                .WithFragment("expectedFragment", "it is {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectToActionResult.Fragment", "expectedFragment", "someOtherFragment"));
        }

        [Fact]
        public void WithPermanent_GivenExpectedValue_ShouldPass()
        {
            RedirectToActionResult result = new RedirectToActionResult(string.Empty, string.Empty, null, true);

            result.Should().BeRedirectToActionResult()
                .WithPermanent(true);
        }

        [Fact]
        public void WithPermanent_GivenUnexpectedValue_ShouldFail()
        {
            RedirectToActionResult result = new RedirectToActionResult(string.Empty, string.Empty, null, true);

            Action a = () => result.Should().BeRedirectToActionResult()
                .WithPermanent(false, "it is {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectToActionResult.Permanent", false, true));
        }

        [Fact]
        public void WithPreservedMethod_GivenExpectedValue_ShouldPass()
        {
            RedirectToActionResult result = new RedirectToActionResult(string.Empty, string.Empty, null, false, true);

            result.Should().BeRedirectToActionResult()
                .WithPreserveMethod(true);
        }

        [Fact]
        public void WithPreserveMethod_GivenUnexpectedValue_ShouldFail()
        {
            RedirectToActionResult result = new RedirectToActionResult(string.Empty, string.Empty, null, false, true);

            Action a = () => result.Should().BeRedirectToActionResult()
                .WithPreserveMethod(false, "it is {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectToActionResult.PreserveMethod", false, true));
        }

        [Fact]
        public void WithRouteValue_GivenKeyDoesntExist_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var failureMessage = FailureMessageHelper.ExpectedKeyButNotFound("RedirectToActionResult.RouteValues", expectedKey, "Val");

            var routeValues = new {myKey = "MyValue"};
            RedirectToActionResult result = new RedirectToActionResult(string.Empty, string.Empty, routeValues);

            Action a = () => result.Should().BeRedirectToActionResult().WithRouteValue(expectedKey, "Val", "it is {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenExpectedKeyValuePair_ShouldPass()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new {expectedKey = expectedValue};

            RedirectToActionResult result = new RedirectToActionResult(string.Empty, string.Empty, routeValues);

            result.Should().BeRedirectToActionResult().WithRouteValue(expectedKey, expectedValue);
        }

        [Fact]
        public void HaveValue_GivenUnexpectedKeyValuePair_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = "someOtherValue" };
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY("RedirectToActionResult.RouteValues", expectedKey, expectedValue, "someOtherValue");

            RedirectToActionResult result = new RedirectToActionResult(string.Empty, string.Empty, routeValues);
            Action a = () => result.Should().BeRedirectToActionResult().WithRouteValue(expectedKey, expectedValue, "it is {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
    }
}
