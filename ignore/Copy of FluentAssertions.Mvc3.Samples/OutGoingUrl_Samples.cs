using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace FluentAssertions.Mvc3.Samples
{
    public class OutGoingUrl_Samples
    {
        private RouteCollection GetRoutes()
        {
            var routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);
            return routes;
        }

        public void OutGoingUrl_Sample()
        {
            var routeValues = new RouteValueDictionary(new
            {
                Controller = "product",
                Action = "edit",
                Id = 444
            });

            var routes = GetRoutes(); //Get Routes from MvcApplication
            routeValues.GenerateUrl(routes).Should().Be("~/product/edit/444");
        }
    }
}
