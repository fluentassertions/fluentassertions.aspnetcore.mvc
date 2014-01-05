using FluentAssertions;
using System;
using System.Web.Mvc;
using FluentAssertions.Mvc;
using System.Web.Routing;
using System.Diagnostics;

namespace FluentAssertions.Mvc
{
    /// <summary>
    /// Contains extension methods for custom assertions in unit tests.
    /// </summary>
    [DebuggerNonUserCode]
    public static class AssertionsExtensions
    {
        /// <summary>
        /// Returns an <see cref="ActionResultAssertions"/> object that can be used to assert the
        /// current <see cref="ActionResult"/>.
        /// </summary>
        public static ActionResultAssertions Should (this ActionResult actual)
        {
            return new ActionResultAssertions (actual);
        }

        /// <summary>
        /// Returns an <see cref="RouteDataAssertions"/> object that can be used to assert the
        /// current <see cref="RouteData"/>.
        /// </summary>
        public static RouteDataAssertions Should(this RouteData routeData)
        {
            return new RouteDataAssertions(routeData);
        }
    }
}
