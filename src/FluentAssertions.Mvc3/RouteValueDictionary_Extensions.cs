using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Mvc;
using FluentAssertions.Mvc3.Fakes;

namespace FluentAssertions.Mvc3
{
    public static class RouteValueDictionary_Extensions
    {
        public static string GenerateUrl(this RouteValueDictionary routeValues, RouteCollection routes)
        {
            var context = new FakeHttpContext("/", "~/");
            var requestContext = new RequestContext(context, new RouteData());
            var url = UrlHelper.GenerateUrl(null, null, null, routeValues, routes, requestContext, true);
            return url;
        }
    }
}
