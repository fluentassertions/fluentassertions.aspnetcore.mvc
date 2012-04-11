using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions.Assertions;
using System.Web.Mvc;

namespace FluentAssertions.Mvc3
{
    public class RedirectToRouteAssertions : ReferenceTypeAssertions<RedirectToRouteResult, RedirectToRouteAssertions>
    {
        public RedirectToRouteAssertions(RedirectToRouteResult subject)
        {
            Subject = subject;
        }
    }
}
