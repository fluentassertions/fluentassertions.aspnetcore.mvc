using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using FluentAssertions.Mvc3.Fakes;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
{
    [DebuggerNonUserCode]
    public static class RouteCollection_Extensions
    {
        public static RouteData GetRouteDataForUrl(this RouteCollection routes, string url)
        {
            var context = new FakeHttpContext(url, string.Empty);
            var routeData = routes.GetRouteData(context);
            return routeData;
        }
    }
}
