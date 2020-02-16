using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FluentAssertions.AspNetCore.Mvc
{
    public class JsonResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        public JsonResultAssertions(JsonResult subject) : base(subject)
        {

        }

        #endregion

        #region Public Properties

        #endregion

        #region Private Properties

        private JsonResult JsonResultSubject => (JsonResult)Subject;

        #endregion Private Properties

        #region Public Methods

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

        #endregion
    }
}