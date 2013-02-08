using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Routing;
using System.Web.Mvc;

namespace FluentAssertions.Mvc.Tests
{
    [TestFixture]
    public class RouteValueDictionary_Extensions_Tests
    {
        private RouteCollection CreateDefaultRoutes()
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
            return routes;
        }

        [Test]
        public void GenerateUrl_GivenNoRouteValues_ShouldReturnExpectedUrl()
        {
            var routeValues = new RouteValueDictionary();
            var url = routeValues.GenerateUrl(CreateDefaultRoutes());
            url.Should().Be("/");
        }
        
        [Test]
        public void GenerateUrl_GivenNotDefaultControllerValue_ShouldReturnExpectedUrl()
        {
            var routeValues = new RouteValueDictionary(new
            {
                Controller = "Blah"
            });

            var url = routeValues.GenerateUrl(CreateDefaultRoutes());
            url.Should().Be("/Blah");
        }

        [Test]
        public void GenerateUrl_GivenDefaultControllerValue_ShouldReturnExpectedUrl()
        {
            var routeValues = new RouteValueDictionary(new
            {
                Controller = "Home"
            });

            var url = routeValues.GenerateUrl(CreateDefaultRoutes());
            url.Should().Be("/");
        }

        [Test]
        public void GenerateUrl_GivenDefaultControllerAndActionValues_ShouldReturnExpectedUrl()
        {
            var routeValues = new RouteValueDictionary(new
            {
                Controller = "Home",
                Action = "Index"
            });

            var url = routeValues.GenerateUrl(CreateDefaultRoutes());
            url.Should().Be("/");
        }

        [Test]
        public void GenerateUrl_GivenDefaultControllerAndNotDefaultActionValues_ShouldReturnExpectedUrl()
        {
            var routeValues = new RouteValueDictionary(new
            {
                Controller = "Home",
                Action = "action1"
            });

            var url = routeValues.GenerateUrl(CreateDefaultRoutes());
            url.Should().Be("/Home/action1");
        }

        [Test]
        public void GenerateUrl_GivenNotDefaultControllerAndActionValues_ShouldReturnExpectedUrl()
        {
            var routeValues = new RouteValueDictionary(new
            {
                Controller = "blah",
                Action = "action1"
            });

            var url = routeValues.GenerateUrl(CreateDefaultRoutes());
            url.Should().Be("/blah/action1");
        }

    }
}
