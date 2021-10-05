using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="ConflictObjectResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class ConflictObjectResultAssertions : ObjectAssertions
    {
        #region Public Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConflictObjectResult" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public ConflictObjectResultAssertions(ConflictObjectResult subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The <see cref="ObjectResult.Value"/> property on the the tested <see cref="ConflictObjectResult"/>.
        /// </summary>
        public object Error => ConflictObjectResultSubject.Value;

        /// <summary>
        /// The <see cref="ObjectResult.Value"/> property as <see cref="Microsoft.AspNetCore.Mvc.SerializableError"/> on the the tested <see cref="ConflictObjectResult"/>.
        /// </summary>
        public SerializableError SerializableError => (SerializableError)ConflictObjectResultSubject.Value;
        #endregion

        #region Private Properties
        private ConflictObjectResult ConflictObjectResultSubject => (ConflictObjectResult)Subject;

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
                    .WithDefaultIdentifier("ConflictObjectResult.Error")
                    .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(TError));

            Execute.Assertion
                .ForCondition(error is TError)
                .WithDefaultIdentifier("ConflictObjectResult.Error")
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(TError), error.GetType());

            return (TError)error;
        }

        #endregion
    }
}
