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
    public class AcceptedAtActionResultAssertions : ObjectAssertions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AcceptedAtActionResultAssertions" /> class.
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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public AcceptedAtActionResultAssertions WithActionName(string expectedActionName, string reason = "", params object[] reasonArgs)
        {
            string actualActionName = (Subject as AcceptedAtActionResult)?.ActionName;

            Execute.Assertion
                   .ForCondition(string.Equals(actualActionName, expectedActionName, StringComparison.OrdinalIgnoreCase))
                   .BecauseOf(reason, reasonArgs)
                   .FailWith("Expected AcceptedAtActionResult.ActionName to be {0}{reason} but was {1}", expectedActionName, actualActionName);

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public AcceptedAtActionResultAssertions WithControllerName(string expectedControllerName, string reason = "", params object[] reasonArgs)
        {
            string actualControllerName = (Subject as AcceptedAtActionResult)?.ControllerName;

            Execute.Assertion
                .ForCondition(string.Equals(actualControllerName, expectedControllerName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .FailWith("Expected AcceptedAtActionResult.ControllerName to be {0}{reason} but was {1}", expectedControllerName, actualControllerName);

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
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public AcceptedAtActionResultAssertions WithRouteValue(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            var subjectTyped = Subject as AcceptedAtActionResult;

            Execute.Assertion
                .ForCondition(subjectTyped != null && subjectTyped.RouteValues.ContainsKey(key))
                .BecauseOf(reason, reasonArgs)
                .FailWith(FailureMessages.AcceptedAtActionResult_RouteValues_ContainsKey, key);

            var actualValue = subjectTyped.RouteValues[key];

            Execute.Assertion
                .ForCondition(expectedValue.Equals(actualValue))
                .BecauseOf(reason, reasonArgs)
                .FailWith(FailureMessages.AcceptedAtActionResult_RouteValues_HaveValue, key, expectedValue, actualValue);

            return this;
        }

        /// <summary>
        ///     Asserts the value is of the expected type.
        /// </summary>
        /// <typeparam name="TValue">The expected type.</typeparam>
        /// <returns>The typed value.</returns>
        public TValue ValueAs<TValue>()
        {
            var subjectTyped = Subject as AcceptedAtActionResult;
            var value = subjectTyped.Value;

            if (value == null)
                Execute.Assertion.FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, "AcceptedAtActionResult.Value", typeof(TValue).Name);

            Execute.Assertion
                .ForCondition(value is TValue)
                .FailWith(FailureMessages.CommonTypeFailMessage, "AcceptedAtActionResult.Value", typeof(TValue).Name, value.GetType().Name);

            return (TValue)value;
        }
    }
}
