using FluentAssertions.Execution;
using System;
using System.Web.Mvc;
using System.Diagnostics;

namespace FluentAssertions.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="ViewResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class ViewResultAssertions : ViewResultBaseAssertions<ViewResult>
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ViewResultAssertions" /> class.
        /// </summary>
		public ViewResultAssertions (ViewResult subject) : base(subject) { }

        /// <summary>
        /// Asserts that the master name is the expected master name.
        /// </summary>
        /// <param name="expectedMasterName">The expected master name.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ViewResultAssertions WithMasterName(string expectedMasterName, string reason = "", params object[] reasonArgs)
        {
            string actualMasterName = (Subject as ViewResult).MasterName;

            Execute.Verification
                    .ForCondition(string.Equals(expectedMasterName, actualMasterName, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.ViewResult_MasterName, expectedMasterName, actualMasterName);
            return this;
        }
	}
}
