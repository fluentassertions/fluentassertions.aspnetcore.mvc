using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Mvc;

namespace FluentAssertions.Mvc.Tests
{
    public class RouteDataAssertions_Tests
    {
        private RouteCollection _routes;

        public RouteDataAssertions_Tests()
        {
            _routes = new RouteCollection();
            _routes.Add(new Route("{controller}/{action}/{id}", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new 
                {
                    Controller = "Home",
                    Action = "Index",
                    Id = UrlParameter.Optional
                }),
            });
        }
    }
}
