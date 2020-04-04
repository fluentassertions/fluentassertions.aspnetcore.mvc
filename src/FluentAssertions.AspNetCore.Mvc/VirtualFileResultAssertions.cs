using System;
using System.Diagnostics;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="VirtualFileResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class VirtualFileResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:VirtualFileResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public VirtualFileResultAssertions(VirtualFileResult subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties
        /// <summary>
        ///     The value on the VirtualFileResult
        /// </summary>
        public string FileName => VirtualFileResultSubject.FileName;
        public string ContentType => VirtualFileResultSubject.ContentType;
        public string FileDownloadName => VirtualFileResultSubject.FileDownloadName;
        public DateTimeOffset? LastModified => VirtualFileResultSubject.LastModified;
        public EntityTagHeaderValue EntityTag => VirtualFileResultSubject.EntityTag;

        #endregion

        #region Private Properties
        private VirtualFileResult VirtualFileResultSubject => (VirtualFileResult)Subject;

        #endregion

        #region Public Methods
        /// <summary>
        /// Asserts that the FileName is exactly the same as the expected FileName, ignoring the casing.
        /// </summary>
        /// <param name="expectedFileName">The expected FileName string.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public VirtualFileResultAssertions WithFileName(string expectedFileName, string reason = "", params object[] reasonArgs)
        {
            var actualFileName = FileName;

            Execute.Assertion
                .ForCondition(string.Equals(actualFileName, expectedFileName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .FailWith(string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.FileName", expectedFileName, actualFileName));

            return this;
        }

        /// <summary>
        /// Asserts that the ContentType is exactly the same as the expected ContentType, ignoring the casing.
        /// </summary>
        /// <param name="expectedContentType">The expected ContentType string.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public VirtualFileResultAssertions WithContentType(string expectedContentType, string reason = "", params object[] reasonArgs)
        {
            var actualContentType = ContentType;

            Execute.Assertion
                .ForCondition(string.Equals(actualContentType, expectedContentType, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .FailWith(string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.ContentType", expectedContentType, actualContentType));

            return this;
        }

        /// <summary>
        /// Asserts that the FileDownloadName is exactly the same as the expected FileDownloadName, ignoring the casing.
        /// </summary>
        /// <param name="expectedFileDownloadName">The expected FileDownloadName string.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public VirtualFileResultAssertions WithFileDownloadName(string expectedFileDownloadName, string reason = "", params object[] reasonArgs)
        {
            var actualFileDownloadName = FileDownloadName;

            Execute.Assertion
                .ForCondition(string.Equals(actualFileDownloadName, expectedFileDownloadName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .FailWith(string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.FileDownloadName", expectedFileDownloadName, actualFileDownloadName));

            return this;
        }

        /// <summary>
        /// Asserts that the LastModified is exactly the same as the expected LastModified, ignoring the casing.
        /// </summary>
        /// <param name="expectedLastModified">The expected LastModified string.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public VirtualFileResultAssertions WithLastModified(DateTimeOffset? expectedLastModified, string reason = "", params object[] reasonArgs)
        {
            var actualLastModified = LastModified;

            if (actualLastModified == null && expectedLastModified == null)
            {
                return this;
            }

            if (actualLastModified == null)
            {
                Execute.Assertion
                    .ForCondition(false)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.LastModified", expectedLastModified, null));

                return this;
            }

            if (expectedLastModified == null)
            {
                Execute.Assertion
                    .ForCondition(false)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.LastModified", null, actualLastModified));

                return this;
            }

            Execute.Assertion
                .ForCondition(DateTimeOffset.Compare(actualLastModified.Value, expectedLastModified.Value) == 0)
                .BecauseOf(reason, reasonArgs)
                .FailWith(string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.LastModified", expectedLastModified, actualLastModified));

            return this;
        }

        /// <summary>
        /// Asserts that the EntityTag is exactly the same as the expected EntityTag, ignoring the casing.
        /// </summary>
        /// <param name="expectedEntityTag">The expected EntityTag string.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public VirtualFileResultAssertions WithEntityTag(EntityTagHeaderValue expectedEntityTag, string reason = "", params object[] reasonArgs)
        {
            var actualEntityTag = EntityTag;

            Execute.Assertion
                .ForCondition(Equals(actualEntityTag, expectedEntityTag))
                .BecauseOf(reason, reasonArgs)
                .FailWith(string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.EntityTag", expectedEntityTag, actualEntityTag));

            return this;
        }

        #endregion
    }
}
