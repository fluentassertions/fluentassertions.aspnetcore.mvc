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

        public JsonResultAssertions BeJsonResult()
        {
            return BeJsonResult(string.Empty, null);
        }

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
                .FailWith(Constants.CommonFailMessage, "RedirectResult", Subject.GetType().Name);

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
                .FailWith(Constants.CommonFailMessage, "ViewResult", Subject.GetType().Name);

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
                .FailWith(Constants.CommonFailMessage, "RedirectToActionResult", Subject.GetType().Name);

            return new RedirectToActionResultAssertions(Subject as RedirectToActionResult);
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