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
        public ActionResultAssertions(IActionResult subject) : base(subject)
        {
            Subject = subject;
        }

        #endregion Public Constructors

        #region Protected Properties

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public ContentResultAssertions BeContentResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is ContentResult)
                .FailWith(Constants.CommonFailMessage, typeof(ContentResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public EmptyResult BeEmptyResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is EmptyResult)
                .FailWith(Constants.CommonFailMessage, typeof(EmptyResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public FileResultAssertions BeFileResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is FileResult)
                .FailWith(Constants.CommonFailMessage, typeof(FileResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public FileContentResultAssertions BeFileContentResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is FileContentResult)
                .FailWith(Constants.CommonFailMessage, typeof(FileContentResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        internal FileStreamResultAssertions BeFileStreamResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is FileStreamResult)
                .FailWith(Constants.CommonFailMessage, typeof(FileStreamResult), Subject.GetType());

            return new FileStreamResultAssertions(Subject as FileStreamResult);
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
        [CustomAssertion]
        internal PhysicalFileResultAssertions BePhysicalFileResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is PhysicalFileResult)
                .FailWith(Constants.CommonFailMessage, typeof(PhysicalFileResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        internal VirtualFileResultAssertions BeVirtualFileResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is VirtualFileResult)
                .FailWith(Constants.CommonFailMessage, typeof(VirtualFileResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public JsonResultAssertions BeJsonResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is JsonResult)
                .FailWith(Constants.CommonFailMessage, typeof(JsonResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public RedirectToRouteAssertions BeRedirectToRouteResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is RedirectToRouteResult)
                .FailWith(Constants.CommonFailMessage, typeof(RedirectToRouteResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public PartialViewResultAssertions BePartialViewResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is PartialViewResult)
                .FailWith(Constants.CommonFailMessage, typeof(PartialViewResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public RedirectResultAssertions BeRedirectResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is RedirectResult)
                .FailWith(Constants.CommonFailMessage, typeof(RedirectResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public ViewResultAssertions BeViewResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is ViewResult)
                .FailWith(Constants.CommonFailMessage, typeof(ViewResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public RedirectToActionResultAssertions BeRedirectToActionResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is RedirectToActionResult)
                .FailWith(Constants.CommonFailMessage, typeof(RedirectToActionResult), Subject.GetType());

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        [CustomAssertion]
        public StatusCodeResultAssertions BeStatusCodeResult(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Subject is StatusCodeResult)
                .FailWith(Constants.CommonFailMessage, typeof(StatusCodeResult), Subject.GetType());

            return new StatusCodeResultAssertions(Subject as StatusCodeResult);
        }

        #endregion Public Methods

        #region Public Structs

        public struct Constants
        {
            #region Public Fields

            public const string CommonFailMessage = "Expected {context} to be {0}{reason}, but found {1}.";

            #endregion Public Fields
        }

        #endregion Public Structs
    }
}