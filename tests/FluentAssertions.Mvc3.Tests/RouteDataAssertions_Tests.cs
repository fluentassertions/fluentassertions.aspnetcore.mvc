using System;
using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;

namespace FluentAssertions.Mvc3.Tests
{
    [TestFixture]
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
                DataTokens = new RouteValueDictionary(new
                {
                    Area = "area51"
                })
            });
        }

        [Test]
		public void GetRouteDataForUrl_GivenRouteDoesntMap_ShouldReturnNull()
		{
            RouteData rd = _routes.GetRouteDataForUrl("/a/b/c/d/r");
            rd.Should().BeNull();
		}

        [Test]
        public void HaveValue_GivenKeyDoesExist_ShouldFail()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check");
            Action a = () => routeData.Should().HaveValue("xyz", "");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void HaveValue_GivenExpectedController_ShouldPass()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check");
            routeData.Should().HaveValue("controller", "accounts");
        }

        [Test]
        public void HaveValue_GivenUnexpectedController_ShouldFail()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check");
            Action a = () => routeData.Should().HaveValue("controller", "xyz");
            a.ShouldThrow<Exception>();
        }
        
        [Test]
        public void HaveValue_GivenNoId_ShouldPass()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check");
            routeData.Should().HaveValue("id", UrlParameter.Optional);
        }

        [Test]
        public void HaveValue_GivenExpectedId_ShouldPass()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check/44");
            routeData.Should().HaveValue("id", "44");
        }

        [Test]
        public void HaveValue_GivenUnexpectedId_ShouldFail()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check/44");
            Action a = () => routeData.Should().HaveValue("id", "999");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void HaveController_GivenExpectedValue_ShouldPass()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check/44");
            routeData.Should().HaveController("accounts");
        }

        [Test]
        public void HaveController_GivenUnexpectedValue_ShouldFail()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check/44");
            Action a = () => routeData.Should().HaveController("xyz");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void HaveAction_GivenExpectedValue_ShouldPass()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check/44");
            routeData.Should().HaveAction("check");
        }

        [Test]
        public void HaveAction_GivenUnexpectedValue_ShouldFail()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check/44");
            Action a = () => routeData.Should().HaveAction("xyz");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void HaveDataToken_GivenKeyDoesExist_ShouldFail()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check");
            Action a = () => routeData.Should().HaveDataToken("xyz", "");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void HaveDataToken_GivenExpectedArea_ShouldPass()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check");
            routeData.Should().HaveDataToken("area", "area51");
        }

        [Test]
        public void HaveDataToken_GivenUnexpectedArea_ShouldFail()
        {
            var routeData = _routes.GetRouteDataForUrl("/accounts/check");
            Action a = () => routeData.Should().HaveDataToken("area", "xyz");
            a.ShouldThrow<Exception>();
        }
    }
}
