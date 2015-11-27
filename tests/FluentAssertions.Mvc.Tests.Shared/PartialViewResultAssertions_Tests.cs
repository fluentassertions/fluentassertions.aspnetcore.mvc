using System;
using System.Web.Mvc;
using NUnit.Framework;

using FluentAssertions.Mvc.Tests.Helpers;

namespace FluentAssertions.Mvc.Tests
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

            result.Should().BePartialViewResult().WithDefaultViewName();
        }

        [Test]
        public void Model_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new PartialViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };

            result.Should().BePartialViewResult().Model.Should().Be("hello");
        }

        [Test]
        public void Model_GivenUnexpectedValue_ShouldFail()
        {
            ActionResult result = new PartialViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };

            Action a = () => result.Should().BePartialViewResult().Model.Should().Be("xyx");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void ModelAs_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new PartialViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };

            result.Should().BePartialViewResult().ModelAs<string>().Should().Be("hello");
        }

        [Test]
        public void ModelAs_GivenUnexpectedValue_ShouldFail()
        {
            ActionResult result = new PartialViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };

            Action a = () => result.Should().BePartialViewResult().ModelAs<string>().Should().Be("xyx");
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void ModelAs_GivenWrongType_ShouldFail()
        {
            ActionResult result = new PartialViewResult
            {
                ViewData = new ViewDataDictionary("hello")
            };

            Action a = () => result.Should().BePartialViewResult().ModelAs<int>().Should().Be(2);
            a.ShouldThrow<Exception>();
        }

        [Test]
        public void ModelAs_Null_ShouldFail()
        {
            ActionResult result = new PartialViewResult();
            string failureMessage = FailureMessageHelper.Format(FailureMessages.ViewResultBase_NullModel, typeof(Object).Name);

            Action a = () => result.Should().BePartialViewResult().ModelAs<Object>();

            a.ShouldThrow<Exception>()
                    .WithMessage(failureMessage);
        }
    }
}
