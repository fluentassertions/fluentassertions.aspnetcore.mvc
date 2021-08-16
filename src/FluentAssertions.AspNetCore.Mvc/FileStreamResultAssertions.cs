using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    ///     Contains a number of methods to assert that a <see cref="FileStreamResult" /> is in the expected state.
    /// </summary>>
    [DebuggerNonUserCode]
    public class FileStreamResultAssertions : FileResultAssertionsBase<FileStreamResult, FileStreamResultAssertions>
    {
        #region Public Constructors

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        /// <param name="fileResult">The testet instance.</param>
        public FileStreamResultAssertions(FileStreamResult fileResult)
            : base(fileResult)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The <see cref="FileStreamResult.FileStream">FileStream</see> on the <see cref="FileStreamResult"/>
        /// </summary>
        public Stream FileStream => FileResultSubject.FileStream;

        #endregion
    }
}
