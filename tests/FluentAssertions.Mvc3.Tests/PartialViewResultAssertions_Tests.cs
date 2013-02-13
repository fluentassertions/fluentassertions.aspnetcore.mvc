using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;

namespace FluentAssertions.Mvc.Tests
{
    [TestFixture]
    public class PartialViewResultAssertions_Tests
    {
        [Test]
        public void WithDefaultViewName_GivenExpectedValue_ShouldPass()
        {
            ActionResult result = new PartialViewResult
            {
                ViewName = String.Empty
            };

            result.Should().BePartialViewResult().WithDefaultViewName();
        }
    }
}
