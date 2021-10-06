using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class ConflictObjectResultAssertions_Tests
    {
        private const string TestError = "testError";

        [Fact]
        public void Error_GivenConflictObjectResult_ShouldHaveTheSameError()
        {
            var result = new TestController().Conflict(TestError);
            result.Should().BeConflictObjectResult().Error.Should().BeSameAs(TestError);
        }

        [Fact]
        public void SerializableError_GivenExpectedModelState_ShouldPass()
        {
            const string testErrorKey = "TestErrorKey";
            const string testErrorMessage = "TestErrorMessage";
            var testModelState = new ModelStateDictionary();
            testModelState.AddModelError(testErrorKey, testErrorMessage);
            var result = new TestController().Conflict(testModelState);

            result.Should().BeConflictObjectResult().SerializableError.Should().ContainKey(testErrorKey);
        }

        [Fact]
        public void ErrorAs_GivenExpectedError_ShouldPass()
        {
            var result = new TestController().Conflict(TestError);

            result.Should().BeConflictObjectResult().ErrorAs<string>().Should().Be(TestError);
        }

        [Fact]
        public void ErrorAs_GivenUnexpectedError_ShouldFail()
        {
            var result = new TestController().Conflict(TestError);

            Action a = () => result.Should().BeConflictObjectResult().ErrorAs<string>().Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ErrorAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().Conflict(TestError);
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                 "ConflictObjectResult.Error", typeof(int), typeof(string));

            Action a = () => result.Should().BeConflictObjectResult().ErrorAs<int>().Should().Be(2);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ErrorAs_Null_ShouldFail()
        {
            ActionResult result = new ConflictObjectResult(null as object);
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "ConflictObjectResult.Error", typeof(object));

            Action a = () => result.Should().BeConflictObjectResult().ErrorAs<object>();

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
