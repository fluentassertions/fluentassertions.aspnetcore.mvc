using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class FileContentResultAssertions_Tests
    {
        [Fact]
        public void WithContentType_GivenExpectedValue_ShouldPass()
        {
            var actualBytes = Encoding.ASCII.GetBytes("Test 1");
            var expectedBytes = Encoding.ASCII.GetBytes("Test 1");
            ActionResult result = new FileContentResult(actualBytes, "text/plain");

            result.Should()
                .BeFileContentResult()
                .WithFileContents(expectedBytes);
        }

        [Theory]
        [InlineData(
            "Test 1", "Test 11"
            , "Expected \"FileContentResult.FileContents\" to have 7 byte(s), but found 6.")]
        [InlineData(
            "Test 1a", "Test 2a"
            , "Expected \"FileContentResult.FileContents[5]\" to be 0x32, but found 0x31.")]
        public void WithContentType_GivenUnexpectedValue_ShouldFail(
            string actual, string expected, string failureMessage)
        {
            var actualBytes = actual != null ? Encoding.ASCII.GetBytes(actual) : null;
            var expectedBytes = expected != null ? Encoding.ASCII.GetBytes(expected) : null;
            ActionResult result = new FileContentResult(actualBytes, "text/plain");

            Action a = () => result.Should()
                .BeFileContentResult()
                .WithFileContents(expectedBytes);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

    }
}
