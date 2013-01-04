using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
{
    [DebuggerNonUserCode]
    public class RouteDataAssertions : ObjectAssertions
    {
        public RouteDataAssertions(RouteData subject)
            : base(subject)
        {
            Subject = subject;
        }

        public RouteDataAssertions HaveController(string expectedControllerName)
        {
            HaveController(expectedControllerName, string.Empty, null);
            return this;
        }

        public RouteDataAssertions HaveController(string expectedControllerName, string reason, params object[] reasonArgs)
        {
            HaveValue("controller", expectedControllerName, reason, reasonArgs);
            return this;
        }

        public RouteDataAssertions HaveAction(string expectedActionName)
        {
            HaveAction(expectedActionName, string.Empty, null);
            return this;
        }

        public RouteDataAssertions HaveAction(string expectedActionName, string reason, params object[] reasonArgs)
        {
            HaveValue("action", expectedActionName, reason, reasonArgs);
            return this;
        }

        public RouteDataAssertions HaveDataToken(string key, object expectedValue)
        {
            HaveDataToken(key, expectedValue, string.Empty, null);
            return this;
        }

        public RouteDataAssertions HaveDataToken(string key, object expectedValue, string reason, params object[] reasonArgs)
        {
            var subjectTyped = Subject as RouteData;

            Execute.Verification
                    .ForCondition(subjectTyped.DataTokens.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.RouteData_DataTokens_ContainsKey, key);

            var actualValue = subjectTyped.DataTokens[key];

            Execute.Verification
                    .ForCondition(expectedValue.Equals(actualValue))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.RouteData_DataTokens_HaveValue, key, expectedValue, actualValue);

            return this;
        }

        public RouteDataAssertions HaveValue(string key, object expectedValue)
        {
            HaveValue(key, expectedValue, string.Empty, null);
            return this;
        }

        public RouteDataAssertions HaveValue(string key, object expectedValue, string reason, params object[] reasonArgs)
        {
            var subjectTyped = Subject as RouteData;

            Execute.Verification
                    .ForCondition(subjectTyped.Values.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.RouteData_Values_ContainsKey, key);

            var actualValue = subjectTyped.Values[key];

            Execute.Verification
                    .ForCondition(expectedValue.Equals(actualValue))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.RouteData_Values_HaveValue, key, expectedValue, actualValue);

            return this;
        }
    }
}
