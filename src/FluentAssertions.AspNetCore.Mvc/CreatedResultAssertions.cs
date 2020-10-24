using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="CreatedResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class CreatedResultAssertions : ObjectResultAssertionsBase<CreatedResult, CreatedResultAssertions>
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="CreatedResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public CreatedResultAssertions(CreatedResult subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties
        /// <summary>
        ///     The location on the CreatedResult.
        /// </summary>
        public string Location => ObjectResultSubject.Location;

        #endregion

        #region Public Methods
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
