using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    ///     Contains a number of methods to assert that a <see cref="FileResult" /> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class FileResultAssertions : FileResultAssertionsBase<FileResult, FileResultAssertions>
    {
        #region Public Constructors

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        /// <param name="fileResult">The testet instance.</param>
        public FileResultAssertions(FileResult fileResult)
            : base(fileResult)
        {
        }

        #endregion
    }
}
