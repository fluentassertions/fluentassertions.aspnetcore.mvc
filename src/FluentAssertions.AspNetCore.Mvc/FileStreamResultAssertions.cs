using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    ///     Contains a number of methods to assert that a <see cref="FileStreamResult" /> is in the expected state.
    /// </summary>>
    [DebuggerNonUserCode]
    public class FileStreamResultAssertions : FileResultAssertions
    {
        #region Public Constructors

        public FileStreamResultAssertions(FileStreamResult fileResult) 
            : base(fileResult)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The <see cref="FileStreamResult.FileStream">FileStream</see> on the <see cref="FileStreamResult"/>
        /// </summary>
        public Stream FileStream => FileStreamResultSubject.FileStream;

        #endregion

        #region Private Properties

        private FileStreamResult FileStreamResultSubject => (FileStreamResult)Subject;

        #endregion Private Properties

    }
}
