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
        /// Initializes a new instance of the <see cref="T:ActionResultAssertions" /> class.
        /// </summary>
        public ActionResultAssertions(ActionResult subject) : base(subject)
        {
            Subject = subject;
        }

        public ActionResultAssertions(IActionResult subject) : base(subject)
        {
            Subject = subject;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Asserts that the subject is a <see cref="ContentResult"/>.
        /// </summary>
        public ContentResultAssertions BeContentResult()
        {
            return BeContentResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="ContentResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ContentResultAssertions BeContentResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is ContentResult)
                .FailWith(Constants.CommonFailMessage, typeof(ContentResult).Name, Subject.GetType().Name);

            return new ContentResultAssertions(Subject as ContentResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="EmptyResult"/>.
        /// </summary>
        public EmptyResult BeEmptyResult()
        {
            return BeEmptyResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="EmptyResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public EmptyResult BeEmptyResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is EmptyResult)
                .FailWith(Constants.CommonFailMessage, typeof(EmptyResult).Name, Subject.GetType().Name);

            return Subject as EmptyResult;
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="FileResult"/>.
        /// </summary>
        public FileResultAssertions BeFileResult()
        {
            return BeFileResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="FileResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public FileResultAssertions BeFileResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is FileResult)
                .FailWith(Constants.CommonFailMessage, typeof(FileResult).Name, Subject.GetType().Name);

            return new FileResultAssertions(Subject as FileResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="FileContentResult"/>.
        /// </summary>
        public FileContentResultAssertions BeFileContentResult()
        {
            return BeFileContentResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="FileContentResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public FileContentResultAssertions BeFileContentResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is FileContentResult)
                .FailWith(Constants.CommonFailMessage, typeof(FileContentResult).Name, Subject.GetType().Name);

            return new FileContentResultAssertions(Subject as FileContentResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="FileStreamResult"/>.
        /// </summary>
        public FileStreamResultAssertions BeFileStreamResult()
        {
            return BeFileStreamResult(string.Empty, null);

        }

        /// <summary>
        /// Asserts that the subject is an <see cref="FileStreamResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public FileStreamResultAssertions BeFileStreamResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is FileStreamResult)
                .FailWith(Constants.CommonFailMessage, typeof(FileStreamResult).Name, Subject.GetType().Name);

            return new FileStreamResultAssertions(Subject as FileStreamResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="PhysicalFileResult"/>.
        /// </summary>
        public PhysicalFileResultAssertions BePhysicalFileResult()
        {
            return BePhysicalFileResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="FileStreamResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public PhysicalFileResultAssertions BePhysicalFileResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is PhysicalFileResult)
                .FailWith(Constants.CommonFailMessage, typeof(PhysicalFileResult).Name, Subject.GetType().Name);

            return new PhysicalFileResultAssertions(Subject as PhysicalFileResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="VirtualFileResult"/>.
        /// </summary>
        public VirtualFileResultAssertions BeVirtualFileResult()
        {
            return BeVirtualFileResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="VirtualFileResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public VirtualFileResultAssertions BeVirtualFileResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is VirtualFileResult)
                .FailWith(Constants.CommonFailMessage, typeof(VirtualFileResult).Name, Subject.GetType().Name);

            return new VirtualFileResultAssertions(Subject as VirtualFileResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="JsonResult"/>.
        /// </summary>
        public JsonResultAssertions BeJsonResult()
        {
            return BeJsonResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="JsonResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public JsonResultAssertions BeJsonResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is JsonResult)
                .FailWith(Constants.CommonFailMessage, typeof(JsonResult).Name, Subject.GetType().Name);

            return new JsonResultAssertions(Subject as JsonResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="RedirectToRouteResult"/>.
        /// </summary>
        [CustomAssertion]
        public RedirectToRouteAssertions BeRedirectToRouteResult()
        {
            return BeRedirectToRouteResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="RedirectToRouteResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public RedirectToRouteAssertions BeRedirectToRouteResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is RedirectToRouteResult)
                .FailWith(Constants.CommonFailMessage, typeof(RedirectToRouteResult).Name, Subject.GetType().Name);

            return new RedirectToRouteAssertions(Subject as RedirectToRouteResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="PartialViewResult"/>.
        /// </summary>
        public PartialViewResultAssertions BePartialViewResult()
        {
            return BePartialViewResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="PartialViewResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public PartialViewResultAssertions BePartialViewResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is PartialViewResult)
                .FailWith(Constants.CommonFailMessage, typeof(PartialViewResult).Name, Subject.GetType().Name);

            return new PartialViewResultAssertions(Subject as PartialViewResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="RedirectResult"/>.
        /// </summary>
        public RedirectResultAssertions BeRedirectResult()
        {
            return BeRedirectResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="RedirectResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RedirectResultAssertions BeRedirectResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is RedirectResult)
                .FailWith(Constants.CommonFailMessage, typeof(RedirectResult).Name, Subject.GetType().Name);

            return new RedirectResultAssertions(Subject as RedirectResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="ViewResult"/>.
        /// </summary>
        public ViewResultAssertions BeViewResult()
        {
            return BeViewResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="ViewResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ViewResultAssertions BeViewResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is ViewResult)
                .FailWith(Constants.CommonFailMessage, typeof(ViewResult).Name, Subject.GetType().Name);

            return new ViewResultAssertions(Subject as ViewResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="RedirectToActionResult"/>.
        /// </summary>
        public RedirectToActionResultAssertions BeRedirectToActionResult()
        {
            return BeRedirectToActionResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="RedirectToActionResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RedirectToActionResultAssertions BeRedirectToActionResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is RedirectToActionResult)
                .FailWith(Constants.CommonFailMessage, typeof(RedirectToActionResult).Name, Subject.GetType().Name);

            return new RedirectToActionResultAssertions(Subject as RedirectToActionResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="StatusCodeResult"/>.
        /// </summary>
        public StatusCodeResultAssertions BeStatusCodeResult()
        {
            return BeStatusCodeResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="StatusCodeResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public StatusCodeResultAssertions BeStatusCodeResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is StatusCodeResult)
                .FailWith(Constants.CommonFailMessage, typeof(StatusCodeResult).Name, Subject.GetType().Name);

            return new StatusCodeResultAssertions(Subject as StatusCodeResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="OkResult"/>.
        /// </summary>
        public OkResult BeOkResult()
        {
            return BeOkResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="OkResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public OkResult BeOkResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is OkResult)
                .FailWith(Constants.CommonFailMessage, typeof(OkResult).Name, Subject.GetType().Name);

            return Subject as OkResult;
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="OkObjectResult"/>.
        /// </summary>
        public OkObjectResultAssertions BeOkObjectResult()
        {
            return BeOkObjectResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="OkObjectResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public OkObjectResultAssertions BeOkObjectResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is OkObjectResult)
                .FailWith(Constants.CommonFailMessage, typeof(OkObjectResult).Name, Subject.GetType().Name);

            return new OkObjectResultAssertions(Subject as OkObjectResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="BadRequestResult"/>.
        /// </summary>
        public BadRequestResult BeBadRequestResult()
        {
            return BeBadRequestResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="BadRequestResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public BadRequestResult BeBadRequestResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is BadRequestResult)
                .FailWith(Constants.CommonFailMessage, typeof(BadRequestResult).Name, Subject.GetType().Name);

            return Subject as BadRequestResult;
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="BadRequestObjectResult"/>.
        /// </summary>
        public BadRequestObjectResultAssertions BeBadRequestObjectResult()
        {
            return BeBadRequestObjectResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="BadRequestObjectResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public BadRequestObjectResultAssertions BeBadRequestObjectResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is BadRequestObjectResult)
                .FailWith(Constants.CommonFailMessage, typeof(BadRequestObjectResult).Name, Subject.GetType().Name);

            return new BadRequestObjectResultAssertions(Subject as BadRequestObjectResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="CreatedResult"/>.
        /// </summary>
        public CreatedResultAssertions BeCreatedResult()
        {
            return BeCreatedResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="CreatedResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public CreatedResultAssertions BeCreatedResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is CreatedResult)
                .FailWith(Constants.CommonFailMessage, typeof(CreatedResult).Name, Subject.GetType().Name);

            return new CreatedResultAssertions(Subject as CreatedResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="ChallengeResult"/>.
        /// </summary>
        public ChallengeResultAssertions BeChallengeResult()
        {
            return BeChallengeResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="ChallengeResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ChallengeResultAssertions BeChallengeResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is ChallengeResult)
                .FailWith(Constants.CommonFailMessage, typeof(ChallengeResult).Name, Subject.GetType().Name);

            return new ChallengeResultAssertions(Subject as ChallengeResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="AcceptedResult"/>.
        /// </summary>
        public AcceptedResultAssertions BeAcceptedResult()
        {
            return BeAcceptedResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="AcceptedResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public AcceptedResultAssertions BeAcceptedResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is AcceptedResult)
                .FailWith(Constants.CommonFailMessage, typeof(AcceptedResult).Name, Subject.GetType().Name);

            return new AcceptedResultAssertions(Subject as AcceptedResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="ForbidResult"/>.
        /// </summary>
        public ForbidResultAssertions BeForbidResult()
        {
            return BeForbidResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="ForbidResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ForbidResultAssertions BeForbidResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is ForbidResult)
                .FailWith(Constants.CommonFailMessage, typeof(ForbidResult).Name, Subject.GetType().Name);

            return new ForbidResultAssertions(Subject as ForbidResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="NoContentResult"/>.
        /// </summary>
        public NoContentResult BeNoContentResult()
        {
            return BeNoContentResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="NoContentResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public NoContentResult BeNoContentResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is NoContentResult)
                .FailWith(Constants.CommonFailMessage, typeof(NoContentResult).Name, Subject.GetType().Name);

            return Subject as NoContentResult;
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="NotFoundResult"/>.
        /// </summary>
        public NotFoundResult BeNotFoundResult()
        {
            return BeNotFoundResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="NotFoundResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public NotFoundResult BeNotFoundResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is NotFoundResult)
                .FailWith(Constants.CommonFailMessage, typeof(NotFoundResult).Name, Subject.GetType().Name);

            return Subject as NotFoundResult;
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="NotFoundObjectResult"/>.
        /// </summary>
        public NotFoundObjectResultAssertions BeNotFoundObjectResult()
        {
            return BeNotFoundObjectResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="NotFoundObjectResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public NotFoundObjectResultAssertions BeNotFoundObjectResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is NotFoundObjectResult)
                .FailWith(Constants.CommonFailMessage, typeof(NotFoundObjectResult).Name, Subject.GetType().Name);

            return new NotFoundObjectResultAssertions(Subject as NotFoundObjectResult);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="UnauthorizedResult"/>.
        /// </summary>
        public UnauthorizedResult BeUnauthorizedResult()
        {
            return BeUnauthorizedResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is an <see cref="UnauthorizedResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public UnauthorizedResult BeUnauthorizedResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is UnauthorizedResult)
                .FailWith(Constants.CommonFailMessage, typeof(UnauthorizedResult).Name, Subject.GetType().Name);

            return Subject as UnauthorizedResult;
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="SignInResult"/>.
        /// </summary>
        public SignInResultAssertions BeSignInResult()
        {
            return BeSignInResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="SignInResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public SignInResultAssertions BeSignInResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is SignInResult)
                .FailWith(Constants.CommonFailMessage, typeof(SignInResult).Name, Subject.GetType().Name);

            return new SignInResultAssertions(Subject as SignInResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="SignOutResult"/>.
        /// </summary>
        public SignOutResultAssertions BeSignOutResult()
        {
            return BeSignOutResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="SignOutResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public SignOutResultAssertions BeSignOutResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is SignOutResult)
                .FailWith(Constants.CommonFailMessage, typeof(SignOutResult).Name, Subject.GetType().Name);

            return new SignOutResultAssertions(Subject as SignOutResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="LocalRedirectResult"/>.
        /// </summary>
        public LocalRedirectResultAssertions BeLocalRedirectResult()
        {
            return BeLocalRedirectResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="LocalRedirectResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public LocalRedirectResultAssertions BeLocalRedirectResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is LocalRedirectResult)
                .FailWith(Constants.CommonFailMessage, typeof(LocalRedirectResult).Name, Subject.GetType().Name);

            return new LocalRedirectResultAssertions(Subject as LocalRedirectResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="AcceptedAtActionResult"/>.
        /// </summary>
        public AcceptedAtActionResultAssertions BeAcceptedAtActionResult()
        {
            return BeAcceptedAtActionResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="AcceptedAtActionResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public AcceptedAtActionResultAssertions BeAcceptedAtActionResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is AcceptedAtActionResult)
                .FailWith(Constants.CommonFailMessage, typeof(AcceptedAtActionResult).Name, Subject.GetType().Name);

            return new AcceptedAtActionResultAssertions(Subject as AcceptedAtActionResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="AcceptedAtRouteResult"/>.
        /// </summary>
        public AcceptedAtRouteResultAssertions BeAcceptedAtRouteResult()
        {
            return BeAcceptedAtRouteResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="AcceptedAtRouteResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public AcceptedAtRouteResultAssertions BeAcceptedAtRouteResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is AcceptedAtRouteResult)
                .FailWith(Constants.CommonFailMessage, typeof(AcceptedAtRouteResult).Name, Subject.GetType().Name);

            return new AcceptedAtRouteResultAssertions(Subject as AcceptedAtRouteResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="CreatedAtActionResult"/>.
        /// </summary>
        public CreatedAtActionResultAssertions BeCreatedAtActionResult()
        {
            return BeCreatedAtActionResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="CreatedAtActionResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public CreatedAtActionResultAssertions BeCreatedAtActionResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is CreatedAtActionResult)
                .FailWith(Constants.CommonFailMessage, typeof(CreatedAtActionResult).Name, Subject.GetType().Name);

            return new CreatedAtActionResultAssertions(Subject as CreatedAtActionResult);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="CreatedAtRouteResult"/>.
        /// </summary>
        public CreatedAtRouteResultAssertions BeCreatedAtRouteResult()
        {
            return BeCreatedAtRouteResult(string.Empty, null);
        }

        /// <summary>
        /// Asserts that the subject is a <see cref="CreatedAtRouteResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public CreatedAtRouteResultAssertions BeCreatedAtRouteResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is CreatedAtRouteResult)
                .FailWith(Constants.CommonFailMessage, typeof(CreatedAtRouteResult).Name, Subject.GetType().Name);

            return new CreatedAtRouteResultAssertions(Subject as CreatedAtRouteResult);
        }

        #endregion Public Methods

        #region Public Structs

        public struct Constants
        {
            #region Public Fields

            public const string CommonFailMessage = "Expected ActionResult to be {0}{reason}, but found {1}";

            #endregion Public Fields
        }

        #endregion Public Structs
    }
}