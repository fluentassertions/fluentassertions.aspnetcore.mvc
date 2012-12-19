using FluentAssertions;
using System;
using System.Web.Mvc;
using FluentAssertions.Mvc3;
using System.Web.Routing;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
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
