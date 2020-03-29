using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    ///     Contains a number of methods to assert that a <see cref="PhysicalFileResult" /> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class PhysicalFileResultAssertions : FileResultAssertions
    {
        #region Public Constructors

        public PhysicalFileResultAssertions(PhysicalFileResult fileResult)
            : base(fileResult)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The <see cref="PhysicalFileResult.FileName">FileName</see> on the <see cref="PhysicalFileResult"/>
        /// </summary>
        public string FileName => PhysicalFileResultSubject.FileName;

        #endregion Private Properties

        #region Private Properties

        private PhysicalFileResult PhysicalFileResultSubject => (PhysicalFileResult)Subject;

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
            var actualFileName = PhysicalFileResultSubject.FileName;

            Execute.Assertion
                .ForCondition(string.Equals(expectedFileName, actualFileName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .FailWith(FailureMessages.CommonFailMessage, "PhysicalFileResult.FileName", expectedFileName, actualFileName);
            return this;
        }

        #endregion
    }
}
