using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class ActionResultAssertions_Tests
    {
        #region Public Methods

        [Fact]
        public void BeContent_GivenContent_ShouldPass()
        {
            ActionResult result = new ContentResult();
            result.Should()
                .BeContentResult();
        }

        [Fact]
        public void BeContent_GivenNotContent_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeContentResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"ContentResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeEmpty_GivenEmpty_ShouldPass()
        {
            ActionResult result = new EmptyResult();

            result.Should().BeEmptyResult();
        }

        [Fact]
        public void BeEmpty_GivenNotEmpty_ShouldPass()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeEmptyResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"EmptyResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeFileResult_GivenFileResult_ShouldPass()
        {
            ActionResult result = new FileContentResult(Array.Empty<byte>(), "text/plain");

            result.Should()
                .BeFileResult();
        }

        [Fact]
        public void BeFileResult_GivenNotFileResult_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeFileResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"FileResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeFileContentResult_GivenFileContentResult_ShouldPass()
        {
            ActionResult result = new FileContentResult(Array.Empty<byte>(), "text/plain");

            result.Should()
                .BeFileContentResult();
        }

        [Fact]
        public void BeFileContentResult_GivenNotFileContentResult_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeFileContentResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"FileContentResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeJson_GivenJson_ShouldPass()
        {
            ActionResult result = new JsonResult(new object());

            result.Should()
                .BeJsonResult();
        }

        [Fact]
        public void BeJson_GivenNotJson_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeJsonResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"JsonResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeRedirectToRoute_GivenRedirectToRoute_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult(new RouteValueDictionary());

            result.Should().BeRedirectToRouteResult();
        }

        [Fact]
        public void BeRedirectToRoute_GivenNotRedirectToRoute_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeRedirectToRouteResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"RedirectToRouteResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeRedirect_GivenRedirect_ShouldPass()
        {
            ActionResult result = new RedirectResult("/");

            result.Should().BeRedirectResult();
        }

        [Fact]
        public void BeRedirect_GivenNotRedirect_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeRedirectResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"RedirectResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BePartialView_GivenPartial_ShouldPass()
        {
            ActionResult result = new PartialViewResult();

            result.Should().BePartialViewResult();
        }

        [Fact]
        public void BePartialView_GivenNotPartial_ShouldFail()
        {
            ActionResult result = new RedirectResult("/");
            Action a = () => result.Should().BePartialViewResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"PartialViewResult\", but found \"RedirectResult\"");
        }

        [Fact]
        public void BeView_GivenView_ShouldPass()
        {
            ActionResult result = new ViewResult();

            result.Should().BeViewResult();
        }

        [Fact]
        public void BeView_GivenNotView_ShouldFail()
        {
            ActionResult result = new RedirectResult("/");
            Action a = () => result.Should().BeViewResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"ViewResult\", but found \"RedirectResult\"");
        }

        [Fact]
        public void BeStatusCodeResult_GivenStatusCodeResult_ShouldPass()
        {
            ActionResult result = new StatusCodeResult(200);

            result.Should().BeStatusCodeResult();
        }

        [Fact]
        public void BeStatusCodeResult_GivenNotStatusCodeResult_ShouldFail()
        {
            ActionResult result = new RedirectResult("/");
            Action a = () => result.Should().BeStatusCodeResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"StatusCodeResult\", but found \"RedirectResult\"");
        }

        #endregion Public Methods
    }
}