using System;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="ContentResult"/> is in the expected state.
    /// </summary>
    public class ContentResultAssertions : ObjectAssertions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ContentResultAssertions" /> class.
        /// </summary>
        public ContentResultAssertions(ContentResult subject) : base(subject)
        {
        }

        /// <summary>
        /// Asserts that the content is exactly the same as the expected content, ignoring the casing.
        /// </summary>
        /// <param name="expectedContent">The expected content string.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ContentResultAssertions WithContent(string expectedContent, string reason = "", params object[] reasonArgs)
        {
            string actualContent = (Subject as ContentResult).Content;

            Execute.Assertion
                   .ForCondition(string.Equals(actualContent, expectedContent, StringComparison.OrdinalIgnoreCase))
                   .BecauseOf(reason, reasonArgs)
                   .FailWith(string.Format(FailureMessages.CommonFailMessage, "ContentResult.Content", expectedContent, actualContent));

            return this;
        }

        /// <summary>
        /// Asserts that the content type is the expected content type.
        /// </summary>
        /// <param name="expectedContentType">The expected content type.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ContentResultAssertions WithContentType(string expectedContentType, string reason = "", params object[] reasonArgs)
        {
            string actualContentType = (Subject as ContentResult).ContentType;

            Execute.Assertion
                   .ForCondition(string.Equals(expectedContentType, actualContentType, StringComparison.OrdinalIgnoreCase))
                   .BecauseOf(reason, reasonArgs)
                   .FailWith(string.Format(FailureMessages.CommonFailMessage, "ContentResult.ContentType", expectedContentType, actualContentType));

            return this;
        }
    }
}
