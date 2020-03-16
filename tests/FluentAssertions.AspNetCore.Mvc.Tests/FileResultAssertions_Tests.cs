using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Net.Http.Headers;
using System.Text;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class FileResultAssertions_Tests
    {
        [Fact]
        public void WithContentType_GivenValue_ShouldPass()
        {
            ActionResult result = new FileContentResult(Array.Empty<byte>(), "text/plain");

            result.Should().BeFileResult().WithContentType("text/plain");
        }

        [Fact]
        public void WithContentType_GivenUnexpected_ShouldFail()
        {
            var actualValue = "text/css";
            var expectedValue = "text/plain";
            ActionResult result = new FileContentResult(Array.Empty<byte>(), actualValue);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "FileResult.ContentType", expectedValue, actualValue);

            Action a = () => result.Should().BeFileResult().WithContentType(expectedValue);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithFileDownloadName_GivenValue_ShouldPass()
        {
            ActionResult result = new FileContentResult(Array.Empty<byte>(), "text/plain")
            {
                FileDownloadName = "file.txt"
            };

            result.Should().BeFileResult().WithFileDownloadName("file.txt");
        }

        [Fact]
        public void WithFileDownloadName_GivenUnexpected_ShouldFail()
        {
            var actualValue = "file2.txt";
            var expectedValue = "file1.txt";
            ActionResult result = new FileContentResult(Array.Empty<byte>(), "text/plain")
            {
                FileDownloadName = actualValue
            };
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "FileResult.FileDownloadName", expectedValue, actualValue);

            Action a = () => result.Should().BeFileResult().WithFileDownloadName(expectedValue);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithLastModified_GivenValue_ShouldPass()
        {
            ActionResult result = new FileContentResult(Array.Empty<byte>(), "text/plain")
            {
                LastModified = DateTimeOffset.Parse("2009-06-15T13:45:30.0000000-07:00")
            };

            result.Should().BeFileResult().WithLastModified(DateTimeOffset.Parse("2009-06-15T13:45:30.0000000-07:00"));
        }

        [Fact]
        public void WithLastModified_GivenUnexpected_ShouldFail()
        {
            var actualValue = DateTimeOffset.Parse("2009-06-15T13:45:30.0000000-07:00");
            var expectedValue = DateTimeOffset.Parse("2010-07-16T14:46:31.0000000-06:00");
            ActionResult result = new FileContentResult(Array.Empty<byte>(), "text/plain")
            {
                LastModified = actualValue
            };
            var failureMessage = "Expected \"FileResult.LastModified\" to be '<2010-07-16 14:46:31 -6h>' but found '<2009-06-15 13:45:30 -7h>'";

            Action a = () => result.Should().BeFileResult().WithLastModified(expectedValue);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }


        [Fact]
        public void WithEntityTag_GivenValue_ShouldPass()
        {
            var actualValue = new EntityTagHeaderValue("\"sha256 value 1\"");
            var expectedValue = new EntityTagHeaderValue("\"sha256 value 1\"");
            ActionResult result = new FileContentResult(Array.Empty<byte>(), "text/plain")
            {
                EntityTag = actualValue
            };

            result.Should().BeFileResult().WithEntityTag(expectedValue);
        }

        [Fact]
        public void WithEntityTag_GivenUnexpected_ShouldFail()
        {
            var actualValue = new EntityTagHeaderValue("\"sha256 value 1\"", true);
            var expectedValue = new EntityTagHeaderValue("\"sha256 value 2\"", false);
            ActionResult result = new FileContentResult(Array.Empty<byte>(), "text/plain")
            {
                EntityTag = actualValue
            };
            var failureMessage = "Expected \"FileResult.EntityTag\" to be '\"sha256 value 2\"' but found 'W/\"sha256 value 1\"'";

            Action a = () => result.Should().BeFileResult().WithEntityTag(expectedValue);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
    }
}
