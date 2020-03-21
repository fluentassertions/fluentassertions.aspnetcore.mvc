using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    ///     Contains a number of methods to assert that a <see cref="FileResult" /> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class FileResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        public FileResultAssertions(FileResult fileResult)
            : base(fileResult)
        {
        }

        #endregion

        #region Private Properties

        private FileResult FileResultSubject => (FileResult)Subject;

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Asserts that the content type is the expected content type.
        /// </summary>
        /// <param name="expectedContentType">The expected content type.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public FileResultAssertions WithContentType(string expectedContentType, string reason = "",
            params object[] reasonArgs)
        {
            var actualContentType = FileResultSubject.ContentType;

            Execute.Assertion
                .ForCondition(string.Equals(expectedContentType, actualContentType, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .FailWith(FailureMessages.CommonFailMessage, "FileResult.ContentType", expectedContentType, actualContentType);
            return this;
        }

        /// <summary>
        ///     Asserts that the entity tag is the expected value.
        /// </summary>
        /// <param name="expectedEntityTag">The expected entity tag value.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public FileResultAssertions WithEntityTag(EntityTagHeaderValue expectedEntityTag, string reason = "",
            params object[] reasonArgs)
        {
            var actualEntityTag = FileResultSubject.EntityTag;

            Execute.Assertion
                .ForCondition(Equals(expectedEntityTag, actualEntityTag))
                .BecauseOf(reason, reasonArgs)
                .FailWith(FailureMessages.CommonFailMessage, "FileResult.EntityTag", expectedEntityTag, actualEntityTag);
            return this;
        }

        /// <summary>
        ///     Asserts that the file download name is the expected value.
        /// </summary>
        /// <param name="expectedFileDownloadName">The expected file download name.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public FileResultAssertions WithFileDownloadName(string expectedFileDownloadName, string reason = "",
            params object[] reasonArgs)
        {
            var actualFileDownloadName = FileResultSubject.FileDownloadName;

            Execute.Assertion
                .ForCondition(string.Equals(expectedFileDownloadName, actualFileDownloadName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .FailWith(FailureMessages.CommonFailMessage, "FileResult.FileDownloadName", expectedFileDownloadName, actualFileDownloadName);
            return this;
        }

        /// <summary>
        ///     Asserts that the last modified is the expected value.
        /// </summary>
        /// <param name="expectedFileDownloadName">The expected last modified value.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public FileResultAssertions WithLastModified(DateTimeOffset expectedLastModified, string reason = "",
            params object[] reasonArgs)
        {
            var actualLastModified = FileResultSubject.LastModified;

            Execute.Assertion
                .ForCondition(expectedLastModified == actualLastModified)
                .BecauseOf(reason, reasonArgs)
                .FailWith(FailureMessages.CommonFailMessage, "FileResult.LastModified", expectedLastModified, actualLastModified);
            return this;
        }

        #endregion
    }
}
