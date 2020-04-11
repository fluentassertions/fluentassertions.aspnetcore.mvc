using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.AspNetCore.Mvc
{
    public class StatusCodeResultAssertions : ObjectAssertions
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:StatusCodeResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public StatusCodeResultAssertions(StatusCodeResult subject) : base(subject)
        {
        }

        private StatusCodeResult StatusCodeResultSubject => (StatusCodeResult) Subject;

        /// <summary>
        ///     The model.
        /// </summary>
        public int StatusCode => StatusCodeResultSubject.StatusCode;

        /// <summary>
        ///     Asserts that the status code is the expected status code.
        /// </summary>
        /// <param name="expectedStatusCode">The status code.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public StatusCodeResultAssertions WithStatusCode(int expectedStatusCode, string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(StatusCode == expectedStatusCode)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("StatusCodeResult.StatusCode")
                .FailWith(FailureMessages.CommonFailMessage2, expectedStatusCode, StatusCode);
            return this;
        }
    }
}