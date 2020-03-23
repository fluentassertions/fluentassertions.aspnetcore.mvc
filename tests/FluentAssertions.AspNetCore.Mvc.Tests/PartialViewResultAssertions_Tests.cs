using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class PartialViewResultAssertions_Tests
    {
        [Fact]
        public void WithDefaultViewName_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new PartialViewResult
            {
                ViewName = String.Empty
            };

            AssertionsExtensions.Should(result).BePartialViewResult().WithDefaultViewName();
        }

        [Fact]
        public void Model_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().PartialViewSimpleModel();

            AssertionsExtensions.Should(result).BePartialViewResult().Model.Should().Be("hello");
        }

        [Fact]
        public void Model_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().PartialViewSimpleModel();

            Action a = () => AssertionsExtensions.Should(result).BePartialViewResult().Model.Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ModelAs_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().PartialViewSimpleModel();

            AssertionsExtensions.Should(result).BePartialViewResult().ModelAs<string>().Should().Be("hello");
        }

        [Fact]
        public void ModelAs_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().PartialViewSimpleModel();

            Action a = () => AssertionsExtensions.Should(result).BePartialViewResult().ModelAs<string>().Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ModelAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().PartialViewSimpleModel();

            Action a = () => AssertionsExtensions.Should(result).BePartialViewResult().ModelAs<int>().Should().Be(2);
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ModelAs_Null_ShouldFail()
        {
            ActionResult result = new PartialViewResult();
            string failureMessage = FailureMessageHelper.Format(FailureMessages.CommonNullWasSuppliedFailMessage, "Model", typeof(Object).Name);

            Action a = () =>
            {
                AssertionsExtensions.Should(result).BePartialViewResult().ModelAs<Object>();
            };

            a.Should().Throw<Exception>()
                    .WithMessage(failureMessage);
        }
    }
}
