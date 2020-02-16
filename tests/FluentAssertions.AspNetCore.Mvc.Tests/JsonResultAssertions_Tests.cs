using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class JsonResultAssertions_Tests
    {
        [Fact]
        public void WithValue_GivenValue_ShouldPass()
        {
            ActionResult result = new JsonResult("value");
            result.Should().BeJsonResult().WithValue("value");
        }

        [Fact]
        public void WithValue_GivenUnexpected_ShouldFail()
        {
            var actualValue = "xyz";
            var expectedValue = "value";
            ActionResult result = new JsonResult(actualValue);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "JsonResult.Value", expectedValue, actualValue);

            Action a = () => result.Should().BeJsonResult().WithValue(expectedValue);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
    }
}