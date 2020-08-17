using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class ObjectResultAssertions_Tests
    {
        private const string TestValue = "testValue";
        [Fact]
        public void Value_GivenObjectResult_ShouldHaveTheSameValue()
        {
            var result = new ObjectResult(TestValue);
            result.Should().BeObjectResult().Value.Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenObjectResult_ShouldHaveTheSameValue()
        {
            var result = new ObjectResult(TestValue);

            result.Should().BeObjectResult().ValueAs<string>().Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new ObjectResult(TestValue);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                "ObjectResult.Value", typeof(int), typeof(string));

            Action a = () => result.Should().BeObjectResult().ValueAs<int>().Should().Be(2);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new ObjectResult(null);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "ObjectResult.Value", typeof(object));

            Action a = () => result.Should().BeObjectResult().ValueAs<object>();

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
    }
}
