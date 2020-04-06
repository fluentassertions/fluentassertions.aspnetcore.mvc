using FluentAssertions.AspNetCore.Mvc.Tests.Helpers;
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
            Action a = () => result.Should().BeContentResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.ContentResult because the reason 10, but found Microsoft.AspNetCore.Mvc.ViewResult.");
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
            Action a = () => result.Should().BeEmptyResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.EmptyResult because the reason 10, but found Microsoft.AspNetCore.Mvc.ViewResult.");
        }

        [Fact]
        public void BeFileResult_GivenFileResult_ShouldPass()
        {
            ActionResult result = TestDataGenerator.CreateFileContentResult();

            result.Should()
                .BeFileResult();
        }

        [Fact]
        public void BeFileResult_GivenNotFileResult_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeFileResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.FileResult because the reason 10, but found Microsoft.AspNetCore.Mvc.ViewResult.");
        }

        [Fact]
        public void BeFileContentResult_GivenFileContentResult_ShouldPass()
        {
            ActionResult result = TestDataGenerator.CreateFileContentResult();

            result.Should()
                .BeFileContentResult();
        }

        [Fact]
        public void BeFileContentResult_GivenNotFileContentResult_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeFileContentResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.FileContentResult because the reason 10, but found Microsoft.AspNetCore.Mvc.ViewResult.");
        }

        [Fact]
        public void BeFileStreamResult_GivenFileStreamResult_ShouldPass()
        {
            ActionResult result = TestDataGenerator.CreateFileStreamResult();

            result.Should()
                .BeFileStreamResult();
        }

        [Fact]
        public void BeFileStreamResult_GivenNotFileStreamResult_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeFileStreamResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.FileStreamResult because the reason 10, but found Microsoft.AspNetCore.Mvc.ViewResult.");
        }

        [Fact]
        public void BePhysicalFileResult_GivenPhysicalFileResult_ShouldPass()
        {
            ActionResult result = TestDataGenerator.CreatePhysicalFileResult();

            result.Should()
                .BePhysicalFileResult();
        }

        [Fact]
        public void BePhysicalFileResult_GivenNotPhysicalFileResult_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BePhysicalFileResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.PhysicalFileResult because the reason 10, but found Microsoft.AspNetCore.Mvc.ViewResult.");
        }

        [Fact]
        public void BeVirtualFileResult_GivenVirtualFileResult_ShouldPass()
        {
            ActionResult result = TestDataGenerator.CreateVirtualFileResult();

            result.Should()
                .BeVirtualFileResult();
        }

        [Fact]
        public void BeVirtualFileResult_GivenNotVirtualFileResult_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeVirtualFileResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.VirtualFileResult because the reason 10, but found Microsoft.AspNetCore.Mvc.ViewResult.");
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
            Action a = () => result.Should().BeJsonResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.JsonResult because the reason 10, but found Microsoft.AspNetCore.Mvc.ViewResult.");
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
            Action a = () => result.Should().BeRedirectToRouteResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.RedirectToRouteResult because the reason 10, but found Microsoft.AspNetCore.Mvc.ViewResult.");
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
            Action a = () => result.Should().BeRedirectResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.RedirectResult because the reason 10, but found Microsoft.AspNetCore.Mvc.ViewResult.");
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
            Action a = () => result.Should().BePartialViewResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.PartialViewResult because the reason 10, but found Microsoft.AspNetCore.Mvc.RedirectResult.");
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
            Action a = () => result.Should().BeViewResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.ViewResult because the reason 10, but found Microsoft.AspNetCore.Mvc.RedirectResult.");
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
            Action a = () => result.Should().BeStatusCodeResult("the reason {0}", 10);

            a.Should().Throw<Exception>()
                .WithMessage("Expected result to be Microsoft.AspNetCore.Mvc.StatusCodeResult because the reason 10, but found Microsoft.AspNetCore.Mvc.RedirectResult.");
        }

        #endregion Public Methods
    }
}