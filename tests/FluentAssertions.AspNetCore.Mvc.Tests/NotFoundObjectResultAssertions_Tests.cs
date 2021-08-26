using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class NotFoundObjectResultAssertions_Tests
    {
        private const string TestValue = "testValue";
        [Fact]
        public void Value_GivenNotFoundObjectResult_ShouldHaveTheSameValue()
        {
            var result = new TestController().NotFound(TestValue);
            result.Should().BeNotFoundObjectResult().Value.Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenNotFoundObjectResult_ShouldHaveTheSameValue()
        {
            var result = new TestController().NotFound(TestValue);

            result.Should().BeNotFoundObjectResult().ValueAs<string>().Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().NotFound(TestValue);

            Action a = () => result.Should().BeNotFoundObjectResult().ValueAs<string>().Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().NotFound(TestValue);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                "NotFoundObjectResult.Value", typeof(int), typeof(string));

            Action a = () => result.Should().BeNotFoundObjectResult().ValueAs<int>().Should().Be(2);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new NotFoundObjectResult(null);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "NotFoundObjectResult.Value", typeof(object));

            Action a = () => result.Should().BeNotFoundObjectResult().ValueAs<object>();

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
    }
}
