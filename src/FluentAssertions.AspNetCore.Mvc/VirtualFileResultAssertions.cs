using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="VirtualFileResult"/> is in the expected state.
    /// </summary>
    public class VirtualFileResultAssertions :  FileResultAssertionsBase<VirtualFileResult, VirtualFileResultAssertions>
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
        /// The <see cref="VirtualFileResult.FileName"/> on the tested subject.
        /// </summary>
        public string FileName => FileResultSubject.FileName;

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
        public VirtualFileResultAssertions WithVirtualPath(string expectedFileName, string reason = "", params object[] reasonArgs)
        {
            var actualFileName = FileName;

            Execute.Assertion
                .ForCondition(string.Equals(actualFileName, expectedFileName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("VirtualFileResult.VirtualPath")
                .FailWith(FailureMessages.CommonFailMessage, expectedFileName, actualFileName);

            return this;
        }

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
        public VirtualFileResultAssertions WithFileName(string expectedFileName, string reason = "", params object[] reasonArgs)
        {
            var actualFileName = FileName;

            Execute.Assertion
                .ForCondition(string.Equals(actualFileName, expectedFileName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("VirtualFileResult.FileName")
                .FailWith(FailureMessages.CommonFailMessage, expectedFileName, actualFileName);

            return this;
        }

        #endregion
    }
}
