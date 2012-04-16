using System;
using System.Web.Mvc;
using FluentAssertions.Assertions;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
{
    [DebuggerNonUserCode]
	public class ActionResultAssertions : ObjectAssertions
	{
        public struct Constants
        {
            public const string CommonFailMessage = "Expected ActionResult to be {0}{reason}, but found {1}";
        }
        
		public ActionResultAssertions (ActionResult subject) : base(subject)
		{
			Subject = subject;
		}

        public ContentResultAssertions BeContent()
        {
            return BeContent(string.Empty, null);
        }

        public ContentResultAssertions BeContent(string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(Subject is ContentResult)
                    .FailWith(Constants.CommonFailMessage, typeof(ContentResult).Name, Subject.GetType().Name);

            return new ContentResultAssertions(Subject as ContentResult);
        }

        public EmptyResult BeEmpty()
        {
            return BeEmpty(string.Empty, null);
        }

        public EmptyResult BeEmpty(string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(Subject is EmptyResult)
                    .FailWith(Constants.CommonFailMessage, typeof(EmptyResult).Name, Subject.GetType().Name);

            return Subject as EmptyResult;
        }

        public RedirectToRouteAssertions BeRedirectToRoute()
        {
            return BeRedirectToRoute(string.Empty, null);
        }

        public RedirectToRouteAssertions BeRedirectToRoute(string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(Subject is RedirectToRouteResult)
                    .FailWith(Constants.CommonFailMessage, typeof(RedirectToRouteResult).Name, Subject.GetType().Name);

            return new RedirectToRouteAssertions(Subject as RedirectToRouteResult);
        }

        public PartialViewResultAssertions BePartialView()
        {
            return BePartialView(string.Empty, null);
        }

        public PartialViewResultAssertions BePartialView(string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(Subject is PartialViewResult)
                    .FailWith(Constants.CommonFailMessage, typeof(PartialViewResult).Name, Subject.GetType().Name);

            return new PartialViewResultAssertions(Subject as PartialViewResult);
        }

        public RedirectResultAssertions BeRedirect()
        {
            return BeRedirect(string.Empty, null);
        }

        public RedirectResultAssertions BeRedirect(string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(Subject is RedirectResult)
                    .FailWith(Constants.CommonFailMessage, "RedirectResult", Subject.GetType().Name);

            return new RedirectResultAssertions(Subject as RedirectResult);
        }

        public ViewResultAssertions BeView()
        {
            return BeView(string.Empty, null);
        }

        public ViewResultAssertions BeView(string reason, params object[] reasonArgs)
		{
			Execute.Verification
                    .BecauseOf(reason, reasonArgs)
					.ForCondition (Subject is ViewResult)
                    .FailWith(Constants.CommonFailMessage, "ViewResult", Subject.GetType().Name);
			
			return new ViewResultAssertions (Subject as ViewResult);
		}
	}
}
