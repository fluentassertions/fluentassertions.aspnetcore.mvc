using FluentAssertions;
using System;
using System.Web.Mvc;
using FluentAssertions.Mvc;
using System.Web.Routing;
using System.Diagnostics;

namespace FluentAssertions.Mvc
{
    [DebuggerNonUserCode]
	public static class AssertionsExtensions
	{
		public static ActionResultAssertions Should (this ActionResult actual)
		{
			return new ActionResultAssertions (actual);
		}

        public static RouteDataAssertions Should(this RouteData routeData)
        {
            return new RouteDataAssertions(routeData);
        }
	}
}
