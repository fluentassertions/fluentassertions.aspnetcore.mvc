using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Base class for <see cref="ObjectResultAssertions"/>.
    /// </summary>
    [DebuggerNonUserCode]
    public class ObjectResultAssertionsBase<TObjectResult, TObjectResultAssertion> : ObjectAssertions
        where TObjectResult : ObjectResult
        where TObjectResultAssertion : ObjectResultAssertionsBase<TObjectResult, TObjectResultAssertion>
    {
        #region Public Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public ObjectResultAssertionsBase(TObjectResult subject)
            : base(subject)
        {

        }
        #endregion

        #region Public Properties

        /// <summary>
        ///     The value on the ObjectResult
        /// </summary>
        public object Value => ObjectResultSubject.Value;

        #endregion

        #region Protected Properties

        /// <inheritdoc />
        protected override string Identifier => typeof(TObjectResult).Name;
        /// <summary>
        /// The <see cref="ReferenceTypeAssertions{TSubject, TAssertions}.Subject"/> casted to the correct type.
        /// </summary>
        protected TObjectResult ObjectResultSubject => (TObjectResult)Subject;

        #endregion

        #region Public Methods
        /// <summary>
        ///     Asserts the value is of the expected type.
        /// </summary>
        /// <typeparam name="TValue">The expected type.</typeparam>
        /// <returns>The typed value.</returns>
        public TValue ValueAs<TValue>()
        {
            var value = ObjectResultSubject.Value;

            if (value == null)
                Execute.Assertion
                    .WithDefaultIdentifier($"{Identifier}.Value")
                    .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(TValue));

            Execute.Assertion
                .ForCondition(value is TValue)
                .WithDefaultIdentifier($"{Identifier}.Value")
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(TValue), value.GetType());

            return (TValue)value;
        }
        #endregion

    }
}
