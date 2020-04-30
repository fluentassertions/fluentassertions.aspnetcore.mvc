using System;
using System.Diagnostics;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="PhysicalFileResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class PhysicalFileResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:PhysicalFileResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public PhysicalFileResultAssertions(PhysicalFileResult subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties
        /// <summary>
        ///     The value on the PhysicalFileResult
        /// </summary>
        public string FileName => PhysicalFileResultSubject.FileName;
        public string ContentType => PhysicalFileResultSubject.ContentType;
        public string FileDownloadName => PhysicalFileResultSubject.FileDownloadName;
        public DateTimeOffset? LastModified => PhysicalFileResultSubject.LastModified;
        public EntityTagHeaderValue EntityTag => PhysicalFileResultSubject.EntityTag;

        #endregion

        #region Private Properties
        private PhysicalFileResult PhysicalFileResultSubject => (PhysicalFileResult)Subject;

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
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public PhysicalFileResultAssertions WithPhysicalPath(string expectedFileName, string reason = "", params object[] reasonArgs)
        {
            var actualFileName = FileName;

            Execute.Assertion
                .ForCondition(string.Equals(actualFileName, expectedFileName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("PhysicalFileResult.PhysicalPath")
                .FailWith(FailureMessages.CommonFailMessage, expectedFileName, actualFileName);

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
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public PhysicalFileResultAssertions WithContentType(string expectedContentType, string reason = "", params object[] reasonArgs)
        {
            var actualContentType = ContentType;

            Execute.Assertion
                .ForCondition(string.Equals(actualContentType, expectedContentType, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("PhysicalFileResult.ContentType")
                .FailWith(FailureMessages.CommonFailMessage, expectedContentType, actualContentType);

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
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public PhysicalFileResultAssertions WithFileDownloadName(string expectedFileDownloadName, string reason = "", params object[] reasonArgs)
        {
            var actualFileDownloadName = FileDownloadName;

            Execute.Assertion
                .ForCondition(string.Equals(actualFileDownloadName, expectedFileDownloadName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("PhysicalFileResult.FileDownloadName")
                .FailWith(FailureMessages.CommonFailMessage, expectedFileDownloadName, actualFileDownloadName);

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
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public PhysicalFileResultAssertions WithLastModified(DateTimeOffset? expectedLastModified, string reason = "",
            params object[] reasonArgs)
        {
            var actualLastModified = LastModified;

            Execute.Assertion
                .ForCondition(expectedLastModified == actualLastModified)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("PhysicalFileResult.LastModified")
                .FailWith(FailureMessages.CommonFailMessage, expectedLastModified, actualLastModified);
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
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public PhysicalFileResultAssertions WithEntityTag(EntityTagHeaderValue expectedEntityTag, string reason = "", params object[] reasonArgs)
        {
            var actualEntityTag = EntityTag;

            Execute.Assertion
                .ForCondition(Equals(actualEntityTag, expectedEntityTag))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("PhysicalFileResult.EntityTag")
                .FailWith(FailureMessages.CommonFailMessage, expectedEntityTag, actualEntityTag);
            return this;
        }

        #endregion
    }
}
