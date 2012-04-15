using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions.Assertions;
using System.Web.Mvc;
using FluentAssertions;

namespace FluentAssertions.Mvc3
{
    public class RedirectToRouteAssertions : ReferenceTypeAssertions<RedirectToRouteResult, RedirectToRouteAssertions>
    {
        public class Constants
        {
            public const string CommonFailMessage = "Expected RedirectResult.{0} to be '{1}' but was '{2}'";
        }

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
                    .ForCondition(expectedPermanent == Subject.Permanent)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(Constants.CommonFailMessage, "Permanent", expectedPermanent, Subject.Permanent);

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
                    .ForCondition(string.Equals(expectedRouteName, Subject.RouteName, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(Constants.CommonFailMessage, "RouteName", expectedRouteName, Subject.Permanent);

            return this;
        }

        public RedirectToRouteAssertions WithController(string expectedControllerName)
        {
            WithController(expectedControllerName, string.Empty, null);
            return this;
        }

        public RedirectToRouteAssertions WithController(string expectedControllerName, string reason, params object[] reasonArgs)
        {
            //Subject.RouteValues[""]
                    
            return this;
        }

        public RedirectToRouteAssertions WithRouteValue(string key, object expectedValue)
        {
            WithRouteValue(key, expectedValue, string.Empty, null);
            return this;
        }

        public RedirectToRouteAssertions WithRouteValue(string key, object expectedValue, string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .ForCondition(Subject.RouteValues.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(string.Format("RedirectResult.RouteValues does not contain key '{0}'", key));
            
            var actualValue = Subject.RouteValues[key];
            actualValue.Should().Be(expectedValue);

            return this;
        }
    }
}
