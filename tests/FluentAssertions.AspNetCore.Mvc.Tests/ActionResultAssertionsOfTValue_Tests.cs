#if NETCOREAPP3_0
using FluentAssertions.AspNetCore.Mvc.Tests.Helpers;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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

        #endregion Public Methods
    }
}
#endif