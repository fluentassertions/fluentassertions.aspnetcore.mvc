using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    [TestFixture]
    public class PartialViewResultAssertions_Tests
    {
        [Test]
        public void WithDefaultViewName_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new PartialViewResult
            {
                ViewName = String.Empty
            };

            AssertionsExtensions.Should(result).BePartialViewResult().WithDefaultViewName();
        }

        [Test]
        public void Model_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().PartialViewSimpleModel();

            AssertionsExtensions.Should(result).BePartialViewResult().Model.Should().Be("hello");
        }

        [Test]
        public void Model_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().PartialViewSimpleModel();

            Action a = () => AssertionsExtensions.Should(result).BePartialViewResult().Model.Should().Be("xyx");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void ModelAs_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().PartialViewSimpleModel();

            AssertionsExtensions.Should(result).BePartialViewResult().ModelAs<string>().Should().Be("hello");
        }

        [Test]
        public void ModelAs_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().PartialViewSimpleModel();

            Action a = () => AssertionsExtensions.Should(result).BePartialViewResult().ModelAs<string>().Should().Be("xyx");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void ModelAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().PartialViewSimpleModel();

            Action a = () => AssertionsExtensions.Should(result).BePartialViewResult().ModelAs<int>().Should().Be(2);
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void ModelAs_Null_ShouldFail()
        {
            ActionResult result = new PartialViewResult();
            string failureMessage = FailureMessageHelper.Format(FailureMessages.ViewResultBase_NullModel, typeof(Object).Name);

            Action a = () =>
            {
                AssertionsExtensions.Should(result).BePartialViewResult().ModelAs<Object>();
            };

            a.ShouldThrow<Exception>()
                    .WithMessage(failureMessage);
        }
    }
}
