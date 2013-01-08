using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Diagnostics;
using FluentAssertions.Primitives;

namespace FluentAssertions.Mvc
{
    [DebuggerNonUserCode]
    public class PartialViewResultAssertions : ObjectAssertions
    {
        public PartialViewResultAssertions(PartialViewResult viewResult) : base(viewResult) { }
    }
}
