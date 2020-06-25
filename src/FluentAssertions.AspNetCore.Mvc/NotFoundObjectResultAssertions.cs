using System.Diagnostics;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="NotFoundObjectResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class NotFoundObjectResultAssertions : ObjectAssertions
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

        #region Public Properties
        /// <summary>
        ///     The value on the NotFoundObjectResult
        /// </summary>
        public object Value => NotFoundObjectResultSubject.Value;

        #endregion

        #region Private Properties
        private NotFoundObjectResult NotFoundObjectResultSubject => (NotFoundObjectResult)Subject;

        #endregion

        #region Public Methods
        /// <summary>
        ///     Asserts the value is of the expected type.
        /// </summary>
        /// <typeparam name="TValue">The expected type.</typeparam>
        /// <returns>The typed value.</returns>
        public TValue ValueAs<TValue>()
        {
            var value = NotFoundObjectResultSubject.Value;

            if (value == null)
                Execute.Assertion
                    .WithDefaultIdentifier("NotFoundObjectResult.Value")
                    .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(TValue));

            Execute.Assertion
                .ForCondition(value is TValue)
                .WithDefaultIdentifier("NotFoundObjectResult.Value")
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(TValue), value.GetType());

            return (TValue)value;
        }
        #endregion
    }
}
