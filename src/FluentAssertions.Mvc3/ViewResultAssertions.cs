using System;
using System.Web.Mvc;
using FluentAssertions.Assertions;
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
            Execute.Verification
                    .ForCondition(string.Equals(expectedMasterName, Subject.MasterName, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("Expected MasterName to be '{0}' but was '{1}'", expectedMasterName, Subject.MasterName);
            return this;
        }
	}
}
