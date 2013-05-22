using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

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

            Execute.Verification
                    .ForCondition(string.Equals(actualContent, expectedContent, StringComparison.InvariantCultureIgnoreCase))
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

            Execute.Verification
                    .ForCondition(string.Equals(expectedContentType, actualContentType, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(string.Format(FailureMessages.CommonFailMessage, "ContentResult.ContentType", expectedContentType, actualContentType));

            return this;
        }

        /// <summary>
        /// Asserts that the content encoding is the expected content encoding type.
        /// </summary>
        /// <param name="expectedEncoding">The expected content encoding type.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ContentResultAssertions WithContentEncoding(Encoding expectedEncoding, string reason = "", params object[] reasonArgs)
        {
            Encoding actualContentEncoding = (Subject as ContentResult).ContentEncoding;

            Execute.Verification
                    .ForCondition(expectedEncoding == actualContentEncoding)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(string.Format(FailureMessages.CommonFailMessage, "ContentResult.ContentEncoding", expectedEncoding.ToString(), actualContentEncoding.ToString()));

            return this;
        }
    }
}
