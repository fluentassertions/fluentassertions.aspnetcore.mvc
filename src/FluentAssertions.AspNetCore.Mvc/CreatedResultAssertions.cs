using System;
using System.Diagnostics;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="CreatedResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class CreatedResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:CreatedResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public CreatedResultAssertions(CreatedResult subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties
        /// <summary>
        ///     The value on the CreatedResult
        /// </summary>
        public object Value => CreatedResultSubject.Value;

        public string Location => CreatedResultSubject.Location;

        #endregion

        #region Private Properties
        private CreatedResult CreatedResultSubject => (CreatedResult)Subject;

        #endregion

        #region Public Methods
        /// <summary>
        ///     Asserts the value is of the expected type.
        /// </summary>
        /// <typeparam name="TValue">The expected type.</typeparam>
        /// <returns>The typed value.</returns>
        public TValue ValueAs<TValue>()
        {
            var value = CreatedResultSubject.Value;

            if (value == null)
                Execute.Assertion.FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, "CreatedResult.Value", typeof(TValue).Name);

            Execute.Assertion
                .ForCondition(value is TValue)
                .FailWith(FailureMessages.CommonTypeFailMessage, "CreatedResult.Value", typeof(TValue).Name, value.GetType().Name);

            return (TValue)value;
        }

        /// <summary>
        ///     Asserts the uri has the expected value.
        /// </summary>
        /// <param name="uri">
        /// The Uri.
        /// </param>
        /// <returns>The typed value.</returns>
        public CreatedResultAssertions WithUri(Uri uri)
        {
            var expectedUri = !uri.IsAbsoluteUri 
                ? uri.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped) 
                : uri.AbsoluteUri;

            Execute.Assertion
                .ForCondition(expectedUri == Location)
                .FailWith(FailureMessages.CommonFailMessage, "CreatedResult.Uri", expectedUri, Location);

            return this;
        }

        /// <summary>
        ///     Asserts the uri has the expected value.
        /// </summary>
        /// <param name="uri">
        /// The Uri as string.
        /// </param>
        /// <returns>The typed value.</returns>
        public CreatedResultAssertions WithUri(string uri)
        {
            Execute.Assertion
                .ForCondition(uri == Location)
                .FailWith(FailureMessages.CommonFailMessage, "CreatedResult.Uri", uri, Location);

            return this;
        }

        #endregion
    }
}
