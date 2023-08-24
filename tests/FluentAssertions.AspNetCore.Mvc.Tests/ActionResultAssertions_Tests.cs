using FluentAssertions.AspNetCore.Mvc.Tests.Helpers;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class ActionResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;

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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(ContentResult), typeof(ViewResult));

            Action a = () => result.Should().BeContentResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(EmptyResult), typeof(ViewResult));

            Action a = () => result.Should().BeEmptyResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(FileResult), typeof(ViewResult));

            Action a = () => result.Should().BeFileResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(FileContentResult), typeof(ViewResult));

            Action a = () => result.Should().BeFileContentResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(FileStreamResult), typeof(ViewResult));

            Action a = () => result.Should().BeFileStreamResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(PhysicalFileResult), typeof(ViewResult));

            Action a = () => result.Should().BePhysicalFileResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(VirtualFileResult), typeof(ViewResult));

            Action a = () => result.Should().BeVirtualFileResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(JsonResult), typeof(ViewResult));

            Action a = () => result.Should().BeJsonResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(RedirectToRouteResult), typeof(ViewResult));

            Action a = () => result.Should().BeRedirectToRouteResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(RedirectResult), typeof(ViewResult));

            Action a = () => result.Should().BeRedirectResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            ActionResult result = new ViewResult();
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(PartialViewResult), typeof(ViewResult));

            Action a = () => result.Should().BePartialViewResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(ViewResult), typeof(RedirectResult));

            Action a = () => result.Should().BeViewResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void BePage_GivenPage_ShouldPass()
        {
            ActionResult result = new PageResult();

            result.Should().BePageResult();
        }

        [Fact]
        public void BePage_GivenNotPage_ShouldFail()
        {
            ActionResult result = new RedirectResult("/");
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(PageResult), typeof(RedirectResult));

            Action a = () => result.Should().BePageResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            ActionResult result = new ViewResult();
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(StatusCodeResult), typeof(ViewResult));

            Action a = () => result.Should().BeStatusCodeResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void BeObjectResult_GivenObjectResult_ShouldPass()
        {
            ActionResult result = new ObjectResult("TestValue");

            result.Should().BeObjectResult();
        }

        [Fact]
        public void BeObjectResult_GivenNotObjectResult_ShouldFail()
        {
            ActionResult result = new ViewResult();
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(ObjectResult), typeof(ViewResult));

            Action a = () => result.Should().BeObjectResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(OkResult), typeof(ViewResult));

            Action a = () => result.Should().BeOkResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(BadRequestResult), typeof(ViewResult));

            Action a = () => result.Should().BeBadRequestResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void BeConflictResult_GivenConflict_ShouldPass()
        {
            ActionResult result = new ConflictResult();

            result.Should().BeConflictResult();
        }

        [Fact]
        public void BeConflictResult_GivenNotConflict_ShouldFail()
        {
            ActionResult result = new ViewResult();
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(ConflictResult), typeof(ViewResult));

            Action a = () => result.Should().BeConflictResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void BeConflictObjectResult_GivenConflictObject_ShouldPass()
        {
            ActionResult result = new ConflictObjectResult("foo");

            result.Should().BeConflictObjectResult();
        }

        [Fact]
        public void BeConflictObjectResult_GivenNotConflictObject_ShouldFail()
        {
            ActionResult result = new ConflictResult();
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(ConflictObjectResult), typeof(ConflictResult));

            Action a = () => result.Should().BeConflictObjectResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(ChallengeResult), typeof(ViewResult));

            Action a = () => result.Should().BeChallengeResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(AcceptedResult), typeof(ViewResult));

            Action a = () => result.Should().BeAcceptedResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(NoContentResult), typeof(ViewResult));

            Action a = () => result.Should().BeNoContentResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(NotFoundResult), typeof(ViewResult));

            Action a = () => result.Should().BeNotFoundResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(UnauthorizedResult), typeof(ViewResult));

            Action a = () => result.Should().BeUnauthorizedResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(SignOutResult), typeof(ViewResult));

            Action a = () => result.Should().BeSignOutResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
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
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason("result", typeof(LocalRedirectResult), typeof(ViewResult));

            Action a = () => result.Should().BeLocalRedirectResult(Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        #endregion Public Methods
    }
}