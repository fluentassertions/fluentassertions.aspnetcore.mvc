using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using FluentAssertions;
using FluentAssertions.Assertions;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
{
    [DebuggerNonUserCode]
    public class RouteDataAssertions : ReferenceTypeAssertions<RouteData, RouteDataAssertions>
    {
        public RouteDataAssertions(RouteData subject)
        {
            Subject = subject;
        }

        public RouteDataAssertions HaveController(string expectedControllerName)
        {
            return this;
        }

        public RouteDataAssertions HaveAction(string expectedActionName)
        {
            return this;
        }

        public RouteDataAssertions HaveArea(string expectedAreaName)
        {
            return this;
        }

        public RouteDataAssertions HaveDataToken(string tokenName, string expectedValue)
        {
            return this;
        }

        public RouteDataAssertions HaveValue(string valueName, string expectedValue)
        {
            return this;
        }
    }
}
