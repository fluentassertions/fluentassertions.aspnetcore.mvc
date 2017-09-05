using System;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="RedirectResult"/> is in the expected state.
    /// </summary>
    public class RedirectResultAssertions : ObjectAssertions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RedirectResultAssertions" /> class.
        /// </summary>
        public RedirectResultAssertions(RedirectResult subject) : base(subject) { }

        /// <summary>
        /// Asserts that the url is the expected url.
        /// </summary>
        /// <param name="expectedUrl">The expected url.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RedirectResultAssertions WithUrl(string expectedUrl, string reason = "", params object[] reasonArgs)
        {
            string actualUrl = (Subject as RedirectResult).Url;

            Execute.Assertion
                   .ForCondition(string.Equals(actualUrl, expectedUrl, StringComparison.OrdinalIgnoreCase))
                   .BecauseOf(reason, reasonArgs)
                   .FailWith("Expected RedirectResult.Url to be {0}{reason} but was {1}", expectedUrl, actualUrl);

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RedirectResultAssertions WithPermanent(bool expectedPermanent, string reason = "", params object[] reasonArgs)
        {
            bool actualPermanent = (Subject as RedirectResult).Permanent;

            Execute.Assertion
                    .ForCondition(expectedPermanent == actualPermanent)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("Expected RedirectResult.Permanent to be {0}{reason} but was {1}", expectedPermanent, actualPermanent);

            return this;
        }
    }
}
