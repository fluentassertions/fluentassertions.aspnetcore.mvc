using System;
using NUnit.Framework;
using FluentAssertions.Mvc3.Tests.Fakes;
using System.Web.Mvc;
using FluentAssertions.Mvc3;
using System.Web.Routing;

namespace FluentAssertions.Mvc3.Tests
{
	[TestFixture]
	public class ActionResultAssertions_Tests
	{
        [Test]
        public void BeContent_GivenContent_ShouldPass()
        {
            ActionResult result = new ContentResult();
            result.Should().BeContent();
        }
        
        [Test]
        public void BeContent_GivenNotContent_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeContent();
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void BeEmpty_GivenEmpty_ShouldPass()
        {
            ActionResult result = new EmptyResult();
            result.Should().BeEmpty();
        }

        [Test]
        public void BeEmpty_GivenNotEmpty_ShouldPass()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeEmpty();
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void BeRedirectToRoute_GivenRedirectToRoute_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult(new RouteValueDictionary());
            result.Should().BeRedirectToRoute();
        }

        [Test]
        public void BeRedirectToRoute_GivenNotRedirectToRoute_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeRedirectToRoute();
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void BeRedirect_GivenRedirect_ShouldPass()
        {
            ActionResult result = new RedirectResult("/");
            result.Should().BeRedirect();
        }

        [Test]
        public void BeRedirect_GivenNotRedirect_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BePartialView();
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void BePartialView_GivenPartial_ShouldPass()
        {
            ActionResult result = new PartialViewResult();
            result.Should().BePartialView();
        }

        [Test]
        public void BePartialView_GivenNotPartial_ShouldFail()
        {
            ActionResult result = new RedirectResult("/");
            Action a = () => result.Should().BePartialView();
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void BeView_GivenView_ShouldPass()
        {
            ActionResult result = new ViewResult();
            result.Should().BeView();
        }

        [Test]
        public void BeView_GivenNotView_ShouldFail()
        {
            ActionResult result = new RedirectResult("/");
            Action a = () => result.Should().BeView();
            a.ShouldThrow<Exception>();
        }
	}
}
