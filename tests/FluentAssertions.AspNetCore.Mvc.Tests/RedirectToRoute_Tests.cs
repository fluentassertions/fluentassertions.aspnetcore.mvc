using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class RedirectToRoute_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;

        #region Public Methods

        [Fact]
        public void WithPermanent_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", null, true);
            result.Should()
                .BeRedirectToRouteResult()
                .WithPermanent(true);
        }

        [Fact]
        public void WithPermanent_GivenUnExpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", null, true);
            Action a = () => result.Should()
                .BeRedirectToRouteResult()
                .WithPermanent(false, Reason, ReasonArgs);
            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectToRoute.Permanent", false, true));
        }

        [Fact]
        public void WithRouteName_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("default", null);
            result.Should()
                .BeRedirectToRouteResult()
                .WithRouteName("default");
        }

        [Fact]
        public void WithRouteName_GivenUnExpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("default", null);
            Action a = () => result.Should()
                .BeRedirectToRouteResult()
                .WithRouteName("xyz", Reason, ReasonArgs);
            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedContextToBeXButY("RedirectToRoute.RouteName","xyz", "default"));
        }

        [Fact]
        public void WithRouteValue_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new {
                    Id = "22"
                }));

            result.Should()
                .BeRedirectToRouteResult()
                .WithRouteValue("Id", "22");
        }

        [Fact]
        public void WithRouteValue_GivenUnexpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new {
                    Id = "22"
                }));

            Action a = () => result.Should()
                .BeRedirectToRouteResult()
                .WithRouteValue("Id", "11", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedAtKeyValueXButFoundY("RedirectToRouteResult.RouteValues", "Id", "11", "22"));
        }

        [Fact]
        public void WithRouteValue_GivenUnexpectedKey_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Id = "22"
                }));

            Action a = () => result.Should()
                .BeRedirectToRouteResult()
                .WithRouteValue("xyz", "22", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedKeyButNotFound("RedirectToRouteResult.RouteValues", "xyz", "22"));
        }

        [Fact]
        public void WithController_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new {
                    Controller = "home"
                }));

            result.Should()
                .BeRedirectToRouteResult()
                .WithController("home");
        }

        [Fact]
        public void WithController_GivenUnexpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new {
                    Controller = "home"
                }));

            Action a = () => result.Should()
                .BeRedirectToRouteResult()
                .WithController("xyz", Reason, ReasonArgs);
            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedAtKeyValueXButFoundY("RedirectToRouteResult.RouteValues", "Controller", "xyz", "home"));
        }

        [Fact]
        public void WithAction_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new {
                    Action = "index"
                }));

            result.Should()
                .BeRedirectToRouteResult()
                .WithAction("index");
        }

        [Fact]
        public void WithAction_GivenUnexpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new {
                    Action = "index"
                }));

            Action a = () => result.Should()
                .BeRedirectToRouteResult()
                .WithAction("xyz", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedAtKeyValueXButFoundY("RedirectToRouteResult.RouteValues", "Action", "xyz", "index"));
        }

        [Fact]
        public void WithArea_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new {
                    Area = "accounts"
                }));

            result.Should()
                .BeRedirectToRouteResult()
                .WithArea("accounts");
        }

        [Fact]
        public void WithArea_GivenUnexpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new {
                    Area = "accounts"
                }));

            Action a = () => result.Should()
                .BeRedirectToRouteResult()
                .WithArea("xyz", Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(FailureMessageHelper.ExpectedAtKeyValueXButFoundY("RedirectToRouteResult.RouteValues", "Area", "xyz", "accounts"));
        }

        #endregion Public Methods
    }
}