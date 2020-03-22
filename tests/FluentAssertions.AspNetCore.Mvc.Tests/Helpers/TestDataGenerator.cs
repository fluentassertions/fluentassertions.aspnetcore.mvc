using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentAssertions.AspNetCore.Mvc.Tests.Helpers
{
    public static class TestDataGenerator
    {
        public static FileContentResult CreateFileContentResult(string content = "", string contentType = "text/plain")
        {
            return CreateFileContentResult(CreateBytes(content), contentType);
        }

        public static FileContentResult CreateFileContentResult(byte[] fileContents, string contentType = "text/plain")
        {
            return new FileContentResult(fileContents, contentType);
        }

        public static FileStreamResult CreateFileStreamResult(string content = "")
        {
            return CreateFileStreamResult(CreateStream(content));
        }

        public static PhysicalFileResult CreatePhysicalFileResult(string fileName = "c:\\temp.txt")
        {
            return new PhysicalFileResult(fileName, "text/plain");
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

        public static DateTimeOffset? CreateDateTimeOffset(string dateText)
        {
            if (dateText == null)
                return null;
            var match = dateRegex.Match(dateText);
            return new DateTimeOffset(
                DateTime.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture),
                TimeSpan.FromHours(int.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture)));
        }

        private static readonly Regex dateRegex
            = new Regex(@"^(\d{4}-\d{2}-\d{2} \d{1,2}:\d{2}:\d{2}) (-?\d+)h$");

    }
}
