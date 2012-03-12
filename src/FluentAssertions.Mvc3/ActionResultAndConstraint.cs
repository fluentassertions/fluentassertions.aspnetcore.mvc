using System;
using System.Web.Mvc;

namespace FluentAssertions.Mvc
{
	public class ActionResultAndConstraint : AndConstraint<ActionResult>
	{
		public ActionResultAndConstraint (ActionResult subject) : base(subject)
		{
		}
		
		public ActionResultAndConstraint WithViewName (string viewName)
		{
			throw new NotImplementedException ();
			return this;
		}
		
		public ActionResultAndConstraint WithViewName (string viewName, string reason, params object[] reasonArgs)
		{
			return this;
		}
		
		public ActionResultAndConstraint WithControllerName (string viewName)
		{
			throw new NotImplementedException ();
			return this;
		}
		
		public ActionResultAndConstraint WithControllerName (string viewName, string reason, params object[] reasonArgs)
		{
			throw new NotImplementedException ();
			return this;
		}		
	}
}

