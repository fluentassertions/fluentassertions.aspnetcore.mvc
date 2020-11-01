using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that an <see cref="ActionResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class ActionResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionResultAssertions" /> class.
        /// </summary>
        public ActionResultAssertions(IActionResult subject) : base(subject)
        {
            Subject = subject;
        }

        #endregion Public Constructors

        #region Protected Properties
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        protected override string Identifier => "ActionResult";

        #endregion Protected Properties

        #region Public Methods

        /// <summary>
        /// Asserts that the subject is a <see cref="ContentResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public ContentResultAssertions BeContentResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is ContentResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(ContentResult), Subject.GetType());

            return new ContentResultAssertions(Subject as ContentResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="EmptyResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public EmptyResult BeEmptyResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is EmptyResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(EmptyResult), Subject.GetType());

            return Subject as EmptyResult;
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="FileResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public FileResultAssertions BeFileResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is FileResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(FileResult), Subject.GetType());

            return new FileResultAssertions(Subject as FileResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="FileContentResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public FileContentResultAssertions BeFileContentResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is FileContentResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(FileContentResult), Subject.GetType());

            return new FileContentResultAssertions(Subject as FileContentResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="FileStreamResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public FileStreamResultAssertions BeFileStreamResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is FileStreamResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(FileStreamResult), Subject.GetType());

            return new FileStreamResultAssertions(Subject as FileStreamResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="PhysicalFileResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public PhysicalFileResultAssertions BePhysicalFileResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is PhysicalFileResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(PhysicalFileResult), Subject.GetType());

            return new PhysicalFileResultAssertions(Subject as PhysicalFileResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="VirtualFileResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public VirtualFileResultAssertions BeVirtualFileResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is VirtualFileResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(VirtualFileResult), Subject.GetType());

            return new VirtualFileResultAssertions(Subject as VirtualFileResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="JsonResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public JsonResultAssertions BeJsonResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is JsonResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(JsonResult), Subject.GetType());

            return new JsonResultAssertions(Subject as JsonResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="RedirectToRouteResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public RedirectToRouteAssertions BeRedirectToRouteResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is RedirectToRouteResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(RedirectToRouteResult), Subject.GetType());

            return new RedirectToRouteAssertions(Subject as RedirectToRouteResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="PartialViewResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public PartialViewResultAssertions BePartialViewResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is PartialViewResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(PartialViewResult), Subject.GetType());

            return new PartialViewResultAssertions(Subject as PartialViewResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="RedirectResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public RedirectResultAssertions BeRedirectResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is RedirectResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(RedirectResult), Subject.GetType());

            return new RedirectResultAssertions(Subject as RedirectResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="ViewResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public ViewResultAssertions BeViewResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is ViewResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(ViewResult), Subject.GetType());

            return new ViewResultAssertions(Subject as ViewResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="RedirectToActionResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public RedirectToActionResultAssertions BeRedirectToActionResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is RedirectToActionResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(RedirectToActionResult), Subject.GetType());

            return new RedirectToActionResultAssertions(Subject as RedirectToActionResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="StatusCodeResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public StatusCodeResultAssertions BeStatusCodeResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is StatusCodeResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(StatusCodeResult), Subject.GetType());

            return new StatusCodeResultAssertions(Subject as StatusCodeResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="ObjectResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public ObjectResultAssertions BeObjectResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is ObjectResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(ObjectResult), Subject.GetType());

            return new ObjectResultAssertions(Subject as ObjectResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="OkResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public OkResult BeOkResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is OkResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(OkResult), Subject.GetType());

            return Subject as OkResult;
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="OkObjectResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public OkObjectResultAssertions BeOkObjectResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is OkObjectResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(OkObjectResult), Subject.GetType());

            return new OkObjectResultAssertions(Subject as OkObjectResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="BadRequestResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public BadRequestResult BeBadRequestResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is BadRequestResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(BadRequestResult), Subject.GetType());

            return Subject as BadRequestResult;
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="BadRequestObjectResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public BadRequestObjectResultAssertions BeBadRequestObjectResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is BadRequestObjectResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(BadRequestObjectResult), Subject.GetType());

            return new BadRequestObjectResultAssertions(Subject as BadRequestObjectResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public CreatedResultAssertions BeCreatedResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is CreatedResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(CreatedResult), Subject.GetType());

            return new CreatedResultAssertions(Subject as CreatedResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="ChallengeResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public ChallengeResultAssertions BeChallengeResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is ChallengeResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(ChallengeResult), Subject.GetType());

            return new ChallengeResultAssertions(Subject as ChallengeResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="AcceptedResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public AcceptedResultAssertions BeAcceptedResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is AcceptedResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(AcceptedResult), Subject.GetType());

            return new AcceptedResultAssertions(Subject as AcceptedResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="ForbidResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public ForbidResultAssertions BeForbidResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is ForbidResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(ForbidResult), Subject.GetType());

            return new ForbidResultAssertions(Subject as ForbidResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="NoContentResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public NoContentResult BeNoContentResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is NoContentResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(NoContentResult), Subject.GetType());

            return Subject as NoContentResult;
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="NotFoundResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public NotFoundResult BeNotFoundResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is NotFoundResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(NotFoundResult), Subject.GetType());

            return Subject as NotFoundResult;
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="NotFoundObjectResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public NotFoundObjectResultAssertions BeNotFoundObjectResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is NotFoundObjectResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(NotFoundObjectResult), Subject.GetType());

            return new NotFoundObjectResultAssertions(Subject as NotFoundObjectResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="UnauthorizedResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public UnauthorizedResult BeUnauthorizedResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is UnauthorizedResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(UnauthorizedResult), Subject.GetType());

            return Subject as UnauthorizedResult;
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="SignInResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public SignInResultAssertions BeSignInResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is SignInResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(SignInResult), Subject.GetType());

            return new SignInResultAssertions(Subject as SignInResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="SignOutResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public SignOutResultAssertions BeSignOutResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is SignOutResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(SignOutResult), Subject.GetType());

            return new SignOutResultAssertions(Subject as SignOutResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="LocalRedirectResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public LocalRedirectResultAssertions BeLocalRedirectResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is LocalRedirectResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(LocalRedirectResult), Subject.GetType());

            return new LocalRedirectResultAssertions(Subject as LocalRedirectResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="AcceptedAtActionResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public AcceptedAtActionResultAssertions BeAcceptedAtActionResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is AcceptedAtActionResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(AcceptedAtActionResult), Subject.GetType());

            return new AcceptedAtActionResultAssertions(Subject as AcceptedAtActionResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="AcceptedAtRouteResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public AcceptedAtRouteResultAssertions BeAcceptedAtRouteResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is AcceptedAtRouteResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(AcceptedAtRouteResult), Subject.GetType());

            return new AcceptedAtRouteResultAssertions(Subject as AcceptedAtRouteResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="CreatedAtActionResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public CreatedAtActionResultAssertions BeCreatedAtActionResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is CreatedAtActionResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(CreatedAtActionResult), Subject.GetType());

            return new CreatedAtActionResultAssertions(Subject as CreatedAtActionResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="CreatedAtRouteResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public CreatedAtRouteResultAssertions BeCreatedAtRouteResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is CreatedAtRouteResult)
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(CreatedAtRouteResult), Subject.GetType());

            return new CreatedAtRouteResultAssertions(Subject as CreatedAtRouteResult);
        }

        #endregion Public Methods
    }
}