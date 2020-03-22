using FluentAssertions.AspNetCore.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class FileContentResultAssertions_Tests
    {
        [Fact]
        public void WithFileContents_GivenExpectedValue_ShouldPass()
        {
            var actualBytes = TestDataGenerator.CreateBytes("Test 1");
            var expectedBytes = TestDataGenerator.CreateBytes("Test 1");
            ActionResult result = TestDataGenerator.CreateFileContentResult(actualBytes);

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
        public void WithFileContents_GivenUnexpectedValue_ShouldFail(
            string actual, string expected, string failureMessage)
        {
            var actualBytes = TestDataGenerator.CreateBytes(actual);
            var expectedBytes = TestDataGenerator.CreateBytes(expected);
            ActionResult result = TestDataGenerator.CreateFileContentResult(actualBytes);

            Action a = () => result.Should()
                .BeFileContentResult()
                .WithFileContents(expectedBytes);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void FileContents_GivenFileContentResult_ShouldHaveTheSameFileContents()
        {
            var result = TestDataGenerator.CreateFileContentResult();

            result.Should()
                .BeFileContentResult()
                .FileContents.Should().BeSameAs(result.FileContents);
        }
    }
}
