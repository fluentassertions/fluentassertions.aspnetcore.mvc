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

        [Fact]
        public void Value_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().JsonSimpleValue();

            result.Should().BeJsonResult().Value.Should().Be("hello");
        }

        [Fact]
        public void Json_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().JsonSimpleValue();

            Action a = () => result.Should().BeJsonResult().Value.Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().JsonSimpleValue();

            result.Should().BeJsonResult().ValueAs<string>().Should().Be("hello");
        }

        [Fact]
        public void ValueAs_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().JsonSimpleValue();

            Action a = () => result.Should().BeJsonResult().ValueAs<string>().Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().JsonSimpleValue();

            Action a = () => result.Should().BeJsonResult().ValueAs<int>().Should().Be(2);
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new JsonResult(null);
            string failureMessage = FailureMessageHelper.Format(FailureMessages.CommonNullWasSuppliedFailMessage, "Value", typeof(Object).Name);

            Action a = () => result.Should().BeJsonResult().ValueAs<Object>();

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

    }
}