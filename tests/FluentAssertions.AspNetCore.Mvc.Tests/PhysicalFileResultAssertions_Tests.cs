using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class PhysicalFileResultAssertions_Tests
    {
        private const string TestPhysicalPath = "TestPhysicalPath";
        private const string TestContentType = "text/html";
        private const string TestFileDownloadName = "TestFileDownloadName";
        private readonly DateTimeOffset? TestLastModified = DateTimeOffset.Now;
        private readonly EntityTagHeaderValue TestEntityTag = new EntityTagHeaderValue("\"0815\"");

        [Fact]
        public void WithPhysicalPath_GivenExpected_ShouldPass()
        {
            ActionResult result = new PhysicalFileResult(TestPhysicalPath, TestContentType);
            result.Should().BePhysicalFileResult().WithPhysicalPath(TestPhysicalPath);
        }

        [Fact]
        public void WithPhysicalPath_GivenUnexpected_ShouldFail()
        {
            var actualPhysicalPath = TestPhysicalPath;
            var expectedPhysicalPath = "xyz";
            ActionResult result = new PhysicalFileResult(actualPhysicalPath, TestContentType);
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "PhysicalFileResult.PhysicalPath", expectedPhysicalPath, actualPhysicalPath);
            Action a = () => result.Should().BePhysicalFileResult().WithPhysicalPath(expectedPhysicalPath);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithContentType_GivenExpected_ShouldPass()
        {
            ActionResult result = new PhysicalFileResult(string.Empty, TestContentType);
            result.Should().BePhysicalFileResult().WithContentType(TestContentType);
        }

        [Fact]
        public void WithContentType_GivenUnexpected_ShouldFail()
        {
            var actualContentType = TestContentType;
            var expectedContentType = "xyz";
            ActionResult result = new PhysicalFileResult(string.Empty, actualContentType);
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "PhysicalFileResult.ContentType", expectedContentType, actualContentType);
            Action a = () => result.Should().BePhysicalFileResult().WithContentType(expectedContentType);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithFileDownloadName_GivenExpected_ShouldPass()
        {
            ActionResult result = new PhysicalFileResult(string.Empty, TestContentType) { FileDownloadName = TestFileDownloadName };
            result.Should().BePhysicalFileResult().WithFileDownloadName(TestFileDownloadName);
        }

        [Fact]
        public void WithFileDownloadName_GivenUnexpected_ShouldFail()
        {
            var actualFileDownloadName = TestFileDownloadName;
            var expectedFileDownloadName = "xyz";
            ActionResult result = new PhysicalFileResult(string.Empty, TestContentType) { FileDownloadName = actualFileDownloadName };
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "PhysicalFileResult.FileDownloadName", expectedFileDownloadName, actualFileDownloadName);
            Action a = () => result.Should().BePhysicalFileResult().WithFileDownloadName(expectedFileDownloadName);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithLastModified_GivenExpected_ShouldPass()
        {
            ActionResult result = new PhysicalFileResult(string.Empty, TestContentType) { LastModified = TestLastModified };
            result.Should().BePhysicalFileResult().WithLastModified(TestLastModified);
        }

        [Fact]
        public void WithLastModified_GivenNull_ShouldPass()
        {
            var actualLastModified = null as DateTimeOffset?;
            var expectedLastModified = null as DateTimeOffset?;
            ActionResult result = new PhysicalFileResult(string.Empty, TestContentType) { LastModified = actualLastModified };
            result.Should().BePhysicalFileResult().WithLastModified(expectedLastModified);
        }

        [Fact]
        public void WithLastModified_GivenActualNull_ShouldFail()
        {
            var actualLastModified = null as DateTimeOffset?;
            var expectedLastModified = DateTimeOffset.Now;
            ActionResult result = new PhysicalFileResult(string.Empty, TestContentType) { LastModified = actualLastModified };
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "PhysicalFileResult.LastModified", expectedLastModified, actualLastModified);
            Action a = () => result.Should().BePhysicalFileResult().WithLastModified(expectedLastModified);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithLastModified_GivenExpectedNull_ShouldFail()
        {
            var actualLastModified = DateTimeOffset.Now;
            var expectedLastModified = null as DateTimeOffset?;
            ActionResult result = new PhysicalFileResult(string.Empty, TestContentType) { LastModified = actualLastModified };
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "PhysicalFileResult.LastModified", expectedLastModified, actualLastModified);
            Action a = () => result.Should().BePhysicalFileResult().WithLastModified(expectedLastModified);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithLastModified_GivenUnexpected_ShouldFail()
        {
            var actualLastModified = TestLastModified;
            var expectedLastModified = DateTimeOffset.Now.AddMilliseconds(1);
            ActionResult result = new PhysicalFileResult(string.Empty, TestContentType) { LastModified = actualLastModified };
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "PhysicalFileResult.LastModified", expectedLastModified, actualLastModified);
            Action a = () => result.Should().BePhysicalFileResult().WithLastModified(expectedLastModified);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithEntityTag_GivenExpected_ShouldPass()
        {
            ActionResult result = new PhysicalFileResult(string.Empty, TestContentType) { EntityTag = TestEntityTag };
            result.Should().BePhysicalFileResult().WithEntityTag(TestEntityTag);
        }

        [Fact]
        public void WithEntityTag_GivenUnexpected_ShouldFail()
        {
            var actualEntityTag = TestEntityTag;
            var expectedEntityTag = new EntityTagHeaderValue("\"1234\"");
            ActionResult result = new PhysicalFileResult(string.Empty, TestContentType) { EntityTag = actualEntityTag };
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "PhysicalFileResult.EntityTag", expectedEntityTag, actualEntityTag);
            Action a = () => result.Should().BePhysicalFileResult().WithEntityTag(expectedEntityTag);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
