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
                Execute.Assertion
                    .WithDefaultIdentifier("CreatedResult.Value")
                    .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(TValue));

            Execute.Assertion
                .ForCondition(value is TValue)
                .WithDefaultIdentifier("CreatedResult.Value")
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(TValue), value.GetType());

            return (TValue)value;
        }

        /// <summary>
        ///     Asserts the uri has the expected value.
        /// </summary>
        /// <param name="uri">
        /// The Uri.
        /// </param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        /// <returns>The typed value.</returns>
        public CreatedResultAssertions WithUri(Uri uri, string reason = "", params object[] reasonArgs)
        {
            var expectedUri = AssertionHelpers.GetAbsoluteUri(uri);

            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(expectedUri == Location)
                .WithDefaultIdentifier("CreatedResult.Uri")
                .FailWith(FailureMessages.CommonFailMessage, expectedUri, Location);

            return this;
        }

        /// <summary>
        ///     Asserts the uri has the expected value.
        /// </summary>
        /// <param name="uri">
        /// The Uri as string.
        /// </param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        /// <returns>The typed value.</returns>
        public CreatedResultAssertions WithUri(string uri, string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(uri == Location)
                .WithDefaultIdentifier("CreatedResult.Uri")
                .FailWith(FailureMessages.CommonFailMessage, uri, Location);

            return this;
        }

        #endregion
    }
}
