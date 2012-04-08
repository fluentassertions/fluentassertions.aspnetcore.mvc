using System;
using System.Web.Mvc;
using FluentAssertions.Assertions;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
{
    [DebuggerNonUserCode]
	public class ActionResultAssertions : ReferenceTypeAssertions<ActionResult, ActionResultAssertions>
	{
		public ActionResultAssertions (ActionResult subject)
		{
			Subject = subject;
		}

        public PartialViewResultAssertions BePartialView()
        {
            return new PartialViewResultAssertions(Subject as PartialViewResult);
        }

		public ViewResultAssertions  BeView ()
		{
			var result = BeView (string.Empty, new object[] { });
			return result;
		}
		
		public ViewResultAssertions BeView (string reason, params object [] reasonArgs)
		{
			Execute.Verification
					.ForCondition (Subject is ViewResult)
					.BecauseOf (reason, reasonArgs)
					.FailWith ("Expected ActionResult to be View but was {0}", Subject.GetType ().Name);
			
			return new ViewResultAssertions (Subject as ViewResult);
		}

		public RedirectResult BeRedirect ()
		{
			var result = BeRedirect (string.Empty, new object[] { });
			return result;
		}
		
		public RedirectResult BeRedirect (string reason, params object [] reasonArgs)
		{
			Execute.Verification
					.ForCondition (Subject is RedirectResult)
					.BecauseOf (reason, reasonArgs)
					.FailWith ("Expected ActionResult to be RedirectResult but was {0}", Subject.GetType ().Name);
			
			return Subject as RedirectResult;
		}
	}
}
