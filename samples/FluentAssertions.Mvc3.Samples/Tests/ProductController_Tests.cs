using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using System.Web.Mvc;
using FluentAssertions.Mvc3.Samples.Controllers;
using FluentAssertions.Mvc3;
using FluentAssertions;

namespace FluentAssertions.Mvc3.Samples.Tests
{
    [TestFixture]
    public class ProductController_Tests
    {
        [Test]
		public void Index_ShouldReturnView()
		{
            var controller = new ProductController();
            controller.Index()
                .Should()
                .BeView();
		}
    }
}