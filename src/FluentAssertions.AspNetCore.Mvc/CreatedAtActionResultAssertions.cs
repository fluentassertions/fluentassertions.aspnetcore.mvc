using System;
using System.Diagnostics;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="CreatedAtActionResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class CreatedAtActionResultAssertions : ObjectAssertions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedAtActionResultAssertions" /> class.
        /// </summary>
        public CreatedAtActionResultAssertions(CreatedAtActionResult subject) : base(subject) { }

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
        public CreatedAtActionResultAssertions WithActionName(string expectedActionName, string reason = "", params object[] reasonArgs)
        {
            string actualActionName = (Subject as CreatedAtActionResult)?.ActionName;

            Execute.Assertion
                   .ForCondition(string.Equals(actualActionName, expectedActionName, StringComparison.OrdinalIgnoreCase))
                   .BecauseOf(reason, reasonArgs)
                   .WithDefaultIdentifier("CreatedAtActionResult.ActionName")
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
        public CreatedAtActionResultAssertions WithControllerName(string expectedControllerName, string reason = "", params object[] reasonArgs)
        {
            string actualControllerName = (Subject as CreatedAtActionResult)?.ControllerName;

            Execute.Assertion
                .ForCondition(string.Equals(actualControllerName, expectedControllerName, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("CreatedAtActionResult.ControllerName")
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
        public CreatedAtActionResultAssertions WithRouteValue(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            var subjectTyped = Subject as CreatedAtActionResult;

            AssertionHelpers.AssertStringObjectDictionary(subjectTyped.RouteValues, "CreatedAtActionResult.RouteValues",
                key, expectedValue, reason, reasonArgs);

            return this;
        }

        /// <summary>
        ///     Asserts the value is of the expected type.
        /// </summary>
        /// <typeparam name="TValue">The expected type.</typeparam>
        /// <returns>The typed value.</returns>
        public TValue ValueAs<TValue>()
        {
            var subjectTyped = Subject as CreatedAtActionResult;
            var value = subjectTyped.Value;

            if (value == null)
                Execute.Assertion
                    .WithDefaultIdentifier("CreatedAtActionResult.Value")
                    .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(TValue));

            Execute.Assertion
                .ForCondition(value is TValue)
                .WithDefaultIdentifier("CreatedAtActionResult.Value")
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(TValue), value.GetType());

            return (TValue)value;
        }
    }
}
