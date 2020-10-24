using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="OkObjectResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class OkObjectResultAssertions : ObjectResultAssertionsBase<OkObjectResult, OkObjectResultAssertions>
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="OkObjectResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public OkObjectResultAssertions(OkObjectResult subject) : base(subject)
        {
        }

        #endregion
    }
}
