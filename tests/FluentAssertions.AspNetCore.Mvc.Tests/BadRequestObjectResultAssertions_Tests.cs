using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class BadRequestObjectResultAssertions_Tests
    {
        private const string TestError = "testError";
        [Fact]
        public void Error_GivenBadRequestObjectResult_ShouldHaveTheSameError()
        {
            var result = new TestController().BadRequest(TestError);
            result.Should().BeBadRequestObjectResult().Error.Should().BeSameAs(TestError);
        }

        [Fact]
        public void SerializableError_GivenExpectedModelState_ShouldPass()
        {
            const string testErrorKey = "TestErrorKey";
            const string testErrorMessage = "TestErrorMessage";
            var testModelState = new ModelStateDictionary();
            testModelState.AddModelError(testErrorKey, testErrorMessage);
            var result = new TestController().BadRequest(testModelState);

            result.Should().BeBadRequestObjectResult().SerializableError.Should().ContainKey(testErrorKey);
        }

        [Fact]
        public void ErrorAs_GivenExpectedError_ShouldPass()
        {
            var result = new TestController().BadRequest(TestError);

            result.Should().BeBadRequestObjectResult().ErrorAs<string>().Should().Be(TestError);
        }

        [Fact]
        public void ErrorAs_GivenUnexpectedError_ShouldFail()
        {
            var result = new TestController().BadRequest(TestError);

            Action a = () => result.Should().BeBadRequestObjectResult().ErrorAs<string>().Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ErrorAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().BadRequest(TestError); 
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                 "BadRequestObjectResult.Error", typeof(int), typeof(string));

            Action a = () => result.Should().BeBadRequestObjectResult().ErrorAs<int>().Should().Be(2);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ErrorAs_Null_ShouldFail()
        {
            ActionResult result = new BadRequestObjectResult(null as object);
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "BadRequestObjectResult.Error", typeof(object));

            Action a = () => result.Should().BeBadRequestObjectResult().ErrorAs<object>();

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
