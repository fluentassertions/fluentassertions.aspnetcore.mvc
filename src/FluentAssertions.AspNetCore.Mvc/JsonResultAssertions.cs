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
        ///     Initializes a new instance of the <see cref="JsonResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public JsonResultAssertions(JsonResult subject) : base(subject)
        {

        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The <see cref="JsonResult.SerializerSettings"/> on the tested subject.
        /// </summary>
#if NETCOREAPP3_0
        public object SerializerSettings => JsonResultSubject.SerializerSettings;
#else
        public Newtonsoft.Json.JsonSerializerSettings SerializerSettings => JsonResultSubject.SerializerSettings;
#endif


        /// <summary>
        /// The <see cref="JsonResult.Value"/> on the tested subject.
        /// </summary>
        public object Value => JsonResultSubject.Value;

        #endregion

        #region Private Properties

        private JsonResult JsonResultSubject => (JsonResult)Subject;

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Asserts that the content type is the expected content type.
        /// </summary>
        /// <param name="expectedContentType">The expected content type.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public JsonResultAssertions WithContentType(string expectedContentType, string reason = "",
            params object[] reasonArgs)
        {
            var actualContentType = JsonResultSubject.ContentType;

            Execute.Assertion
                .ForCondition(string.Equals(expectedContentType, actualContentType, StringComparison.OrdinalIgnoreCase))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("JsonResult.ContentType")
                .FailWith(FailureMessages.CommonFailMessage, expectedContentType, actualContentType);
            return this;
        }

        /// <summary>
        ///     Asserts that the status code is the expected status code.
        /// </summary>
        /// <param name="expectedStatusCode">The expected status code.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public JsonResultAssertions WithStatusCode(int? expectedStatusCode, string reason = "",
            params object[] reasonArgs)
        {
            var actualStatusCode = JsonResultSubject.StatusCode;

            Execute.Assertion
                .ForCondition(expectedStatusCode == actualStatusCode)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("JsonResult.StatusCode")
                .FailWith(FailureMessages.CommonFailMessage, expectedStatusCode, actualStatusCode);
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
                Execute.Assertion
                    .WithDefaultIdentifier("JsonResult.Value")
                    .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(TValue));

            Execute.Assertion
                .ForCondition(value is TValue)
                .WithDefaultIdentifier("JsonResult.Value")
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(TValue), value.GetType());

            return (TValue)value;
        }
        #endregion
    }
}