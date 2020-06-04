using System.Diagnostics;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="OkObjectResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class OkObjectResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:OkObjectResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public OkObjectResultAssertions(OkObjectResult subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties
        /// <summary>
        ///     The value on the OkObjectResult
        /// </summary>
        public object Value => OkObjectResultSubject.Value;

        #endregion

        #region Private Properties
        private OkObjectResult OkObjectResultSubject => (OkObjectResult)Subject;

        #endregion

        #region Public Methods
        /// <summary>
        ///     Asserts the value is of the expected type.
        /// </summary>
        /// <typeparam name="TValue">The expected type.</typeparam>
        /// <returns>The typed value.</returns>
        public TValue ValueAs<TValue>()
        {
            var value = OkObjectResultSubject.Value;

            if (value == null)
                Execute.Assertion
                    .WithDefaultIdentifier("OkObjectResult.Value")
                    .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(TValue));

            Execute.Assertion
                .ForCondition(value is TValue)
                .WithDefaultIdentifier("OkObjectResult.Value")
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(TValue), value.GetType());

            return (TValue)value;
        }
        #endregion
    }
}
