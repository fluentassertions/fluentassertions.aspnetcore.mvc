using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace FluentAssertions.Mvc3.Samples
{
    public class IncomingUrl_Samples
    {
        private RouteCollection GetRoutes()
        {
            var routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);
            return routes;
        }

        public void IncomingUrl_Sample()
        {
            var routes = GetRoutes();
            var routeData = routes.GetRouteDataForUrl("product/view/444");
            routeData.Should()
                .HaveController("product")
                .HaveAction("view")
                .HaveValue("Id", "444")
                .HaveDataToken("Area", "products");
        }
    }
}
