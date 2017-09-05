using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;

namespace FluentAssertions.Mvc.Tests
{
    [TestFixture]
    public class RedirectToRoute_Tests
    {
        [Test]
		public void WithPermanent_GivenExpected_ShouldPass()
		{
            ActionResult result = new RedirectToRouteResult("", null, true);
            result.Should()
                    .BeRedirectToRouteResult()
                    .WithPermanent(true);
		}

        [Test]
        public void WithPermanent_GivenUnExpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", null, true);
            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithPermanent(false);
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected RedirectToRoute.Permanent to be False, but found True");
        }

        [Test]
        public void WithRouteName_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("default", null);
            result.Should()
                    .BeRedirectToRouteResult()
                    .WithRouteName("default");
        }

        [Test]
        public void WithRouteName_GivenUnExpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("default", null);
            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithRouteName("xyz");
            a.ShouldThrow<Exception>()
                .WithMessage("Expected RedirectToRoute.RouteName to be \"xyz\", but found \"default\"");
        }

        [Test]
        public void WithRouteValue_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Id = "22"
                }));

            result.Should()
                    .BeRedirectToRouteResult()
                    .WithRouteValue("Id", "22");
        }

        [Test]
        public void WithRouteValue_GivenUnexpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Id = "22"
                }));

            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithRouteValue("Id", "11");
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected dictionary to contain value \"11\" at key \"Id\", but found \"22\".");            
        }

        [Test]
        public void WithController_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Controller = "home"
                }));

            result.Should()
                    .BeRedirectToRouteResult()
                    .WithController("home");
        }

        [Test]
        public void WithController_GivenUnexpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Controller = "home"
                }));

            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithController("xyz");
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected dictionary to contain value \"xyz\" at key \"Controller\", but found \"home\".");
        }

        [Test]
        public void WithAction_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Action = "index"
                }));

            result.Should()
                    .BeRedirectToRouteResult()
                    .WithAction("index");
        }

        [Test]
        public void WithAction_GivenUnexpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Action = "index"
                }));

            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithAction("xyz");
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected dictionary to contain value \"xyz\" at key \"Action\", but found \"index\".");
        }

        [Test]
        public void WithArea_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Area = "accounts"
                }));

            result.Should()
                    .BeRedirectToRouteResult()
                    .WithArea("accounts");
        }

        [Test]
        public void WithArea_GivenUnexpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Area = "accounts"
                }));

            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithArea("xyz");
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected dictionary to contain value \"xyz\" at key \"Area\", but found \"accounts\".");
        }
    }
}
