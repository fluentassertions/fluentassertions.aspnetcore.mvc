using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Diagnostics;

namespace FluentAssertions.Mvc
{
    [DebuggerNonUserCode]
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="RouteData"/> is in the expected state.
    /// </summary>
    public class RouteDataAssertions : ObjectAssertions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RouteDataAssertions" /> class.
        /// </summary>
        public RouteDataAssertions(RouteData subject)
            : base(subject)
        {
            Subject = subject;
        }

        /// <summary>
        /// Asserts that the route data has the expected controller name.
        /// </summary>
        /// <param name="expectedControllerName">The expected controller name.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RouteDataAssertions HaveController(string expectedControllerName, string reason = "", params object[] reasonArgs)
        {
            HaveValue("controller", expectedControllerName, reason, reasonArgs);
            return this;
        }

        /// <summary>
        /// Asserts that the route data has the expected action name.
        /// </summary>
        /// <param name="expectedActionName">The expected action name.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RouteDataAssertions HaveAction(string expectedActionName, string reason = "", params object[] reasonArgs)
        {
            HaveValue("action", expectedActionName, reason, reasonArgs);
            return this;
        }

        /// <summary>
        /// Asserts that the route data has the expected data token.
        /// </summary>
        /// <param name="key">The expected data token key value.</param>
        /// <param name="expectedValue">The expected data token value.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RouteDataAssertions HaveDataToken(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            var subjectTyped = Subject as RouteData;

            Execute.Assertion
                    .ForCondition(subjectTyped.DataTokens.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.RouteData_DataTokens_ContainsKey, key);

            var actualValue = subjectTyped.DataTokens[key];

            Execute.Assertion
                    .ForCondition(expectedValue.Equals(actualValue))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.RouteData_DataTokens_HaveValue, key, expectedValue, actualValue);

            return this;
        }

        /// <summary>
        /// Asserts that the route data has the expected value.
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
        public RouteDataAssertions HaveValue(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            var subjectTyped = Subject as RouteData;

            Execute.Assertion
                    .ForCondition(subjectTyped.Values.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.RouteData_Values_ContainsKey, key);

            var actualValue = subjectTyped.Values[key];

            Execute.Assertion
                    .ForCondition(expectedValue.Equals(actualValue))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.RouteData_Values_HaveValue, key, expectedValue, actualValue);

            return this;
        }
    }
}
