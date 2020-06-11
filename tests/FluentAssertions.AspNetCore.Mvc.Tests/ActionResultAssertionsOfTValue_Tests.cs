using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
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

            result.Should().BeActionResult<object>().Result.Should().BeSameAs(actionResult);
        }

        [Fact]
        public void Value_GivenAValue_ShouldReturnSameValue()
        {
            var theValue = new object();
            var result = new ActionResult<object>(theValue);

            result.Should().BeActionResult<object>().Value.Should().BeSameAs(theValue);
        }

        [Fact]
        public void ConvertibleTo_CallingConvertResultsDifferentType_ShouldFail()
        {
            var result = new ActionResult<object>(new BadRequestObjectResult(new object()));
            var failureMessage = FailureMessageHelper.ExpectedContextToBeConvertible(
                "result", typeof(ActionResult).FullName, typeof(BadRequestObjectResult).FullName);

            Action action = () => result.Should().BeActionResult<object>().ConvertibleTo<ActionResult>(Reason, ReasonArgs);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);

        }

        [Fact]
        public void ConvertibleTo_CallingConvertResultsGoodType_ShouldPass()
        {
            var result = new ActionResult<object>(new OkObjectResult(new object()));

            result.Should().BeActionResult<object>().ConvertibleTo<OkObjectResult>(Reason, ReasonArgs);
        }

        [Fact]
        public void ConvertibleToWich_ShouldBeTheConvertedObject()
        {
            OkObjectResult expectation = new OkObjectResult(new object());
            var result = new ActionResult<object>(expectation);

            var actual =
                result.Should().BeActionResult<object>().ConvertibleTo<OkObjectResult>(Reason, ReasonArgs).Which;

            actual.Should().BeSameAs(expectation);
        }
        #endregion Public Methods
    }
}