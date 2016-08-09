#if !NETSTANDARD1_6
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using FluentAssertions.Mvc.Fakes;
using System.Diagnostics;

namespace FluentAssertions.Mvc
{
    [DebuggerNonUserCode]
    public static class RouteCollection_Extensions
    {
        public static RouteData GetRouteDataForUrl(this RouteCollection routes, string url)
        {
            var context = new FakeHttpContext("/", url);
            var routeData = routes.GetRouteData(context);
            return routeData;
        }
    }
}
#endif