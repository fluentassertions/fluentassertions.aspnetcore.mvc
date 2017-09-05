using System;
#if NETCOREAPP1_0
using Microsoft.AspNetCore.Mvc;
#else
using System.Web.Mvc;
#endif
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
