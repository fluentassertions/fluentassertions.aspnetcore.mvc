using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;

namespace FluentAssertions.Mvc3.Tests
{
    [TestFixture]
    public class ContentResultAssertions_Tests
    {
        [Test]
        public void WithContent_GivenExpected_ShouldPass()
        {
            ActionResult result = new ContentResult {Content = "content"};
            result.Should().BeContent().WithContent("content");
        }

        [Test]
        public void WithContent_GivenUnexpected_ShouldFail()
        {
            ActionResult result = new ContentResult { Content = "content" };
            Action a = () => result.Should().BeContent().WithContent("xyz");
            a.ShouldThrow<Exception>()
                    .WithMessage("");
        }

        [Test]
        public void WithContentType_GivenExpected_ShouldPass()
        {
            ActionResult result = new ContentResult { ContentType = "text/html" };
            result.Should().BeContent().WithContentType("text/html");
        }

        [Test]
        public void WithContentType_GivenUnexpected_ShouldFail()
        {
            ActionResult result = new ContentResult { ContentType = "text/html" };
            Action a = () => result.Should().BeContent().WithContentType("xyz");
            a.ShouldThrow<Exception>()
                    .WithMessage("");
        }

        [Test]
        public void WithContentEncoding_GivenExpected_ShouldPass()
        {
            ActionResult result = new ContentResult { ContentEncoding = Encoding.ASCII };
            result.Should().BeContent().WithContentEncoding(Encoding.ASCII);
        }

        [Test]
        public void WithContentEncoding_GivenUnexpected_ShouldFail()
        {
            ActionResult result = new ContentResult { ContentEncoding = Encoding.ASCII };
            Action a = () => result.Should().BeContent().WithContentEncoding(Encoding.Unicode);
            a.ShouldThrow<Exception>()
                    .WithMessage("");
        }
    }
}
