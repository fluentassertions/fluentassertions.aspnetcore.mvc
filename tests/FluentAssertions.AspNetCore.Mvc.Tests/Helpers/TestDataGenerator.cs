using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace FluentAssertions.AspNetCore.Mvc.Tests.Helpers
{
    public static class TestDataGenerator
    {
        public static FileContentResult CreateFileContentResult(string content = "")
        {
            return CreateFileContentResult(CreateBytes(content));
        }

        public static FileContentResult CreateFileContentResult(byte[] fileContents)
        {
            return new FileContentResult(fileContents, "text/plain");
        }

        public static FileStreamResult CreateFileStreamResult(string content = "")
        {
            return CreateFileStreamResult(CreateStream(content));
        }

        public static FileStreamResult CreateFileStreamResult(Stream stream)
        {
            return new FileStreamResult(stream, "text/plain");
        }

        public static Stream CreateStream(string content = "")
        {
            var memoryStream = new MemoryStream();
            var bytes = CreateBytes(content);
            memoryStream.Write(bytes, 0, bytes.Length);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }

        public static byte[] CreateBytes(string content = "")
        {
            var bytes = Encoding.UTF8.GetBytes(content);
            return bytes;
        }
    }
}
