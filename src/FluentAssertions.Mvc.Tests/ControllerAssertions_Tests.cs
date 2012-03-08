using System;
using NUnit.Framework;
using FluentAssertions.Mvc.Tests.Fakes;
using System.Web.Mvc;

namespace FluentAssertions.Mvc.Tests
{
	[TestFixture]
	public class ActionResultAssertions_Tests
	{		
		[Test]
		public void BeView_GivenView_ShouldPass()
		{
			var controller = new FakeController (new ViewResult ());		
			controller.Index().Should().BeView();
		}
	}
}
