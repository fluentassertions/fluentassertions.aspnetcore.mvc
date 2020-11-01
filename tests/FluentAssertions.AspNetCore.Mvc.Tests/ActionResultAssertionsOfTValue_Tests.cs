using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class ActionResultAssertionsOfTValue_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;

        #region Public Methods

        [Fact]
        public void Result_GivenActionResultOfTValue_ShouldReturnSameValue()
        {
            var actionResult = new BadRequestResult();
            var result = new ActionResult<object>(actionResult);

            result.Should().Result.Should().BeSameAs(actionResult);
        }

        [Fact]
        public void Value_GivenAValue_ShouldReturnSameValue()
        {
            var theValue = new object();
            var result = new ActionResult<object>(theValue);

            result.Should().Value.Should().BeSameAs(theValue);
        }

        [Fact]
        public void BeConvertibleTo_CallingConvertResultsDifferentType_ShouldFail()
        {
            var result = new ActionResult<object>(new BadRequestObjectResult(new object()));
            var failureMessage = FailureMessageHelper.ExpectedContextToBeConvertible(
                "result", typeof(ActionResult).FullName, typeof(BadRequestObjectResult).FullName);

            Action action = () => result.Should().BeConvertibleTo<ActionResult>(Reason, ReasonArgs);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);

        }

        [Fact]
        public void BeConvertibleTo_CallingConvertResultsGoodType_ShouldPass()
        {
            var result = new ActionResult<object>(new OkObjectResult(new object()));

            result.Should().BeConvertibleTo<OkObjectResult>(Reason, ReasonArgs);
        }

        [Fact]
        public void BeConvertibleTo_WithNullResult_ShouldPass()
        {
            var result = new ActionResult<object>(new object());

            result.Should().BeConvertibleTo<ObjectResult>(Reason, ReasonArgs);
        }

        [Fact]
        public void BeConvertibleTo_ShouldBeTheConvertedObject()
        {
            OkObjectResult expectation = new OkObjectResult(new object());
            var result = new ActionResult<object>(expectation);

            var actual =
                result.Should().BeConvertibleTo<OkObjectResult>(Reason, ReasonArgs).Which;

            actual.Should().BeSameAs(expectation);
        }

        [Fact]
        public void BeObjectResult_GivenActionResultWithObjectResult_ShouldPass()
        {
            var result = new ActionResult<object>(new object());

            result.Should().BeObjectResult(Reason, ReasonArgs);
        }

        [Fact]
        public void BeObjectResult_GivenActionResultWithNotObjectResult_ShouldFail()
        {
            var result = new ActionResult<object>(new BadRequestObjectResult(new object()));
            var failureMessage = FailureMessageHelper.ExpectedContextToBeConvertible(
                "result", typeof(ObjectResult).FullName, typeof(BadRequestObjectResult).FullName);

            Action action = () => result.Should().BeObjectResult(Reason, ReasonArgs);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        #endregion Public Methods
    }
}