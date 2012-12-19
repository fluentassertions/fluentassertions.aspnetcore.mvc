using FluentAssertions.Execution;
using System;
using System.Web.Mvc;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
{
    [DebuggerNonUserCode]
	public class ViewResultAssertions : ViewResultBaseAssertions<ViewResult>
	{
		public ViewResultAssertions (ViewResult subject) : base(subject) { }

        public ViewResultAssertions WithMasterName(string expectedMasterName)
        {
            WithMasterName(expectedMasterName, string.Empty, null);
            return this;
        }

        public ViewResultAssertions WithMasterName(string expectedMasterName, string reason, params object[] reasonArgs)
        {
            string actualMasterName = (Subject as ViewResult).MasterName;

            Execute.Verification
                    .ForCondition(string.Equals(expectedMasterName, actualMasterName, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("Expected MasterName to be '{0}' but was '{1}'", expectedMasterName, actualMasterName);
            return this;
        }
	}
}
