using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="AcceptedAtRouteResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class AcceptedAtRouteResultAssertions : ObjectResultAssertionsBase<AcceptedAtRouteResult, AcceptedAtRouteResultAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AcceptedAtRouteResultAssertions" /> class.
        /// </summary>
        public AcceptedAtRouteResultAssertions(AcceptedAtRouteResult subject) : base(subject) { }

        /// <summary>
        /// Asserts that the redirect has the expected route name.
        /// </summary>
        /// <param name="expectedRouteName">The expected route name.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public AcceptedAtRouteResultAssertions WithRouteName(string expectedRouteName, string reason = "", params object[] reasonArgs)
        {
            var actualRouteName = ObjectResultSubject.RouteName;

            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(string.Equals(expectedRouteName, actualRouteName, StringComparison.OrdinalIgnoreCase))
                .WithDefaultIdentifier("AcceptedAtRouteResult.RouteName")
                .FailWith(FailureMessages.CommonFailMessage, expectedRouteName, actualRouteName);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected route value.
        /// </summary>
        /// <param name="key">The expected key.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public AcceptedAtRouteResultAssertions WithRouteValue(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            var actualRouteValues = ObjectResultSubject.RouteValues;

            AssertionHelpers.AssertStringObjectDictionary(actualRouteValues,
                "AcceptedAtRouteResult.RouteValues", key, expectedValue, reason, reasonArgs);

            return this;
        }
    }
}
