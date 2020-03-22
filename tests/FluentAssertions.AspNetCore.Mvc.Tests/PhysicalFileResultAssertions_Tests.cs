using FluentAssertions.AspNetCore.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class PhysicalFileResultAssertions_Tests
    {

        [Fact]
        public void WithFileName_GivenExpectedValue_ShouldPass()
        {
            var actualFileName = "Test1.txt";
            var expectedFileName = string.Copy(actualFileName);
            ActionResult result = TestDataGenerator.CreatePhysicalFileResult(actualFileName);

            result.Should()
                .BePhysicalFileResult()
                .WithFileName(expectedFileName);
        }

        [Fact]
        public void WithFileName_GivenUnexpectedValue_ShouldFail()
        {
            string actualFileName = "Test1.txt";
            string expectedFileName = "Test2.txt";
            ActionResult result = TestDataGenerator.CreatePhysicalFileResult(actualFileName);
            var failureMessage = "Expected \"PhysicalFileResult.FileName\" to be '\"Test2.txt\"' but found '\"Test1.txt\"'";

            Action a = () => result.Should()
                .BePhysicalFileResult()
                .WithFileName(expectedFileName);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void FileStream_GivenFileStreamResult_ShouldHaveTheSameStream()
        {
            var result = TestDataGenerator.CreatePhysicalFileResult();

            result.Should()
                .BePhysicalFileResult()
                .FileName
                .Should().BeSameAs(result.FileName);
        }
    }
}
