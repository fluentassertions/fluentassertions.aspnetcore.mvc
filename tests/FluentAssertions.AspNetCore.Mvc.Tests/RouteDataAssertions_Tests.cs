using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Routing;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class RouteDataAssertionsTests
    {
        private RouteData _routeData;

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
            var failureMessage = FailureMessageHelper.Format(FailureMessages.RouteData_Values_ContainsKey, expectedKey);

            Action a = () => _routeData.Should().HaveValue(expectedKey, "");

            a.ShouldThrow<Exception>()
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
            var failureMessage = FailureMessageHelper.Format(FailureMessages.RouteData_Values_HaveValue, "controller", controllerName, "home");

            Action a = () => _routeData.Should().HaveValue("controller", controllerName);

            a.ShouldThrow<Exception>()
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
            var failureMessage = FailureMessageHelper.Format(FailureMessages.RouteData_Values_HaveValue, "controller", controllerName, "home");

            Action a = () => _routeData.Should().HaveController(controllerName);

            a.ShouldThrow<Exception>()
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
            var failureMessage = FailureMessageHelper.Format(FailureMessages.RouteData_Values_HaveValue, "action", actionName, "index");

            Action a = () => _routeData.Should().HaveAction(actionName);

            a.ShouldThrow<Exception>()
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
            var failureMessage = FailureMessageHelper.Format(FailureMessages.RouteData_Values_HaveValue, "area", area, "admin");

            Action a = () => _routeData.Should().HaveArea(area);

            a.ShouldThrow<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void HaveDataToken_KeyDoesExist_ShouldFail()
        {
            var expectedKey = "xyz";
            var failureMessage = FailureMessageHelper.Format(FailureMessages.RouteData_DataTokens_ContainsKey, expectedKey);

            Action a = () => _routeData.Should().HaveDataToken(expectedKey, "");

            a.ShouldThrow<Exception>()
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
            var failureMessage = FailureMessageHelper.Format(FailureMessages.RouteData_DataTokens_HaveValue, "token", value, "value");

            Action a = () => _routeData.Should().HaveDataToken("token", value);


            a.ShouldThrow<Exception>()
                .WithMessage(failureMessage);
        }
    }

}
