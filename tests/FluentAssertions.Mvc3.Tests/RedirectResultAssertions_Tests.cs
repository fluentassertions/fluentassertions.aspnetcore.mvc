using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;
using FluentAssertions.Mvc3;

namespace FluentAssertions.Mvc3.Tests
{
    [TestFixture]
    public class RedirectResultAssertions_Tests
    {
        [Test]
        public void HaveUrl_GivenValidUrl_ShouldPass()
        {
            ActionResult result = new RedirectResult("/abc");

            result.Should().BeRedirect()
                .HaveUrl("/abc");
        }

#warning more tests!
    }
}
