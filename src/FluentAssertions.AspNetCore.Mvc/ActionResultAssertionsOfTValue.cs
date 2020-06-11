using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that an <see cref="ActionResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class ActionResultAssertions<TValue> : ReferenceTypeAssertions<ActionResult<TValue>, ActionResultAssertions<TValue>>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionResultAssertions{TValue}" /> class.
        /// </summary>
        public ActionResultAssertions(ActionResult<TValue> subject)
        {
            Subject = subject;
        }

        #endregion Public Constructors

        #region Protected Properties

        /// <inheritdoc />
        protected override string Identifier { get; } = $"ActionResult<{typeof(TValue).Name}>";

        #endregion Protected Properties

        #region Public Properties

        /// <summary>
        /// Gets the <see cref="ActionResult{TValue}.Result"/> of the Subject.
        /// </summary>
        public ActionResult Result => Subject.Result;

        /// <summary>
        /// Gets the <see cref="ActionResult{TValue}.Value"/> of the Subject.
        /// </summary>
        public TValue Value => Subject.Value;

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Asserts that the <see cref="ActionResult{TValue}.Result"/> is type of <typeparamref name="TActionResult"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        /// <returns>
        /// An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}"/> where the Which contains 
        /// the result of Result converted to <typeparamref name="TActionResult"/>.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<ActionResultAssertions<TValue>, TActionResult> ConvertibleTo<TActionResult>(
            string reason = "", params object[] reasonArgs)
            where TActionResult : ActionResult
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(Result.GetType() == typeof(TActionResult))
                .FailWith(FailureMessages.ConvertibleActionFailMessage, typeof(TActionResult), Result.GetType());

            return new AndWhichConstraint<ActionResultAssertions<TValue>, TActionResult>(this, (TActionResult)Result);
        }
    }
    #endregion Public Methods
}
