using System;
using System.Web.Mvc;
using FluentAssertions.Assertions;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
{
    [DebuggerNonUserCode]
	public class ActionResultAssertions : ReferenceTypeAssertions<ActionResult, ActionResultAssertions>
	{
        public struct Constants
        {
            public const string CommonFailMessage = "Expected ActionResult to be {0} but was '{1}'";
        }
        
		public ActionResultAssertions (ActionResult subject)
		{
			Subject = subject;
		}

        public ContentResultAssertions BeContent()
        {
            Execute.Verification
                    .ForCondition(Subject is ContentResult)
                    .FailWith(string.Format(Constants.CommonFailMessage, typeof(ContentResult).Name, Subject.GetType().Name));

            return new ContentResultAssertions(Subject as ContentResult);
        }

        public EmptyResult BeEmpty()
        {
            Execute.Verification
                    .ForCondition(Subject is EmptyResult)
                    .FailWith(Constants.CommonFailMessage, typeof(EmptyResult).Name, Subject.GetType().Name);

            return Subject as EmptyResult;
        }

        public RedirectToRouteAssertions BeRedirectToRoute()
        {
            Execute.Verification
                    .ForCondition(Subject is RedirectToRouteResult)
                    .FailWith(Constants.CommonFailMessage, typeof(RedirectToRouteResult).Name, Subject.GetType().Name);

            return new RedirectToRouteAssertions(Subject as RedirectToRouteResult);
        }

        public PartialViewResultAssertions BePartialView()
        {
            Execute.Verification
                    .ForCondition(Subject is PartialViewResult)
                    .FailWith(Constants.CommonFailMessage, typeof(PartialViewResult).Name, Subject.GetType().Name);

            return new PartialViewResultAssertions(Subject as PartialViewResult);
        }

        public RedirectResultAssertions BeRedirect()
        {
            Execute.Verification
                    .ForCondition(Subject is RedirectResult)
                    .FailWith(Constants.CommonFailMessage, "RedirectResult", Subject.GetType().Name);

            return new RedirectResultAssertions(Subject as RedirectResult);
        }

		public ViewResultAssertions BeView ()
		{
			Execute.Verification
					.ForCondition (Subject is ViewResult)
                    .FailWith(Constants.CommonFailMessage, "ViewResult", Subject.GetType().Name);
			
			return new ViewResultAssertions (Subject as ViewResult);
		}
	}
}
