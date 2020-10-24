using System;
using System.Diagnostics;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="AcceptedAtActionResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class AcceptedAtActionResultAssertions : ObjectResultAssertionsBase<AcceptedAtActionResult, AcceptedAtActionResultAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AcceptedAtActionResultAssertions" /> class.
        /// </summary>
        public AcceptedAtActionResultAssertions(AcceptedAtActionResult subject) : base(subject) { }

        /// <summary>
        /// Asserts that the action name is the expected action.
        /// </summary>
        /// <param name="expectedActionName">The expected action.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public AcceptedAtActionResultAssertions WithActionName(string expectedActionName, string reason = "", params object[] reasonArgs)
        {
            string actualActionName = ObjectResultSubject?.ActionName;

            Execute.Assertion
                   .ForCondition(string.Equals(actualActionName, expectedActionName, StringComparison.OrdinalIgnoreCase))
                   .BecauseOf(reason, reasonArgs)
                   .WithDefaultIdentifier("AcceptedAtActionResult.ActionName")
                   .FailWith(FailureMessages.CommonFailMessage, expectedActionName, actualActionName);

            return this;
        }

        /// <summary>
        /// Asserts that the controller name is the expected controller.
        /// </summary>
        /// <param name="expectedControllerName">The expected controller.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public AcceptedAtActionResultAssertions WithControllerName(string expectedControllerName, string reason = "", params object[] reasonArgs)
        {
            string actualControllerName = ObjectResultSubject?.ControllerName;

            Execute.Assertion
                .ForCondition(string.Equals(actualControllerName, expectedControllerName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("AcceptedAtActionResult.ControllerName")
                .FailWith(FailureMessages.CommonFailMessage, expectedControllerName, actualControllerName);

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
        public AcceptedAtActionResultAssertions WithRouteValue(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            var actualRouteValues = ObjectResultSubject.RouteValues;

            AssertionHelpers.AssertStringObjectDictionary(actualRouteValues,
                "AcceptedAtActionResult.RouteValues", key, expectedValue, reason, reasonArgs);

            return this;
        }
    }
}
