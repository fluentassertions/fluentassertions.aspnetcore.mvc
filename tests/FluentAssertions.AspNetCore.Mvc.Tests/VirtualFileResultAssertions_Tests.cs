using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class VirtualFileResultAssertions_Tests
    {
        private const string TestFileName = "TestFileName";
        private const string TestContentType = "text/html";
        private const string TestFileDownloadName = "TestFileDownloadName";
        private readonly DateTimeOffset? TestLastModified = DateTimeOffset.Now;
        private readonly EntityTagHeaderValue TestEntityTag = new EntityTagHeaderValue("\"0815\"");

        [Fact]
        public void WithFileName_GivenExpected_ShouldPass()
        {
            ActionResult result = new VirtualFileResult(TestFileName, TestContentType);
            result.Should().BeVirtualFileResult().WithFileName(TestFileName);
        }

        [Fact]
        public void WithFileName_GivenUnexpected_ShouldFail()
        {
            var actualFileName = TestFileName;
            var expectedFileName = "xyz";
            ActionResult result = new VirtualFileResult(actualFileName, TestContentType);
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.FileName", expectedFileName, actualFileName);
            Action a = () => result.Should().BeVirtualFileResult().WithFileName(expectedFileName);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithContentType_GivenExpected_ShouldPass()
        {
            ActionResult result = new VirtualFileResult(string.Empty, TestContentType);
            result.Should().BeVirtualFileResult().WithContentType(TestContentType);
        }

        [Fact]
        public void WithContentType_GivenUnexpected_ShouldFail()
        {
            var actualContentType = TestContentType;
            var expectedContentType = "xyz";
            ActionResult result = new VirtualFileResult(string.Empty, actualContentType);
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.ContentType", expectedContentType, actualContentType);
            Action a = () => result.Should().BeVirtualFileResult().WithContentType(expectedContentType);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithFileDownloadName_GivenExpected_ShouldPass()
        {
            ActionResult result = new VirtualFileResult(string.Empty, TestContentType) { FileDownloadName = TestFileDownloadName };
            result.Should().BeVirtualFileResult().WithFileDownloadName(TestFileDownloadName);
        }

        [Fact]
        public void WithFileDownloadName_GivenUnexpected_ShouldFail()
        {
            var actualFileDownloadName = TestFileDownloadName;
            var expectedFileDownloadName = "xyz";
            ActionResult result = new VirtualFileResult(string.Empty, TestContentType) { FileDownloadName = actualFileDownloadName };
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.FileDownloadName", expectedFileDownloadName, actualFileDownloadName);
            Action a = () => result.Should().BeVirtualFileResult().WithFileDownloadName(expectedFileDownloadName);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithLastModified_GivenExpected_ShouldPass()
        {
            ActionResult result = new VirtualFileResult(string.Empty, TestContentType) { LastModified = TestLastModified };
            result.Should().BeVirtualFileResult().WithLastModified(TestLastModified);
        }

        [Fact]
        public void WithLastModified_GivenNull_ShouldPass()
        {
            var actualLastModified = null as DateTimeOffset?;
            var expectedLastModified = null as DateTimeOffset?;
            ActionResult result = new VirtualFileResult(string.Empty, TestContentType) { LastModified = actualLastModified };
            result.Should().BeVirtualFileResult().WithLastModified(expectedLastModified);
        }

        [Fact]
        public void WithLastModified_GivenActualNull_ShouldFail()
        {
            var actualLastModified = null as DateTimeOffset?;
            var expectedLastModified = DateTimeOffset.Now;
            ActionResult result = new VirtualFileResult(string.Empty, TestContentType) { LastModified = actualLastModified };
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.LastModified", expectedLastModified, actualLastModified);
            Action a = () => result.Should().BeVirtualFileResult().WithLastModified(expectedLastModified);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithLastModified_GivenExpectedNull_ShouldFail()
        {
            var actualLastModified = DateTimeOffset.Now;
            var expectedLastModified = null as DateTimeOffset?;
            ActionResult result = new VirtualFileResult(string.Empty, TestContentType) { LastModified = actualLastModified };
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.LastModified", expectedLastModified, actualLastModified);
            Action a = () => result.Should().BeVirtualFileResult().WithLastModified(expectedLastModified);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithLastModified_GivenUnexpected_ShouldFail()
        {
            var actualLastModified = TestLastModified;
            var expectedLastModified = DateTimeOffset.Now.AddMilliseconds(1);
            ActionResult result = new VirtualFileResult(string.Empty, TestContentType) { LastModified = actualLastModified };
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.LastModified", expectedLastModified, actualLastModified);
            Action a = () => result.Should().BeVirtualFileResult().WithLastModified(expectedLastModified);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithEntityTag_GivenExpected_ShouldPass()
        {
            ActionResult result = new VirtualFileResult(string.Empty, TestContentType) { EntityTag = TestEntityTag };
            result.Should().BeVirtualFileResult().WithEntityTag(TestEntityTag);
        }

        [Fact]
        public void WithEntityTag_GivenUnexpected_ShouldFail()
        {
            var actualEntityTag = TestEntityTag;
            var expectedEntityTag = new EntityTagHeaderValue("\"1234\"");
            ActionResult result = new VirtualFileResult(string.Empty, TestContentType) { EntityTag = actualEntityTag };
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "VirtualFileResult.EntityTag", expectedEntityTag, actualEntityTag);
            Action a = () => result.Should().BeVirtualFileResult().WithEntityTag(expectedEntityTag);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
