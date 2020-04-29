using System;
using System.Diagnostics;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="AcceptedResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class AcceptedResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:AcceptedResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public AcceptedResultAssertions(AcceptedResult subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties
        /// <summary>
        ///     The value on the AcceptedResult
        /// </summary>
        public object Value => AcceptedResultSubject.Value;

        public string Location => AcceptedResultSubject.Location;

        #endregion

        #region Private Properties
        private AcceptedResult AcceptedResultSubject => (AcceptedResult)Subject;

        #endregion

        #region Public Methods
        /// <summary>
        ///     Asserts the value is of the expected type.
        /// </summary>
        /// <typeparam name="TValue">The expected type.</typeparam>
        /// <returns>The typed value.</returns>
        public TValue ValueAs<TValue>()
        {
            var value = AcceptedResultSubject.Value;

            if (value == null)
                Execute.Assertion
                    .WithDefaultIdentifier("AcceptedResultAssertions.Value")
                    .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(TValue));

            Execute.Assertion
                .ForCondition(value is TValue)
                .WithDefaultIdentifier("AcceptedResultAssertions.Value")
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(TValue), value.GetType());

            return (TValue)value;
        }

        /// <summary>
        ///     Asserts the uri has the expected value.
        /// </summary>
        /// <param name="uri">
        /// The Uri.
        /// </param>
        /// <returns>The typed value.</returns>
        public AcceptedResultAssertions WithUri(Uri uri, string reason = "", params object[] reasonArgs)
        {
            var expectedUri = !uri.IsAbsoluteUri 
                ? uri.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped) 
                : uri.AbsoluteUri;

            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(expectedUri == Location)
                .WithDefaultIdentifier("AcceptedResultAssertions.Uri")
                .FailWith(FailureMessages.CommonFailMessage, expectedUri, Location);

            return this;
        }

        /// <summary>
        ///     Asserts the uri has the expected value.
        /// </summary>
        /// <param name="uri">
        /// The Uri as string.
        /// </param>
        /// <returns>The typed value.</returns>
        public AcceptedResultAssertions WithUri(string uri, string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(uri == Location)
                .WithDefaultIdentifier("AcceptedResultAssertions.Uri")
                .FailWith(FailureMessages.CommonFailMessage, uri, Location);

            return this;
        }

        #endregion
    }
}
