using FluentAssertions.Mvc.Tests.Fakes;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class StatusCodeResultAssertions_Tests
    {
        #region Private Fields

        private FakeController _controller = new FakeController();

        #endregion Private Fields

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

            var failureMessage = string.Format(FailureMessages.StatusCodeResultBase_WithStatusCode, expectedStatusCode, actualStatusCode);
            ActionResult result = new StatusCodeResult(actualStatusCode);

            Action action = () => result.Should().BeStatusCodeResult().WithStatusCode(expectedStatusCode);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        #endregion Public Methods
    }
}