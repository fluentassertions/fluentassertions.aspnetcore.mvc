using FluentAssertions.AspNetCore.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class VirtualFileResultAssertions_Tests
    {

        [Fact]
        public void WithFileName_GivenExpectedValue_ShouldPass()
        {
            var actualFileName = "Test1.txt";
            var expectedFileName = string.Copy(actualFileName);
            ActionResult result = TestDataGenerator.CreateVirtualFileResult(actualFileName);

            result.Should()
                .BeVirtualFileResult()
                .WithFileName(expectedFileName);
        }

        [Fact]
        public void WithFileName_GivenUnexpectedValue_ShouldFail()
        {
            string actualFileName = "Test1.txt";
            string expectedFileName = "Test2.txt";
            ActionResult result = TestDataGenerator.CreateVirtualFileResult(actualFileName);
            var failureMessage = "Expected \"VirtualFileResult.FileName\" to be '\"Test2.txt\"' but found '\"Test1.txt\"'";

            Action a = () => result.Should()
                .BeVirtualFileResult()
                .WithFileName(expectedFileName);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void FileName_GivenVirtualFileResult_ShouldHaveTheFileName()
        {
            var result = TestDataGenerator.CreateVirtualFileResult();

            result.Should()
                .BeVirtualFileResult()
                .FileName
                .Should().BeSameAs(result.FileName);
        }
    }
}
