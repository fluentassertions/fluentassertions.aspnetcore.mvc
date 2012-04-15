using System;
using System.Web.Mvc;
using NUnit.Framework;
using System.Web.Routing;

namespace FluentAssertions.Mvc3.Tests
{
    [TestFixture]
    public class RedirectToRoute_Tests
    {
        [Test]
		public void WithPermanent_GivenExpected_ShouldPass()
		{
            ActionResult result = new RedirectToRouteResult("", null, true);
            result.Should()
                    .BeRedirectToRoute()
                    .WithPermanent(true);
		}

        [Test]
        public void WithPermanent_GivenUnxpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", null, true);
            Action a = () => result.Should()
                    .BeRedirectToRoute()
                    .WithPermanent(false);
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void WithRouteName_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("default", null);
            result.Should()
                    .BeRedirectToRoute()
                    .WithRouteName("default");
        }

        [Test]
        public void WithRouteName_GivenUnxpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("default", null);
            Action a = () => result.Should()
                    .BeRedirectToRoute()
                    .WithRouteName("xyz");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void WithController_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new {
                    Controller = "home",
                    Action = "list",
                    Id = "22"
                }));

            result.Should()
                    .BeRedirectToRoute()
                    .WithController("Home");
        }

        [Test]
        public void WithRouteValue_GivenUnxpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Controller = "home",
                    Action = "list",
                    Id = "22"
                }));

            Action a = () => result.Should()
                    .BeRedirectToRoute()
                    .WithController("xyz");
            a.ShouldThrow<Exception>();
        }


    }
}
