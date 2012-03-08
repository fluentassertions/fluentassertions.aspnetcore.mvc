using System;
using System.Web.Mvc;
using FluentAssertions.Assertions;

namespace FluentAssertions.Mvc
{
	public class ActionResultAssertions : ReferenceTypeAssertions<ActionResult, ActionResultAssertions>
	{
		public ActionResultAssertions (ActionResult subject)
		{
			Subject = subject;
		}
		
		public AndConstraint<ActionResultAssertions> BeView()
		{
			var andConstraint = BeView(string.Empty, new object[] { });
			return andConstraint;
		}
		
		public AndConstraint<ActionResultAssertions> BeView(string reason, params object [] reasonArgs)
		{
			Execute.Verification
					.ForCondition(Subject is ViewResult)
					.BecauseOf(reason, reasonArgs)
					.FailWith("Expected ActionResult to be View but was {0}", Subject.GetType().Name);
			
			return new AndConstraint<ActionResultAssertions> (this);
		}		
	}
}
