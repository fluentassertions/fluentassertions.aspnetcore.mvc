using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class ConvertToActionResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;

        [Fact]
        public void BeActionResult_GivenActionResultOfTValue_ShouldPass()
        {
            var actionResult = new BadRequestResult();
            IConvertToActionResult result = new ActionResult<object>(actionResult);

            result.Should().BeActionResult<object>();
        }

        [Fact]
        public void BeActionResult_GivenActionResultOfTValue_ShouldReturnActionResultAssertionsOfTValue()
        {
            var actionResult = new BadRequestResult();
            IConvertToActionResult subject = new ActionResult<object>(actionResult);

            var result = subject.Should().BeActionResult<object>();

            Assert.IsType<ActionResultAssertions<object>>(result);
        }

        [Fact]
        public void BeActionResult_GivenNull_ShouldFail()
        {
            IConvertToActionResult result = null;
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "result", typeof(ActionResult<object>));

            Action action = () => result.Should().BeActionResult<object>(Reason, ReasonArgs);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void BeActionResult_GivenUnexpectedTValue_ShouldFail()
        {
            var actionResult = new BadRequestResult();
            IConvertToActionResult result = new ActionResult<string>(actionResult);

            Action action = () => result.Should().BeActionResult<int>(Reason, ReasonArgs);

            action.Should().Throw<Exception>()
                .WithMessage("Expected result to be ActionResult<TValue> with type System.Int32 because it is 10 but was System.String.");
        }

        [Fact]
        public void BeActionResult_GivenUnexpectedType_ShouldFail()
        {
            var mock = new Mock<IConvertToActionResult>();
            var result = mock.Object;
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason(
                "result", typeof(ActionResult<object>), result.GetType());

            Action action = () => result.Should().BeActionResult<object>(Reason, ReasonArgs);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void BeConvertibleTo_CallingConvertResultsNull_ShouldFail()
        {
            var mock = new Mock<IConvertToActionResult>();
            mock.Setup(e => e.Convert()).Returns((IActionResult)null);
            var result = mock.Object;
            var failureMessage = FailureMessageHelper.ExpectedContextToBeConvertible(
                "result", typeof(ActionResult).FullName, "<null>");

            Action action = () => result.Should().BeConvertibleTo<ActionResult>(Reason, ReasonArgs);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);

        }

        [Fact]
        public void BeConvertibleTo_CallingConvertResultsDifferentType_ShouldFail()
        {
            var mock = new Mock<IConvertToActionResult>();
            mock.Setup(e => e.Convert()).Returns(new BadRequestObjectResult(new object()));
            var result = mock.Object;
            var failureMessage = FailureMessageHelper.ExpectedContextToBeConvertible(
                "result", typeof(ActionResult).FullName, typeof(BadRequestObjectResult).FullName);

            Action action = () => result.Should().BeConvertibleTo<ActionResult>(Reason, ReasonArgs);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);

        }

        [Fact]
        public void BeConvertibleTo_CallingConvertResultsGoodType_ShouldPass()
        {
            var mock = new Mock<IConvertToActionResult>();
            mock.Setup(e => e.Convert()).Returns(new OkObjectResult(new object()));
            var result = mock.Object;

            result.Should().BeConvertibleTo<OkObjectResult>(Reason, ReasonArgs);
        }

        [Fact]
        public void BeConvertibleTo_ShouldBeTheConvertedObject()
        {
            var mock = new Mock<IConvertToActionResult>();
            var expectation = new OkObjectResult(new object());
            mock.Setup(e => e.Convert()).Returns(expectation);
            var result = mock.Object;

            var actual =
                result.Should().BeConvertibleTo<OkObjectResult>(Reason, ReasonArgs).Which;

            actual.Should().BeSameAs(expectation);
        }
    }
}