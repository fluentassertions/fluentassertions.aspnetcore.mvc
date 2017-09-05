using System;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

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
                    .BeContentResult();
        }
        
        [Test]
        public void BeContent_GivenNotContent_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeContentResult();
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"ContentResult\", but found \"ViewResult\"");
        }

        [Test]
        public void BeEmpty_GivenEmpty_ShouldPass()
        {
            ActionResult result = new EmptyResult();
            result.Should().BeEmptyResult();
        }

        [Test]
        public void BeEmpty_GivenNotEmpty_ShouldPass()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeEmptyResult();
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"EmptyResult\", but found \"ViewResult\"");
        }

        [Test]
        public void BeRedirectToRoute_GivenRedirectToRoute_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult(new RouteValueDictionary());
            result.Should().BeRedirectToRouteResult();
        }

        [Test]
        public void BeRedirectToRoute_GivenNotRedirectToRoute_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeRedirectToRouteResult();
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"RedirectToRouteResult\", but found \"ViewResult\"");
        }

        [Test]
        public void BeRedirect_GivenRedirect_ShouldPass()
        {
            ActionResult result = new RedirectResult("/");
            result.Should().BeRedirectResult();
        }

        [Test]
        public void BeRedirect_GivenNotRedirect_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeRedirectResult();
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"RedirectResult\", but found \"ViewResult\"");
        }

        [Test]
        public void BePartialView_GivenPartial_ShouldPass()
        {
            ActionResult result = new PartialViewResult();
            result.Should().BePartialViewResult();
        }

        [Test]
        public void BePartialView_GivenNotPartial_ShouldFail()
        {
            ActionResult result = new RedirectResult("/");
            Action a = () => result.Should().BePartialViewResult();
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"PartialViewResult\", but found \"RedirectResult\"");
        }

        [Test]
        public void BeView_GivenView_ShouldPass()
        {
            ActionResult result = new ViewResult();
            result.Should().BeViewResult();
        }

        [Test]
        public void BeView_GivenNotView_ShouldFail()
        {
            ActionResult result = new RedirectResult("/");
            Action a = () => result.Should().BeViewResult();
            a.ShouldThrow<Exception>()
                    .WithMessage("Expected ActionResult to be \"ViewResult\", but found \"RedirectResult\"");
        }
	}
}
