using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
{
    [DebuggerNonUserCode]
    public class PartialViewResultAssertions : ViewResultBaseAssertions<PartialViewResult>
    {
        public PartialViewResultAssertions(PartialViewResult viewResult) : base(viewResult) { }
    }
}
