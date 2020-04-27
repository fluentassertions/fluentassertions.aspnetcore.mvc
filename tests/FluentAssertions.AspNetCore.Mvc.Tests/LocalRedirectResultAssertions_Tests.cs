using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class LocalRedirectObjectResultAssertions_Tests
    {
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

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "LocalRedirectResult.LocalUrl", expectedLocalUrl, actualLocalUrl);
            Action a = () => result.Should().BeLocalRedirectResult().WithLocalUrl(expectedLocalUrl);
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

            var failureMessage = $"Expected LocalRedirectResult.Permanent to be {expectedPermanent} but was {actualPermanent}";
            Action a = () => result.Should().BeLocalRedirectResult().WithPermanent(expectedPermanent);
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

            var failureMessage = $"Expected LocalRedirectResult.PreserveMethod to be {expectedPreserveMethod} but was {actualPreserveMethod}";
            Action a = () => result.Should().BeLocalRedirectResult().WithPreserveMethod(expectedPreserveMethod);
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
