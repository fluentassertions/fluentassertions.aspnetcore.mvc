using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="RedirectToActionResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class RedirectToActionResultAssertions : ObjectAssertions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RedirectToActionResultAssertions" /> class.
        /// </summary>
        public RedirectToActionResultAssertions(RedirectToActionResult subject) : base(subject) { }

        private RedirectToActionResult RedirectToActionResultSubject => Subject as RedirectToActionResult;
        /// <summary>
        /// Asserts that the action name is the expected action.
        /// </summary>
        /// <param name="expectedActionName">The expected action.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RedirectToActionResultAssertions WithActionName(string expectedActionName, string reason = "", params object[] reasonArgs)
        {
            string actualActionName = RedirectToActionResultSubject.ActionName;

            Execute.Assertion
                   .ForCondition(string.Equals(actualActionName, expectedActionName, StringComparison.OrdinalIgnoreCase))
                   .BecauseOf(reason, reasonArgs)
                   .WithDefaultIdentifier("RedirectToActionResult.ActionName")
                   .FailWith(FailureMessages.CommonFailMessage, expectedActionName, actualActionName);

            return this;
        }

        /// <summary>
        /// Asserts that the controller name is the expected controller.
        /// </summary>
        /// <param name="expectedControllerName">The expected controller.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RedirectToActionResultAssertions WithControllerName(string expectedControllerName, string reason = "", params object[] reasonArgs)
        {
            string actualControllerName = RedirectToActionResultSubject.ControllerName;

            Execute.Assertion
                .ForCondition(string.Equals(actualControllerName, expectedControllerName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("RedirectToActionResult.ControllerName")
                .FailWith(FailureMessages.CommonFailMessage, expectedControllerName, actualControllerName);

            return this;
        }

        /// <summary>
        /// Asserts that the fragment is the expected fragment.
        /// </summary>
        /// <param name="expectedFragment">The expected fragment.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RedirectToActionResultAssertions WithFragment(string expectedFragment, string reason = "", params object[] reasonArgs)
        {
            string actualFragment = RedirectToActionResultSubject.Fragment;

            Execute.Assertion
                .ForCondition(string.Equals(actualFragment, expectedFragment, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("RedirectToActionResult.Fragment")
                .FailWith(FailureMessages.CommonFailMessage, expectedFragment, actualFragment);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect to action is permanent.
        /// </summary>
        /// <param name="expectedPermanent">Should the expected redirect be permanent.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RedirectToActionResultAssertions WithPermanent(bool expectedPermanent, string reason = "", params object[] reasonArgs)
        {
            bool actualPermanent = RedirectToActionResultSubject.Permanent;

            Execute.Assertion
                    .ForCondition(expectedPermanent == actualPermanent)
                    .BecauseOf(reason, reasonArgs)
                    .WithDefaultIdentifier("RedirectToActionResult.Permanent")
                    .FailWith(FailureMessages.CommonFailMessage, expectedPermanent, actualPermanent);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect preserves the original request method.
        /// </summary>
        /// <param name="expectedPreserveMethod">Should the expected redirect preserve the original request method.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RedirectToActionResultAssertions WithPreserveMethod(bool expectedPreserveMethod, string reason = "", params object[] reasonArgs)
        {
            bool actualPreserveMethod = RedirectToActionResultSubject.PreserveMethod;

            Execute.Assertion
                .ForCondition(expectedPreserveMethod == actualPreserveMethod)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("RedirectToActionResult.PreserveMethod")
                .FailWith(FailureMessages.CommonFailMessage, expectedPreserveMethod, actualPreserveMethod);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected route value.
        /// </summary>
        /// <param name="key">The expected key.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RedirectToActionResultAssertions WithRouteValue(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            var subjectTyped = RedirectToActionResultSubject;

            AssertionHelpers.AssertStringObjectDictionary(subjectTyped.RouteValues, "RedirectToActionResult.RouteValues", key, expectedValue, reason, reasonArgs);

            return this;
        }
    }
}
