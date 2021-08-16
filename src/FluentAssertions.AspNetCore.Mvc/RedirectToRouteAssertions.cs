using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="RedirectToRouteResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class RedirectToRouteAssertions : ReferenceTypeAssertions<RedirectToRouteResult, RedirectToRouteAssertions>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentResultAssertions" /> class.
        /// </summary>
        public RedirectToRouteAssertions(RedirectToRouteResult subject) : base(subject)
        {
        }

        #endregion Public Constructors

        #region Protected Properties

        /// <summary>
        /// Returns the type of the subject the assertion applies on.
        /// </summary>
        protected override string Identifier => "RedirectToRouteResult";

        #endregion Protected Properties

        #region Public Methods

        /// <summary>
        /// Asserts that the redirect is permanent.
        /// </summary>
        /// <param name="expectedPermanent">Should the redirect be permanent.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public RedirectToRouteAssertions WithPermanent(bool expectedPermanent, string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(expectedPermanent == Subject.Permanent)
                    .WithDefaultIdentifier("RedirectToRoute.Permanent")
                    .FailWith(FailureMessages.CommonFailMessage, expectedPermanent, Subject.Permanent);
            return this;
        }

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
        public RedirectToRouteAssertions WithRouteName(string expectedRouteName, string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                   .BecauseOf(reason, reasonArgs)
                   .ForCondition(string.Equals(expectedRouteName, Subject.RouteName, StringComparison.OrdinalIgnoreCase))
                   .WithDefaultIdentifier("RedirectToRoute.RouteName")
                   .FailWith(FailureMessages.CommonFailMessage, expectedRouteName, Subject.RouteName);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected route value.
        /// </summary>
        /// <param name="key">The expected route value key.</param>
        /// <param name="expectedValue">The expected route value.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public RedirectToRouteAssertions WithRouteValue(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            var routeValues = Subject.RouteValues;

            AssertionHelpers.AssertStringObjectDictionary(routeValues, "RedirectToRouteResult.RouteValues", key, expectedValue, reason, reasonArgs);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected controller name.
        /// </summary>
        /// <param name="expectedControllerName">The expected controller name.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public RedirectToRouteAssertions WithController(string expectedControllerName, string reason = "", params object[] reasonArgs)
        {
            WithRouteValue("Controller", expectedControllerName, reason, reasonArgs);
            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected action.
        /// </summary>
        /// <param name="expectedAction">The expected action.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public RedirectToRouteAssertions WithAction(string expectedAction, string reason = "", params object[] reasonArgs)
        {
            WithRouteValue("Action", expectedAction, reason, reasonArgs);
            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected area.
        /// </summary>
        /// <param name="expectedArea">The expected area.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public RedirectToRouteAssertions WithArea(string expectedArea, string reason = "", params object[] reasonArgs)
        {
            WithRouteValue("Area", expectedArea, reason, reasonArgs);
            return this;
        }

        #endregion Public Methods
    }
}