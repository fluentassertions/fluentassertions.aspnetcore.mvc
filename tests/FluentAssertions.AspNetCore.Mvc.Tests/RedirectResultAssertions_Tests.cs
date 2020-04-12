using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class RedirectResultAssertions_Tests
    {
        [Fact]
        public void WithUrl_GivenExpectedUrl_ShouldPass()
        {
            ActionResult result = new RedirectResult("/abc");

            result.Should().BeRedirectResult()
                .WithUrl("/abc");
        }

        [Fact]
        public void WithUrl_GivenUnexpectedUrl_ShouldFail()
        {
            ActionResult result = new RedirectResult("/abc");

            Action a = () => result.Should().BeRedirectResult()
                .WithUrl("/xyz", "it is {0}", 10);
            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectResult.Url", "/xyz", "/abc"));
        }

        [Fact]
        public void WithPermanent_GivenExpectedUrl_ShouldPass()
        {
            ActionResult result = new RedirectResult("/abc", true);

            result.Should().BeRedirectResult()
                .WithPermanent(true);
        }

        [Fact]
        public void WithPermanent_GivenUnexpectedUrl_ShouldFail()
        {
            ActionResult result = new RedirectResult("/abc", true);

            Action a = () => result.Should().BeRedirectResult()
                .WithPermanent(false, "it is {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectResult.Permanent", false, true));
        }
    }
}
