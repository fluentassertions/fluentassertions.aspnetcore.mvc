using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="RedirectToPageResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class RedirectToPageResultAssertions : ObjectAssertions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RedirectToPageResultAssertions" /> class.
        /// </summary>
        public RedirectToPageResultAssertions(RedirectToPageResult subject) : base(subject) { }

        private RedirectToPageResult RedirectToPageResultSubject => Subject as RedirectToPageResult;

        /// <summary>
        /// Asserts that the page name is the expected page.
        /// </summary>
        /// <param name="expectedPageName">The expected page.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public RedirectToPageResultAssertions WithPageName(string expectedPageName, string reason = "", params object[] reasonArgs)
        {
            string actualPageName = RedirectToPageResultSubject.PageName;

            Execute.Assertion
                   .ForCondition(string.Equals(actualPageName, expectedPageName, StringComparison.OrdinalIgnoreCase))
                   .BecauseOf(reason, reasonArgs)
                   .WithDefaultIdentifier("RedirectToPageResult.PageName")
                   .FailWith(FailureMessages.CommonFailMessage, expectedPageName, actualPageName);

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
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public RedirectToPageResultAssertions WithFragment(string expectedFragment, string reason = "", params object[] reasonArgs)
        {
            string actualFragment = RedirectToPageResultSubject.Fragment;

            Execute.Assertion
                .ForCondition(string.Equals(actualFragment, expectedFragment, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("RedirectToPageResult.Fragment")
                .FailWith(FailureMessages.CommonFailMessage, expectedFragment, actualFragment);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect to page is permanent.
        /// </summary>
        /// <param name="expectedPermanent">Should the expected redirect be permanent.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public RedirectToPageResultAssertions WithPermanent(bool expectedPermanent, string reason = "", params object[] reasonArgs)
        {
            bool actualPermanent = RedirectToPageResultSubject.Permanent;

            Execute.Assertion
                    .ForCondition(expectedPermanent == actualPermanent)
                    .BecauseOf(reason, reasonArgs)
                    .WithDefaultIdentifier("RedirectToPageResult.Permanent")
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
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public RedirectToPageResultAssertions WithPreserveMethod(bool expectedPreserveMethod, string reason = "", params object[] reasonArgs)
        {
            bool actualPreserveMethod = RedirectToPageResultSubject.PreserveMethod;

            Execute.Assertion
                .ForCondition(expectedPreserveMethod == actualPreserveMethod)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("RedirectToPageResult.PreserveMethod")
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
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public RedirectToPageResultAssertions WithRouteValue(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            var subjectTyped = RedirectToPageResultSubject;

            AssertionHelpers.AssertStringObjectDictionary(subjectTyped.RouteValues, "RedirectToPageResult.RouteValues", key, expectedValue, reason, reasonArgs);

            return this;
        }
    }
}
