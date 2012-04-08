using System;
using System.Web.Mvc;

namespace FluentAssertions.Mvc.Tests.Fakes
{
	public class FakeController : Controller
	{
        public ActionResult IndexReturn { get; set; }

		public ActionResult Index ()
		{
			return IndexReturn;
		}
	}
}
