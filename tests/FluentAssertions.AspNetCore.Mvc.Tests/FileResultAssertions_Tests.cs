using FluentAssertions.AspNetCore.Mvc.Tests.Helpers;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class FileResultAssertions_Tests
    {
        [Fact]
        public void WithContentType_GivenExpectedValue_ShouldPass()
        {
            var actualValue = "text/plain";
            var expectedValue = string.Copy(actualValue);
            ActionResult result = TestDataGenerator.CreateFileContentResult(contentType: actualValue);

            result.Should().BeFileResult().WithContentType(expectedValue);
        }

        [Fact]
        public void WithContentType_GivenUnexpected_ShouldFail()
        {
            var actualValue = "text/css";
            var expectedValue = "text/plain";
            ActionResult result = TestDataGenerator.CreateFileContentResult(contentType: actualValue);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "FileResult.ContentType", expectedValue, actualValue);

            Action a = () => result.Should().BeFileResult().WithContentType(expectedValue);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithFileDownloadName_GivenExpectedValue_ShouldPass()
        {
            var result = TestDataGenerator.CreateFileContentResult();
            result.FileDownloadName = "file.txt";

            result.Should().BeFileResult().WithFileDownloadName("file.txt");
        }

        [Fact]
        public void WithFileDownloadName_GivenUnexpected_ShouldFail()
        {
            var actualValue = "file2.txt";
            var expectedValue = "file1.txt"; 
            var result = TestDataGenerator.CreateFileContentResult();
            result.FileDownloadName = actualValue;
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "FileResult.FileDownloadName", expectedValue, actualValue);

            Action a = () => result.Should().BeFileResult().WithFileDownloadName(expectedValue);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithLastModified_GivenExpectedValue_ShouldPass()
        {
            var result = TestDataGenerator.CreateFileContentResult();
            result.LastModified = DateTimeOffset.Parse("2009-06-15T13:45:30.0000000-07:00");

            result.Should().BeFileResult().WithLastModified(DateTimeOffset.Parse("2009-06-15T13:45:30.0000000-07:00"));
        }

        [Fact]
        public void WithLastModified_GivenUnexpected_ShouldFail()
        {
            var actualValue = DateTimeOffset.Parse("2009-06-15T13:45:30.0000000-07:00");
            var expectedValue = DateTimeOffset.Parse("2010-07-16T14:46:31.0000000-06:00");
            var result = TestDataGenerator.CreateFileContentResult();
            result.LastModified = actualValue;
            var failureMessage = "Expected \"FileResult.LastModified\" to be '<2010-07-16 14:46:31 -6h>' but found '<2009-06-15 13:45:30 -7h>'";

            Action a = () => result.Should().BeFileResult().WithLastModified(expectedValue);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }


        [Fact]
        public void WithEntityTag_GivenExpectedValue_ShouldPass()
        {
            var actualValue = new EntityTagHeaderValue("\"sha256 value 1\"");
            var expectedValue = new EntityTagHeaderValue("\"sha256 value 1\"");
            var result = TestDataGenerator.CreateFileContentResult();
            result.EntityTag = actualValue;

            result.Should().BeFileResult().WithEntityTag(expectedValue);
        }

        [Fact]
        public void WithEntityTag_GivenUnexpected_ShouldFail()
        {
            var actualValue = new EntityTagHeaderValue("\"sha256 value 1\"", true);
            var expectedValue = new EntityTagHeaderValue("\"sha256 value 2\"", false);
            var result = TestDataGenerator.CreateFileContentResult();
            result.EntityTag = actualValue;
            var failureMessage = "Expected \"FileResult.EntityTag\" to be '\"sha256 value 2\"' but found 'W/\"sha256 value 1\"'";

            Action a = () => result.Should().BeFileResult().WithEntityTag(expectedValue);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
    }
}
