#if NETCOREAPP3_0
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that an <see cref="IConvertToActionResult"/> is in the expected state.
    /// </summary>
    public class ConvertToActionResultAssertions : ReferenceTypeAssertions<IConvertToActionResult, ConvertToActionResultAssertions>
    {
        public ConvertToActionResultAssertions(IConvertToActionResult subject)
        {
            Subject = subject;
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
                .FailWith("Expected {context} to be ActionResult<TValue> with type {0}{reason} but was {1}.", typeof(TValue), genericParameter);

            return new ActionResultAssertions<TValue>((ActionResult<TValue>)Subject);
        }
    }
}

#endif