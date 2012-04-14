using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions.Assertions;
using System.Web.Mvc;

namespace FluentAssertions.Mvc3
{
    public class ContentResultAssertions : ReferenceTypeAssertions<ContentResult, ContentResultAssertions>
    {
        class Constants
        {
            public const string CommonFailMessage = "Expect {0} to be '{1}' but was '{2}'";
        }

        public ContentResultAssertions(ContentResult subject)
        {
            Subject = subject;
        }

        public ContentResultAssertions WithContent(string expectedContent)
        {
            WithContent(expectedContent, string.Empty, null);
            return this;
        }

        public ContentResultAssertions WithContent(string expectedContent, string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .ForCondition(string.Equals(Subject.Content, expectedContent, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(string.Format(Constants.CommonFailMessage, "ContentResult.Content", expectedContent, Subject.Content));

            return this;
        }

        public ContentResultAssertions WithContentType(string expectedContent)
        {
            WithContentType(expectedContent, string.Empty, null);
            return this;
        }

        public ContentResultAssertions WithContentType(string expectedContent, string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .ForCondition(string.Equals(expectedContent, Subject.ContentType, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(Constants.CommonFailMessage, "ContentResult.ContentType", expectedContent, Subject.ContentType);

            return this;
        }

        public ContentResultAssertions WithContentEncoding(Encoding expectedEncoding)
        {
            WithContentEncoding(expectedEncoding, string.Empty, null);
            return this;
        }

        public ContentResultAssertions WithContentEncoding(Encoding expectedEncoding, string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .ForCondition(expectedEncoding == Subject.ContentEncoding)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(Constants.CommonFailMessage, "ContentResult.ContentType", expectedEncoding.ToString(), Subject.ContentEncoding.ToString());

            return this;
        }
    }
}
