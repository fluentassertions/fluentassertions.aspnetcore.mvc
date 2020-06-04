using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
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
        /// Returns an <see cref="ActionResultAssertions"/> object that can be used to assert the
        /// current <see cref="IActionResult"/>.
        /// </summary>
        public static ActionResultAssertions Should (this IActionResult actual)
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

#if NETCOREAPP3_0

        /// <summary>
        /// Returns an <see cref="ConvertToActionResultAssertions"/> object that can be used to assert the
        /// current <see cref="IConvertToActionResult"/>.
        /// </summary>
        public static ConvertToActionResultAssertions Should(this IConvertToActionResult actual)
        {
            return new ConvertToActionResultAssertions(actual);
        }

#endif
    }
}
