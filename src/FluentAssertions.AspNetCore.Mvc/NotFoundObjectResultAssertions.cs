using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="NotFoundObjectResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class NotFoundObjectResultAssertions : ObjectResultAssertionsBase<NotFoundObjectResult, NotFoundObjectResultAssertions>
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="NotFoundObjectResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public NotFoundObjectResultAssertions(NotFoundObjectResult subject) : base(subject)
        {
        }

        #endregion
    }
}
