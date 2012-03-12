using System;
using System.Web.Mvc;

namespace FluentAssertions.Mvc.Tests.Fakes
{
	public class FakeController : Controller
	{
		private ActionResult _indexResult;
		
		public FakeController (ActionResult indexResult)
		{
			_indexResult = indexResult;
		}
		
		public ActionResult Index ()
		{
			return _indexResult;
		}
	}
}
