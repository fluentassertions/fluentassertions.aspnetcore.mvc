using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Net.Http.Headers;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Base class for <see cref="FileResultAssertions"/>, <see cref="FileContentResultAssertions"/>, 
    /// <see cref="PhysicalFileResultAssertions"/>, <see cref="VirtualFileResultAssertions"/> and
    /// <see cref="FileStreamResultAssertions"/>.
    /// </summary>
    /// <typeparam name="TFileResult">The type of the testet FileResult variant.</typeparam>
    /// <typeparam name="TFileResultAssertions">The subclass of this class.</typeparam>
    public class FileResultAssertionsBase<TFileResult, TFileResultAssertions> : ObjectAssertions
        where TFileResult : FileResult
        where TFileResultAssertions : FileResultAssertionsBase<TFileResult, TFileResultAssertions>
    {
        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        /// <param name="fileResult">The testet instance.</param>
        protected FileResultAssertionsBase(TFileResult fileResult)
            : base(fileResult)
        {
            Identifier = typeof(TFileResult).Name;
        }

        #region Private Properties

        /// <summary>
        /// The <see cref="FileResult"/> under test.
        /// </summary>
        protected TFileResult FileResultSubject => (TFileResult)Subject;

        #endregion Private Properties

        /// <summary>
        /// Returns the type of the subject the assertion applies on.
        /// </summary>
        protected override string Identifier { get; }

        #region Public Properties
        /// <summary>
        /// The <see cref="FileResult.ContentType">ContentType</see> on the <see cref="FileResult"/>.
        /// </summary>
        public string ContentType => FileResultSubject.ContentType;
        /// <summary>
        /// The <see cref="FileResult.FileDownloadName">ContentType</see> on the <see cref="FileResult"/>.
        /// </summary>
        public string FileDownloadName => FileResultSubject.FileDownloadName;
        /// <summary>
        /// The <see cref="FileResult.LastModified">ContentType</see> on the <see cref="FileResult"/>.
        /// </summary>
        public DateTimeOffset? LastModified => FileResultSubject.LastModified;
        /// <summary>
        /// The <see cref="FileResult.EntityTag">ContentType</see> on the <see cref="FileResult"/>.
        /// </summary>
        public EntityTagHeaderValue EntityTag => FileResultSubject.EntityTag;

        #endregion

        #region Public Methods

        /// <summary>
        ///     Asserts that the content type is the expected string.
        /// </summary>
        /// <param name="expectedContentType">The expected content type.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TFileResultAssertions WithContentType(string expectedContentType, string reason = "",
            params object[] reasonArgs)
        {
            var actualContentType = FileResultSubject.ContentType;

            Execute.Assertion
                .ForCondition(string.Equals(expectedContentType, actualContentType, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier($"{Identifier}.ContentType")
                .FailWith(FailureMessages.CommonFailMessage, expectedContentType, actualContentType);
            return (TFileResultAssertions)this;
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
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TFileResultAssertions WithEntityTag(EntityTagHeaderValue expectedEntityTag, string reason = "",
            params object[] reasonArgs)
        {
            var actualEntityTag = FileResultSubject.EntityTag;

            Execute.Assertion
                .ForCondition(Equals(expectedEntityTag, actualEntityTag))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier($"{Identifier}.EntityTag")
                .FailWith(FailureMessages.CommonFailMessage, expectedEntityTag, actualEntityTag);
            return (TFileResultAssertions)this;
        }

        /// <summary>
        ///     Asserts that the file download name is the expected string.
        /// </summary>
        /// <param name="expectedFileDownloadName">The expected file download name.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TFileResultAssertions WithFileDownloadName(string expectedFileDownloadName, string reason = "",
            params object[] reasonArgs)
        {
            var actualFileDownloadName = FileResultSubject.FileDownloadName;

            Execute.Assertion
                .ForCondition(string.Equals(expectedFileDownloadName, actualFileDownloadName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier($"{Identifier}.FileDownloadName")
                .FailWith(FailureMessages.CommonFailMessage, expectedFileDownloadName, actualFileDownloadName);
            return (TFileResultAssertions)this;
        }

        /// <summary>
        ///     Asserts that the last modified is the expected DateTimeOffset.
        /// </summary>
        /// <param name="expectedLastModified">The expected last modified value.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TFileResultAssertions WithLastModified(DateTimeOffset? expectedLastModified, string reason = "",
            params object[] reasonArgs)
        {
            var actualLastModified = FileResultSubject.LastModified;

            Execute.Assertion
                .ForCondition(expectedLastModified == actualLastModified)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier($"{Identifier}.LastModified")
                .FailWith(FailureMessages.CommonFailMessage, expectedLastModified, actualLastModified);
            return (TFileResultAssertions)this;
        }

        #endregion
    }
}
