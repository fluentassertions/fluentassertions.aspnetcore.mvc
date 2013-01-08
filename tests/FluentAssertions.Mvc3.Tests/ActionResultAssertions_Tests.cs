using System;
using NUnit.Framework;
using FluentAssertions.Mvc.Tests.Fakes;
using System.Web.Mvc;
using FluentAssertions.Mvc;
using System.Web.Routing;

namespace FluentAssertions.Mvc.Tests
{
	[TestFixture]
	public class ActionResultAssertions_Tests
	{
        [Test]
        public void BeContent_GivenContent_ShouldPass()
        {
            ActionResult result = new ContentResult();
            result.Should()
                    .BeContent();
        }
        
        [Test]
        public void BeContent_GivenNotContent_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeContent();
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"ContentResult\", but found \"ViewResult\"");
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
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"EmptyResult\", but found \"ViewResult\"");
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
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"RedirectToRouteResult\", but found \"ViewResult\"");
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
            Action a = () => result.Should().BeRedirect();
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"RedirectResult\", but found \"ViewResult\"");
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
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"PartialViewResult\", but found \"RedirectResult\"");
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
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"ViewResult\", but found \"RedirectResult\"");
        }
	}
}
