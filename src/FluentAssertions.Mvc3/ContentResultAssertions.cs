using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FluentAssertions.Mvc3
{
    public class ContentResultAssertions : ObjectAssertions
    {
        public ContentResultAssertions(ContentResult subject) : base(subject)
        {
        }

        public ContentResultAssertions WithContent(string expectedContent)
        {
            WithContent(expectedContent, string.Empty, null);
            return this;
        }

        public ContentResultAssertions WithContent(string expectedContent, string reason, params object[] reasonArgs)
        {
            string actualContent = (Subject as ContentResult).Content;

            Execute.Verification
                    .ForCondition(string.Equals(actualContent, expectedContent, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(string.Format(FailureMessages.CommonFailMessage, "ContentResult.Content", expectedContent, actualContent));

            return this;
        }

        public ContentResultAssertions WithContentType(string expectedContent)
        {
            WithContentType(expectedContent, string.Empty, null);
            return this;
        }

        public ContentResultAssertions WithContentType(string expectedContent, string reason, params object[] reasonArgs)
        {
            string actualContentType = (Subject as ContentResult).ContentType;

            Execute.Verification
                    .ForCondition(string.Equals(expectedContent, actualContentType, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(string.Format(FailureMessages.CommonFailMessage, "ContentResult.ContentType", expectedContent, actualContentType));

            return this;
        }

        public ContentResultAssertions WithContentEncoding(Encoding expectedEncoding)
        {
            WithContentEncoding(expectedEncoding, string.Empty, null);
            return this;
        }

        public ContentResultAssertions WithContentEncoding(Encoding expectedEncoding, string reason, params object[] reasonArgs)
        {
            Encoding actualContentEncoding = (Subject as ContentResult).ContentEncoding;

            Execute.Verification
                    .ForCondition(expectedEncoding == actualContentEncoding)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(string.Format(FailureMessages.CommonFailMessage, "ContentResult.ContentType", expectedEncoding.ToString(), actualContentEncoding.ToString()));

            return this;
        }
    }
}
