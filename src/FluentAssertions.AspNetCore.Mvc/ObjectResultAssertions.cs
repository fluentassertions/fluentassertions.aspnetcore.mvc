using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="ObjectResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class ObjectResultAssertions : ObjectResultAssertionsBase<ObjectResult, ObjectResultAssertions>
    {
        #region Public Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public ObjectResultAssertions(ObjectResult subject)
            : base(subject)
        {

        }
        #endregion
    }
}
