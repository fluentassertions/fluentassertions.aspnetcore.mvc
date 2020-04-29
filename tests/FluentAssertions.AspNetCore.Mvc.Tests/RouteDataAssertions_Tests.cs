using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Routing;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class RouteDataAssertionsTests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;
        private readonly RouteData _routeData;

        public RouteDataAssertionsTests()
        {
            _routeData = new RouteData();
            _routeData.Values.Add("controller", "home");
            _routeData.Values.Add("action", "index");
            _routeData.Values.Add("area", "admin");
            _routeData.DataTokens.Add("token", "value");
        }

        [Fact]
        public void HaveValue_GivenKeyDoesntExist_ShouldFail()
        {
            var expectedKey = "xyz";
            var failureMessage = FailureMessageHelper.ExpectedKeyButNotFound("RouteData.Values", expectedKey, "Val");

            Action a = () => _routeData.Should().HaveValue(expectedKey, "Val", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void HaveValue_GivenExpectedKeyValuePair_ShouldPass()
        {
            _routeData.Should().HaveValue("controller", "home");
        }

        [Fact]
        public void HaveValue_GivenUnexpectedKeyValuePair_ShouldFail()
        {
            var controllerName = "xyz";
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY("RouteData.Values", "controller", controllerName, "home");

            Action a = () => _routeData.Should().HaveValue("controller", controllerName, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void HaveController_GivenExpectedValue_ShouldPass()
        {
            _routeData.Should().HaveController("home");
        }

        [Fact]
        public void HaveController_GivenUnexpectedValue_ShouldFail()
        {
            var controllerName = "xyz";
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY("RouteData.Values", "controller", controllerName, "home");

            Action a = () => _routeData.Should().HaveController(controllerName, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void HaveAction_GivenExpectedValue_ShouldPass()
        {
            _routeData.Should().HaveAction("index");
        }

        [Fact]
        public void HaveAction_GivenUnexpectedValue_ShouldFail()
        {
            var actionName = "xyz";
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY("RouteData.Values", "action", actionName, "index");

            Action a = () => _routeData.Should().HaveAction(actionName, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void HaveArea_Exits_ShouldPass()
        {
            _routeData.Should().HaveArea("admin");
        }

        [Fact]
        public void HaveArea_DoesntExist_ShouldFail()
        {
            var area = "xyz"; 
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY("RouteData.Values", "area", area, "admin");

            Action a = () => _routeData.Should().HaveArea(area, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void HaveDataToken_KeyDoesExist_ShouldFail()
        {
            var expectedKey = "xyz"; 
            var failureMessage = FailureMessageHelper.ExpectedKeyButNotFound("RouteData.DataTokens",expectedKey, "Val");

            Action a = () => _routeData.Should().HaveDataToken(expectedKey, "Val", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void HaveDataToken_KeyValuePairExists_ShouldPass()
        {
            _routeData.Should().HaveDataToken("token", "value");
        }

        [Fact]
        public void HaveDataToken_ValueDoesntExist_ShouldFail()
        {
            var value = "xyz";
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY("RouteData.DataTokens", "token", value, "value");

            Action a = () => _routeData.Should().HaveDataToken("token", value, Reason, ReasonArgs);


            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
    }

}
