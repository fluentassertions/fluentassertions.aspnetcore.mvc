using System.Web.Routing;
using NUnit.Framework;

namespace FluentAssertions.Mvc3.Samples.Tests
{
    [TestFixture]
    public class Route_Tests
    {
        private RouteCollection _routes;

        public Route_Tests()
        {
            _routes = new RouteCollection();
            MvcApplication.RegisterRoutes(_routes);
        }

        [Test]
        public void Incoming_ProductListRoute_ShouldMap()
		{
            RouteData rd = _routes.GetRouteDataForUrl("Product/List");
            rd.Should()
                    .HaveController("Product")
                    .HaveAction("List");
		}

        [Test]
		public void Incoming_ProductIndexRoute_ShouldNotMap()
		{
            RouteData rd = _routes.GetRouteDataForUrl("Product/Index");
#warning todo
		}
    }
}
