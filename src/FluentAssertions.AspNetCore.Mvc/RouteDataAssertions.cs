using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="RouteData"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
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
        /// Asserts that the route data has the expected area name.
        /// </summary>
        /// <param name="expectedAreaName">The expected area name.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public RouteDataAssertions HaveArea(string expectedAreaName, string reason = "", params object[] reasonArgs)
        {
            HaveValue("area", expectedAreaName, reason, reasonArgs);
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

            AssertionHelpers.AssertStringObjectDictionary(subjectTyped.DataTokens, "RouteData.DataTokens", key, expectedValue, reason, reasonArgs);

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

            AssertionHelpers.AssertStringObjectDictionary(subjectTyped.Values, "RouteData.Values", key, expectedValue, reason, reasonArgs);

            return this;
        }
    }
}
