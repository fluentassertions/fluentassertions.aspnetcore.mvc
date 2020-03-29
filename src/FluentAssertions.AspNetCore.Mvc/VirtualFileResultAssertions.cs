using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    ///     Contains a number of methods to assert that a <see cref="VirtualFileResult" /> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class VirtualFileResultAssertions : FileResultAssertions
    {
        #region Public Constructors

        public VirtualFileResultAssertions(VirtualFileResult fileResult)
            : base(fileResult)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The <see cref="VirtualFileResult.FileName">FileName</see> on the <see cref="VirtualFileResult"/>
        /// </summary>
        public string FileName => VirtualFileResultSubject.FileName;

        #endregion Private Properties

        #region Private Properties

        private VirtualFileResult VirtualFileResultSubject => (VirtualFileResult)Subject;

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Asserts that the file name is the expected string.
        /// </summary>
        /// <param name="expectedFileName">The expected file name.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public FileResultAssertions WithFileName(string expectedFileName, string reason = "",
            params object[] reasonArgs)
        {
            var actualFileName = VirtualFileResultSubject.FileName;

            Execute.Assertion
                .ForCondition(string.Equals(expectedFileName, actualFileName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .FailWith(FailureMessages.CommonFailMessage, "VirtualFileResult.FileName", expectedFileName, actualFileName);
            return this;
        }

        #endregion
    }
}
