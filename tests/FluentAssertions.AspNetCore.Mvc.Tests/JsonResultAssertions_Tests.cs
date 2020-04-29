using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class JsonResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;

        [Fact]
        public void WithContentType_GivenExpectedValue_ShouldPass()
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
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("JsonResult.ContentType", expectedValue, actualValue);

            Action a = () => result.Should().BeJsonResult().WithContentType(expectedValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithStatusCode_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new JsonResult("value")
            {
                StatusCode = 200
            };

            result.Should().BeJsonResult().WithStatusCode(200);
        }

        [Fact]
        public void WithStatusCode_GivenUnexpected_ShouldFail()
        {
            var actualStatusCode = 401;
            var expectedStatusCode = 200;
            ActionResult result = new JsonResult("value")
            {
                StatusCode = actualStatusCode
            };
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("JsonResult.StatusCode", expectedStatusCode, actualStatusCode);

            Action a = () => result.Should().BeJsonResult().WithStatusCode(expectedStatusCode, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void Value_GivenJsonResult_ShouldReturnSameValue()
        {
            object expectedValue = "hello";
            var result = new JsonResult(expectedValue);

            result.Should().BeJsonResult().Value.Should().BeSameAs(expectedValue);
        }

        [Fact]
        public void ValueAs_GivenJsonResultWithValue_ShouldReturnTheSame()
        {
            string expectedValue = "hello";
            var result = new JsonResult(expectedValue);

            result.Should().BeJsonResult().ValueAs<string>().Should().BeSameAs(expectedValue);
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().JsonSimpleValue();
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                "JsonResult.Value", typeof(int), typeof(string));

            Action a = () => result.Should().BeJsonResult().ValueAs<int>().Should().Be(2);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new JsonResult(null);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "JsonResult.Value", typeof(object));

            Action a = () => result.Should().BeJsonResult().ValueAs<object>();

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void SerializerSettings_GivenInJsonResult_ShouldBeSame()
        {
            var expectedValue = new JsonSerializerSettings();
            var result = new JsonResult("value", expectedValue);

            result.Should().BeJsonResult().SerializerSettings.Should().BeSameAs(expectedValue);
        }
    }
}