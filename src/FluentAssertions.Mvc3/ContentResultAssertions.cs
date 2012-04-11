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
        public ContentResultAssertions(ContentResult subject)
        {
            Subject = subject;
        }
    }
}
