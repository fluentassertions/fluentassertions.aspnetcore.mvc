using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class JsonResultAssertions_Tests
    {
        [Fact]
        public void WithContentType_GivenValue_ShouldPass()
        {
            ActionResult result = new JsonResult("value")
            {
                ContentType = "text/plain"
            };

            result.Should().BeJsonResult().WithContentType("text/plain");
        }

        [Fact]
        public void WithContentType_GivenUnexpected_ShouldFail()
        {
            var actualValue = "text/css";
            var expectedValue = "text/plain";
            ActionResult result = new JsonResult("value")
            {
                ContentType = actualValue
            };
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "JsonResult.ContentType", expectedValue, actualValue);

            Action a = () => result.Should().BeJsonResult().WithContentType(expectedValue);

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

        [Fact]
        public void SerializerSettings_GivenExpectedValue_ShouldPass()
        {
            var expectedValue = new JsonSerializerSettings();
            var result = new JsonResult("value", expectedValue);

            result.Should().BeJsonResult().SerializerSettings.Should().BeSameAs(expectedValue);
        }
    }
}