using FluentAssertions.Mvc.Tests.Fakes;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class StatusCodeResultAssertions_Tests
    {
        #region Public Methods

        [Fact]
        public void WithStatusCode_GivenExpectedValue_ShouldPass()
        {
            int statusCode = 200;

            ActionResult result = new StatusCodeResult(statusCode);

            result.Should().BeStatusCodeResult().WithStatusCode(statusCode);
        }

        [Fact]
        public void WithStatusCode_GivenUnexpectedValue_ShouldFail()
        {
            int actualStatusCode = 200;
            int expectedStatusCode = 400;

            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("StatusCodeResult.StatusCode", expectedStatusCode, actualStatusCode);
            ActionResult result = new StatusCodeResult(actualStatusCode);

            Action action = () => result.Should().BeStatusCodeResult().WithStatusCode(expectedStatusCode, "it is {0}", 10);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        #endregion Public Methods
    }
}