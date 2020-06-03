using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="RedirectResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class RedirectResultAssertions : ObjectAssertions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RedirectResultAssertions" /> class.
        /// </summary>
        public RedirectResultAssertions(RedirectResult subject) : base(subject) { }

        private RedirectResult RedirectResultSubject => Subject as RedirectResult;
        /// <summary>
        /// Asserts that the url is the expected url.
        /// </summary>
        /// <param name="expectedUrl">The expected url.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public RedirectResultAssertions WithUrl(string expectedUrl, string reason = "", params object[] reasonArgs)
        {
            string actualUrl = RedirectResultSubject.Url;

            Execute.Assertion
                   .ForCondition(string.Equals(actualUrl, expectedUrl, StringComparison.OrdinalIgnoreCase))
                   .BecauseOf(reason, reasonArgs)
                   .WithDefaultIdentifier("RedirectResult.Url")
                   .FailWith(FailureMessages.CommonFailMessage, expectedUrl, actualUrl);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect is permanent.
        /// </summary>
        /// <param name="expectedPermanent">Should the expected redirect be permanent.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public RedirectResultAssertions WithPermanent(bool expectedPermanent, string reason = "", params object[] reasonArgs)
        {
            bool actualPermanent = RedirectResultSubject.Permanent;

            Execute.Assertion
                    .ForCondition(expectedPermanent == actualPermanent)
                    .BecauseOf(reason, reasonArgs)
                    .WithDefaultIdentifier("RedirectResult.Permanent")
                    .FailWith(FailureMessages.CommonFailMessage, expectedPermanent, actualPermanent);

            return this;
        }
    }
}
