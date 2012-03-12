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
		public void BeView_GivenViewResult_ShouldPass ()
		{
			var controller = new FakeController (new ViewResult ());
			controller.Index ().Should ().BeView ();
		}
		
		[Test]
		public void BeView_GivenViewResultWithExpectedName_ShouldPass ()
		{
			var controller = new FakeController (new ViewResult { ViewName = "Index"});
			controller.Index ().Should ().BeView ();
		}
		
		[Test]
		public void BeView_GivenRedirection_ShouldFail ()
		{
			var controller = new FakeController (new RedirectResult ("/"));
			Action action = () => controller.Index ().Should ().BeView ();
			action.ShouldThrow<AssertionException> ().WithMessage ("Expected ActionResult to be ViewResult but was \"RedirectResult\"");
		}
	}
}
