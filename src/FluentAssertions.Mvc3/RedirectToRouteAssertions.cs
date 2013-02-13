using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Web.Mvc;
using FluentAssertions;

namespace FluentAssertions.Mvc
{
    public class RedirectToRouteAssertions : ReferenceTypeAssertions<RedirectToRouteResult, RedirectToRouteAssertions>
    {
        public RedirectToRouteAssertions(RedirectToRouteResult subject)
        {
            Subject = subject;
        }

        public RedirectToRouteAssertions WithPermanent(bool expectedPermanent)
        {
            WithPermanent(expectedPermanent, string.Empty, null);
            return this;
        }

        public RedirectToRouteAssertions WithPermanent(bool expectedPermanent, string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(expectedPermanent == Subject.Permanent)
                    .FailWith("Expected RedirectToRoute.Permanent to be {0}{reason}, but found {1}", expectedPermanent, Subject.Permanent);
            return this;
        }

        public RedirectToRouteAssertions WithRouteName(string expectedRouteName)
        {
            WithRouteName(expectedRouteName, string.Empty, null);
            return this;
        }

        public RedirectToRouteAssertions WithRouteName(string expectedRouteName, string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(string.Equals(expectedRouteName, Subject.RouteName, StringComparison.InvariantCultureIgnoreCase))
                    .FailWith("Expected RedirectToRoute.RouteName to be {0}{reason}, but found {1}", expectedRouteName, Subject.RouteName);

            return this;
        }

        public RedirectToRouteAssertions WithRouteValue(string key, object expectedValue)
        {
            WithRouteValue(key, expectedValue, string.Empty, null);
            return this;
        }

        public RedirectToRouteAssertions WithRouteValue(string key, object expectedValue, string reason, params object[] reasonArgs)
        {
            Subject.RouteValues.Should().Contain(new KeyValuePair<string, object>(key, expectedValue), reason, reasonArgs);
            return this;
        }

        public RedirectToRouteAssertions WithController(string expectedControllerName)
        {
            WithController(expectedControllerName, string.Empty, null);
            return this;
        }

        public RedirectToRouteAssertions WithController(string expectedControllerName, string reason, params object[] reasonArgs)
        {
            WithRouteValue("Controller", expectedControllerName, reason, reasonArgs);
            return this;
        }

        public RedirectToRouteAssertions WithAction(string expectedAction)
        {
            WithAction(expectedAction, string.Empty, null);
            return this;
        }

        public RedirectToRouteAssertions WithAction(string expectedArea, string reason, params object[] reasonArgs)
        {
            WithRouteValue("Action", expectedArea, reason, reasonArgs);
            return this;
        }

        public RedirectToRouteAssertions WithArea(string expectedAction)
        {
            WithArea(expectedAction, string.Empty, null);
            return this;
        }

        public RedirectToRouteAssertions WithArea(string expectedArea, string reason, params object[] reasonArgs)
        {
            WithRouteValue("Area", expectedArea, reason, reasonArgs);
            return this;
        }
    }
}
