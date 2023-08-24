using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class RedirectToPageResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;

        [Fact]
        public void WithPageName_GivenExpectedPageName_ShouldPass()
        {
            var expectedPageName = "expectedPage";
            RedirectToPageResult result = new RedirectToPageResult(expectedPageName, string.Empty, null);

            result.Should().BeRedirectToPageResult()
                .WithPageName(expectedPageName);
        }

        [Fact]
        public void WithPageName_GivenUnexpectedPageName_ShouldFail()
        {
            RedirectToPageResult result = new RedirectToPageResult("someOtherPage", string.Empty, null);

            Action a = () => result.Should().BeRedirectToPageResult()
                .WithPageName("expectedPage", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectToPageResult.PageName", "expectedPage", "someOtherPage"));
        }

        [Fact]
        public void WithFragment_GivenExpectedFragment_ShouldPass()
        {
            var expectedFragment = "expectedFragment";
            RedirectToPageResult result = new RedirectToPageResult(string.Empty, string.Empty, null, false, expectedFragment);

            result.Should().BeRedirectToPageResult()
                .WithFragment(expectedFragment);
        }

        [Fact]
        public void WithFragment_GivenUnexpectedFragment_ShouldFail()
        {
            RedirectToPageResult result = new RedirectToPageResult(string.Empty, string.Empty, null, false, "someOtherFragment");

            Action a = () => result.Should().BeRedirectToPageResult()
                .WithFragment("expectedFragment", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectToPageResult.Fragment", "expectedFragment", "someOtherFragment"));
        }

        [Fact]
        public void WithPermanent_GivenExpectedValue_ShouldPass()
        {
            RedirectToPageResult result = new RedirectToPageResult(string.Empty, string.Empty, null, true);

            result.Should().BeRedirectToPageResult()
                .WithPermanent(true);
        }

        [Fact]
        public void WithPermanent_GivenUnexpectedValue_ShouldFail()
        {
            RedirectToPageResult result = new RedirectToPageResult(string.Empty, string.Empty, null, true);

            Action a = () => result.Should().BeRedirectToPageResult()
                .WithPermanent(false, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectToPageResult.Permanent", false, true));
        }

        [Fact]
        public void WithPreservedMethod_GivenExpectedValue_ShouldPass()
        {
            RedirectToPageResult result = new RedirectToPageResult(string.Empty, string.Empty, null, false, true);

            result.Should().BeRedirectToPageResult()
                .WithPreserveMethod(true);
        }

        [Fact]
        public void WithPreserveMethod_GivenUnexpectedValue_ShouldFail()
        {
            RedirectToPageResult result = new RedirectToPageResult(string.Empty, string.Empty, null, false, true);

            Action a = () => result.Should().BeRedirectToPageResult()
                .WithPreserveMethod(false, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectToPageResult.PreserveMethod", false, true));
        }

        [Fact]
        public void WithRouteValue_GivenKeyDoesntExist_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var failureMessage = FailureMessageHelper.ExpectedKeyButNotFound("RedirectToPageResult.RouteValues", expectedKey, "Val");

            var routeValues = new { myKey = "MyValue" };
            RedirectToPageResult result = new RedirectToPageResult(string.Empty, string.Empty, routeValues);

            Action a = () => result.Should().BeRedirectToPageResult().WithRouteValue(expectedKey, "Val", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithRouteValue_GivenExpectedKeyValuePair_ShouldPass()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = expectedValue };

            RedirectToPageResult result = new RedirectToPageResult(string.Empty, string.Empty, routeValues);

            result.Should().BeRedirectToPageResult().WithRouteValue(expectedKey, expectedValue);
        }

        [Fact]
        public void HaveValue_GivenUnexpectedKeyValuePair_ShouldFail()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var routeValues = new { expectedKey = "someOtherValue" };
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY("RedirectToPageResult.RouteValues", expectedKey, expectedValue, "someOtherValue");

            RedirectToPageResult result = new RedirectToPageResult(string.Empty, string.Empty, routeValues);
            Action a = () => result.Should().BeRedirectToPageResult().WithRouteValue(expectedKey, expectedValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
    }
}
