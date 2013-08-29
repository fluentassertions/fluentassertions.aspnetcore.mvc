using FluentAssertions.Primitives;
using FluentAssertions.Execution;
using System;
using System.Web.Mvc;
using System.Diagnostics;

namespace FluentAssertions.Mvc
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

        public ContentResultAssertions BeContentResult()
        {
            return BeContentResult(string.Empty, null);
        }

        public ContentResultAssertions BeContentResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(Subject is ContentResult)
                    .FailWith(Constants.CommonFailMessage, typeof(ContentResult).Name, Subject.GetType().Name);

            return new ContentResultAssertions(Subject as ContentResult);
        }

        public EmptyResult BeEmptyResult()
        {
            return BeEmptyResult(string.Empty, null);
        }

        public EmptyResult BeEmptyResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(Subject is EmptyResult)
                    .FailWith(Constants.CommonFailMessage, typeof(EmptyResult).Name, Subject.GetType().Name);

            return Subject as EmptyResult;
        }

        public RedirectToRouteAssertions BeRedirectToRouteResult()
        {
            return BeRedirectToRouteResult(string.Empty, null);
        }

        public RedirectToRouteAssertions BeRedirectToRouteResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(Subject is RedirectToRouteResult)
                    .FailWith(Constants.CommonFailMessage, typeof(RedirectToRouteResult).Name, Subject.GetType().Name);

            return new RedirectToRouteAssertions(Subject as RedirectToRouteResult);
        }

        public PartialViewResultAssertions BePartialViewResult()
        {
            return BePartialViewResult(string.Empty, null);
        }

        public PartialViewResultAssertions BePartialViewResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(Subject is PartialViewResult)
                    .FailWith(Constants.CommonFailMessage, typeof(PartialViewResult).Name, Subject.GetType().Name);

            return new PartialViewResultAssertions(Subject as PartialViewResult);
        }

        public RedirectResultAssertions BeRedirectResult()
        {
            return BeRedirectResult(string.Empty, null);
        }

        public RedirectResultAssertions BeRedirectResult(string reason, params object[] reasonArgs)
        {
            Execute.Assertion
                    .BecauseOf(reason, reasonArgs)
                    .ForCondition(Subject is RedirectResult)
                    .FailWith(Constants.CommonFailMessage, "RedirectResult", Subject.GetType().Name);

            return new RedirectResultAssertions(Subject as RedirectResult);
        }

        public ViewResultAssertions BeViewResult()
        {
            return BeViewResult(string.Empty, null);
        }

        public ViewResultAssertions BeViewResult(string reason, params object[] reasonArgs)
		{
			Execute.Assertion
                    .BecauseOf(reason, reasonArgs)
					.ForCondition (Subject is ViewResult)
                    .FailWith(Constants.CommonFailMessage, "ViewResult", Subject.GetType().Name);
			
			return new ViewResultAssertions (Subject as ViewResult);
		}
	}
}
