using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that an <see cref="IConvertToActionResult"/> is in the expected state.
    /// </summary>
    public class ConvertToActionResultAssertions : ReferenceTypeAssertions<IConvertToActionResult, ConvertToActionResultAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConvertToActionResultAssertions" /> class.
        /// </summary>
        public ConvertToActionResultAssertions(IConvertToActionResult subject) : base(subject)
        {
        }

        /// <inheritdoc />
        protected override string Identifier => "IConvertToActionResult";

        /// <summary>
        /// Asserts that the subject is a <see cref="ActionResult{TValue}"/>.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public ActionResultAssertions<TValue> BeActionResult<TValue>(string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(!(Subject is null))
                .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(ActionResult<TValue>));

            var type = Subject.GetType();

            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ActionResult<>))
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(ActionResult<TValue>), Subject.GetType());

            var genericParameter = type.GenericTypeArguments[0];

            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(genericParameter == typeof(TValue))
                .FailWith(FailureMessages.ConvertibelModelFailMessage, typeof(TValue), genericParameter);

            return new ActionResultAssertions<TValue>((ActionResult<TValue>)Subject);
        }

        /// <summary>
        /// Asserts that calling the subject's <see cref="IConvertToActionResult.Convert"/> method, 
        /// the resulting <see cref="IActionResult"/> 's type is <typeparamref name="TActionResult"/>.
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
        /// the result of Convert() converted to <typeparamref name="TActionResult"/>.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<ConvertToActionResultAssertions, TActionResult> BeConvertibleTo<TActionResult>(
            string reason = "", params object[] reasonArgs)
            where TActionResult : class, IActionResult
        {
            var convertResult = Subject.Convert();
            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(convertResult != null)
                .FailWith(FailureMessages.ConvertibleActionFailMessage, typeof(TActionResult), null);

            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(convertResult.GetType() == typeof(TActionResult))
                .FailWith(FailureMessages.ConvertibleActionFailMessage, typeof(TActionResult), convertResult.GetType());

            return new AndWhichConstraint<ConvertToActionResultAssertions, TActionResult>(this, (TActionResult)convertResult);
        }
    }
}