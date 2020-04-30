using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    ///     Contains a number of methods to assert that a <see cref="FileContentResult" /> is in the expected state.
    /// </summary>>
    [DebuggerNonUserCode]
    public class FileContentResultAssertions : FileResultAssertionsBase<FileContentResult, FileContentResultAssertions>
    {
        #region Public Constructors

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        /// <param name="fileResult">The testet instance.</param>
        public FileContentResultAssertions(FileContentResult fileResult) 
            : base(fileResult)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The <see cref="FileContentResult.FileContents"/> on the tested subject.
        /// </summary>
        [SuppressMessage("Performance", "CA1819:Properties should not return arrays",
            Justification = "It needs to return the same instance as FileContentResult")]
        public byte[] FileContents => FileResultSubject.FileContents;

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Asserts that the file contents is the expected bytes.
        /// </summary>
        /// <param name="expectedFileContents">The expected file contents.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        internal FileContentResultAssertions WithFileContents(byte[] expectedFileContents, string reason = "",
           params object[] reasonArgs)
        {
            var actualFileContents = FileResultSubject.FileContents;

            Execute.Assertion
                .ForCondition(expectedFileContents.Length == actualFileContents.Length)
                .BecauseOf(reason, reasonArgs)
                .FailWith(FailureMessages.FileContentResult_WithFileContents_LengthFail, expectedFileContents.Length, actualFileContents.Length);
            for (int i = 0; i < expectedFileContents.Length; i++)
            {
                var expectedByte = expectedFileContents[i];
                var actualByte = actualFileContents[i];
                Execute.Assertion
                    .ForCondition(expectedByte == actualByte)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.FileContentResult_WithFileContents_MatchFail, i, expectedByte, actualByte);
            }

            return this;
        }

        #endregion
    }
}
