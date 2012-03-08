using FluentAssertions;
using FluentAssertions.Assertions;
using System;
using System.Web.Mvc;

namespace FluentAssertions.Mvc
{
	public static class AssertionsExtensions
	{
		public static ActionResultAssertions Should (this ActionResult subject)
		{
			return new ActionResultAssertions (subject);
		}
	}
}
