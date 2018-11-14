using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    
    public class ContentResultAssertions_Tests
    {
        [Fact]
        public void WithContent_GivenExpected_ShouldPass()
        {
            ActionResult result = new ContentResult { Content = "content" };
            result.Should().BeContentResult().WithContent("content");
        }

        [Fact]
        public void WithContent_GivenUnexpected_ShouldFail()
        {
            var actualContent = "content";
            var expectedContent = "xyz";
            ActionResult result = new ContentResult { Content = actualContent };
            var failureMessage = String.Format(FailureMessages.CommonFailMessage, "ContentResult.Content", expectedContent, actualContent);

            Action a = () => result.Should().BeContentResult().WithContent(expectedContent);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithContentType_GivenExpected_ShouldPass()
        {
            ActionResult result = new ContentResult { ContentType = "text/html" };
            result.Should().BeContentResult().WithContentType("text/html");
        }

        [Fact]
        public void WithContentType_GivenUnexpected_ShouldFail()
        {
            var actualContentType = "text/html";
            var expectedContentType = "xyz";
            ActionResult result = new ContentResult { ContentType = actualContentType };
            var failureMessage = String.Format(FailureMessages.CommonFailMessage, "ContentResult.ContentType", expectedContentType, actualContentType);

            Action a = () => result.Should().BeContentResult().WithContentType(expectedContentType);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
    }
}
