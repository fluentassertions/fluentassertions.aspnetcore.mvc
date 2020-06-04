#if NETCOREAPP3_0
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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

            result.Should().BeOfType<ActionResultAssertions<object>>();
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
            IConvertToActionResult result = new Mock<IConvertToActionResult>().Object;
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                "result", "Microsoft.AspNetCore.Mvc.ActionResult`1[System.Object]", result.GetType().FullName);

            Action action = () => result.Should().BeActionResult<object>(Reason, ReasonArgs);

            action.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }


    }
}

#endif