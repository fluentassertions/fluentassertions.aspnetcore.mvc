using System;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    [TestFixture]
    public class RedirectResultAssertions_Tests
    {
        [Test]
        public void WithUrl_GivenExpectedUrl_ShouldPass()
        {
            ActionResult result = new RedirectResult("/abc");

            result.Should().BeRedirectResult()
                .WithUrl("/abc");
        }

        [Test]
        public void WithUrl_GivenUnexpectedUrl_ShouldFail()
        {
            ActionResult result = new RedirectResult("/abc");

            Action a = () => result.Should().BeRedirectResult()
                .WithUrl("/xyz");
            a.ShouldThrow<Exception>()
                .WithMessage("Expected RedirectResult.Url to be \"/xyz\" but was \"/abc\"");
        }

        [Test]
        public void WithPermanent_GivenExpectedUrl_ShouldPass()
        {
            ActionResult result = new RedirectResult("/abc", true);

            result.Should().BeRedirectResult()
                .WithPermanent(true);
        }

        [Test]
        public void WithPermanent_GivenUnexpectedUrl_ShouldFail()
        {
            ActionResult result = new RedirectResult("/abc", true);

            Action a = () => result.Should().BeRedirectResult()
                .WithPermanent(false);
            a.ShouldThrow<Exception>()
                .WithMessage("Expected RedirectResult.Permanent to be False but was True");
        }
    }
}
