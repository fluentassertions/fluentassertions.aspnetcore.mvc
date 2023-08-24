using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    ///     Contains a number of methods to assert that a <see cref="PageResult" /> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class PageResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PageResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public PageResultAssertions(PageResult subject) : base(subject)
        {
        }

        #endregion Public Constructors
    }
}