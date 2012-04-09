using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Routing;
using System.Web.Mvc;

namespace FluentAssertions.Mvc3.Tests
{
    [TestFixture]
    public class RouteValueDictionary_Extensions_Tests
    {
        public static void a()
        {
            var routes = new RouteCollection();
            routes.Add(new Route("{controller}/{action}/{id}", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new
                {
                    Controller = "Home",
                    Action = "Index",
                    Id = UrlParameter.Optional
                }),
            });

            var routeValues = new RouteValueDictionary(new
            {
                Controller = "Home",
                Action = "Index"
            });

            var url = routeValues.GenerateUrl(routes);
            url.Should().Be("/abcHome");
        }
    }
}
