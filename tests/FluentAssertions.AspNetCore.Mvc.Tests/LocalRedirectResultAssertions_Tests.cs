using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class LocalRedirectObjectResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;
        private const string TestLocalUrl = "localUrl";

        [Fact]
        public void WithLocalUrl_GivenExpectedLocalUrl_ShouldPass()
        {
            var result = new TestController().LocalRedirect(TestLocalUrl);

            result.Should().BeLocalRedirectResult().WithLocalUrl(TestLocalUrl);
        }

        [Fact]
        public void WithLocalUrl_GivenUnexpectedLocalUrl_ShouldFail()
        {
            const string actualLocalUrl = TestLocalUrl;
            const string expectedLocalUrl = "otherUrl";
            ActionResult result = new LocalRedirectResult(TestLocalUrl);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("LocalRedirectResult.LocalUrl", expectedLocalUrl, actualLocalUrl);

            Action a = () => result.Should().BeLocalRedirectResult().WithLocalUrl(expectedLocalUrl, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithPermanent_GivenExpectedPermanent_ShouldPass()
        {
            var result = new TestController().LocalRedirectPermanent(TestLocalUrl);

            result.Should().BeLocalRedirectResult().WithPermanent(true);
        }

        [Fact]
        public void WithPermanent_GivenUnexpectedPermanent_ShouldFail()
        {
            var actualPermanent = true;
            var expectedPermanent = false;
            ActionResult result = new LocalRedirectResult(TestLocalUrl) { Permanent = actualPermanent };
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("LocalRedirectResult.Permanent", expectedPermanent, actualPermanent);

            Action a = () => result.Should().BeLocalRedirectResult().WithPermanent(expectedPermanent, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithPreserveMethod_GivenExpectedPreserveMethod_ShouldPass()
        {
            var result = new TestController().LocalRedirectPreserveMethod(TestLocalUrl);

            result.Should().BeLocalRedirectResult().WithPreserveMethod(true);
        }

        [Fact]
        public void WithPreserveMethod_GivenUnexpectedPreserveMethod_ShouldFail()
        {
            var actualPreserveMethod = true;
            var expectedPreserveMethod = false;
            ActionResult result = new LocalRedirectResult(TestLocalUrl) { PreserveMethod = actualPreserveMethod };
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("LocalRedirectResult.PreserveMethod", expectedPreserveMethod, actualPreserveMethod);

            Action a = () => result.Should().BeLocalRedirectResult().WithPreserveMethod(expectedPreserveMethod, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithPreserveMethod_GivenExpectedPermanentPreserveMethod_ShouldPass()
        {
            var result = new TestController().LocalRedirectPermanentPreserveMethod(TestLocalUrl);

            result.Should().BeLocalRedirectResult().WithPermanent(true).WithPreserveMethod(true);
        }
    }
}
