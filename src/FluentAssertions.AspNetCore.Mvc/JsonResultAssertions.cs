using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    ///     Contains a number of methods to assert that a <see cref="JsonResult" /> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class JsonResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:JsonResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public JsonResultAssertions(JsonResult subject) : base(subject)
        {

        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The value on the JsonResult
        /// </summary>
        public object Value => JsonResultSubject.Value;

        #endregion

        #region Private Properties

        private JsonResult JsonResultSubject => (JsonResult)Subject;

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Asserts that the value is the expected value using Equals.
        /// </summary>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        /// <returns></returns>
        public JsonResultAssertions WithValue(object expectedValue, string reason = "",
            params object[] reasonArgs)
        {
            var actualValue = JsonResultSubject.Value;

            Execute.Assertion
                .ForCondition(Equals(expectedValue, actualValue))
                .BecauseOf(reason, reasonArgs)
                .FailWith(FailureMessages.CommonFailMessage, "JsonResult.Value", expectedValue, actualValue);
            return this;
        }

        /// <summary>
        ///     Asserts the value is of the expected type.
        /// </summary>
        /// <typeparam name="TValue">The expected type.</typeparam>
        /// <returns>The typed value.</returns>
        public TValue ValueAs<TValue>()
        {
            var value = JsonResultSubject.Value;

            if (value == null)
                Execute.Assertion.FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, "Value", typeof(TValue).Name);

            Execute.Assertion
                .ForCondition(value is TValue)
                .FailWith(FailureMessages.CommonTypeFailMessage, "Value", typeof(TValue).Name, value.GetType().Name);

            return (TValue)value;
        }
        #endregion
    }
}