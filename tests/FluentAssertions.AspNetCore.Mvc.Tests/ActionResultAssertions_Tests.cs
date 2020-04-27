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
            ActionResult result = TestDataGenerator.CreateFileContentResult();

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
            ActionResult result = TestDataGenerator.CreateFileContentResult();

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
            Action a = () => result.Should().BeFileStreamResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"FileStreamResult\", but found \"ViewResult\"");
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
            Action a = () => result.Should().BePhysicalFileResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"PhysicalFileResult\", but found \"ViewResult\"");
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
            Action a = () => result.Should().BeVirtualFileResult();

            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"VirtualFileResult\", but found \"ViewResult\"");
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

        [Fact]
        public void BeOkResult_GivenOk_ShouldPass()
        {
            ActionResult result = new OkResult();
            result.Should().BeOkResult();
        }

        [Fact]
        public void BeOkResult_GivenNotOk_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeOkResult();
            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"OkResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeBadRequestResult_GivenBadRequest_ShouldPass()
        {
            ActionResult result = new BadRequestResult();
            result.Should().BeBadRequestResult();
        }

        [Fact]
        public void BeBadRequestResult_GivenNotBadRequest_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeBadRequestResult();
            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"BadRequestResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeChallengeResult_GivenChallengeResult_ShouldPass()
        {
            ActionResult result = new ChallengeResult();
            result.Should().BeChallengeResult();
        }

        [Fact]
        public void BeChallengeResult_GivenNotChallengeResult_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeChallengeResult();
            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"ChallengeResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeAcceptedResult_GivenAccepted_ShouldPass()
        {
            ActionResult result = new AcceptedResult();
            result.Should().BeAcceptedResult();
        }

        [Fact]
        public void BeAcceptedResult_GivenNotAccepted_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeAcceptedResult();
            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"AcceptedResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeNoContentResult_GivenNoContent_ShouldPass()
        {
            ActionResult result = new NoContentResult();
            result.Should().BeNoContentResult();
        }

        [Fact]
        public void BeNoContentResult_GivenNotNoContent_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeNoContentResult();
            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"NoContentResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeNotFoundResult_GivenNotFound_ShouldPass()
        {
            ActionResult result = new NotFoundResult();
            result.Should().BeNotFoundResult();
        }

        [Fact]
        public void BeNotFoundResult_GivenNotNotFound_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeNotFoundResult();
            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"NotFoundResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeUnauthorizedResult_GivenUnauthorized_ShouldPass()
        {
            ActionResult result = new UnauthorizedResult();
            result.Should().BeUnauthorizedResult();
        }

        [Fact]
        public void BeUnauthorizedResult_GivenNotUnauthorized_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeUnauthorizedResult();
            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"UnauthorizedResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeSignOutResult_GivenSignOutResult_ShouldPass()
        {
            ActionResult result = new SignOutResult();
            result.Should().BeSignOutResult();
        }

        [Fact]
        public void BeSignOutResult_GivenNotSignOutResult_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeSignOutResult();
            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"SignOutResult\", but found \"ViewResult\"");
        }

        [Fact]
        public void BeLocalRedirectResult_GivenLocalRedirectResult_ShouldPass()
        {
            const string testLocalUrl = "testLocalUrl";
            ActionResult result = new LocalRedirectResult(testLocalUrl);
            result.Should().BeLocalRedirectResult();
        }

        [Fact]
        public void BeLocalRedirectResult_GivenNotLocalRedirectResult_ShouldFail()
        {
            ActionResult result = new ViewResult();
            Action a = () => result.Should().BeLocalRedirectResult();
            a.Should().Throw<Exception>()
                .WithMessage("Expected ActionResult to be \"LocalRedirectResult\", but found \"ViewResult\"");
        }

        #endregion Public Methods
    }
}