using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class OkObjectResultAssertions_Tests
    {
        private const string TestValue = "testValue";
        [Fact]
        public void Value_GivenOkObjectResult_ShouldHaveTheSameValue()
        {
            var result = new TestController().Ok(TestValue);
            result.Should().BeOkObjectResult().Value.Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenOkObjectResult_ShouldHaveTheSameValue()
        {
            var result = new TestController().Ok(TestValue);

            result.Should().BeOkObjectResult().ValueAs<string>().Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().Ok(TestValue);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                "OkObjectResult.Value", typeof(int), typeof(string));

            Action a = () => result.Should().BeOkObjectResult().ValueAs<int>().Should().Be(2);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new OkObjectResult(null);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "OkObjectResult.Value", typeof(object));

            Action a = () => result.Should().BeOkObjectResult().ValueAs<object>();

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
    }
}
