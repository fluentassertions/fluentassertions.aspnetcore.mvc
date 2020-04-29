using System.Diagnostics;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="BadRequestObjectResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class BadRequestObjectResultAssertions : ObjectAssertions
    {
        #region Public Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:BadRequestObjectResult" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public BadRequestObjectResultAssertions(BadRequestObjectResult subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties

        public object Error => BadRequestObjectResultSubject.Value;

        public SerializableError SerializableError => (SerializableError)BadRequestObjectResultSubject.Value;
        #endregion

        #region Private Properties
        private BadRequestObjectResult BadRequestObjectResultSubject => (BadRequestObjectResult) Subject;

        #endregion

        #region Public Methods
        /// <summary>
        ///     Asserts the error is of the expected type.
        /// </summary>
        /// <typeparam name="TError">The expected type.</typeparam>
        /// <returns>The typed error.</returns>
        public TError ErrorAs<TError>()
        {
            var error = Error;

            if (error == null)
                Execute.Assertion
                    .WithDefaultIdentifier("BadRequestObjectResult.Error")
                    .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(TError));

            Execute.Assertion
                .ForCondition(error is TError)
                .WithDefaultIdentifier("BadRequestObjectResult.Error")
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(TError), error.GetType());

            return (TError)error;
        }

        #endregion
    }
}
