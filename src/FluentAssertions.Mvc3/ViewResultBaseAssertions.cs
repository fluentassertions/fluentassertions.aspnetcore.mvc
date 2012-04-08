using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions.Assertions;
using System.Web.Mvc;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
{
    [DebuggerNonUserCode]
    public abstract class ViewResultBaseAssertions<T> : ReferenceTypeAssertions<T, ViewResultBaseAssertions<T>>
        where T : ViewResultBase
    {
        public ViewResultBaseAssertions(ViewResultBase subject)
        {
            Subject = (T)subject;
        }

        public ViewResultBaseAssertions<T> WithViewName(string expectedViewName)
        {
            WithViewName(expectedViewName, string.Empty, null);
            return this;
        }

        public ViewResultBaseAssertions<T> WithViewName(string expectedViewName, string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .ForCondition(string.Equals(expectedViewName, Subject.ViewName, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("Expected ViewName to be '{0}' but was '{1}'", expectedViewName, Subject.ViewName);
            return this;
        }

        public ViewResultBaseAssertions<T> WithViewData(string key, object expectedValue)
        {
            WithViewData(key, expectedValue, string.Empty, null);
            return this;
        }

        public ViewResultBaseAssertions<T> WithViewData(string key, object expectedValue, string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .ForCondition(Subject.ViewData.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("ViewData does not contain key of '{0}'", key);

            Subject.ViewData[key].Should().Be(expectedValue);

            return this;
        }

        public ViewResultBaseAssertions<T> WithTempData(string key, object expectedValue)
        {
            WithTempData(key, expectedValue, string.Empty, null);
            return this;
        }

        public ViewResultBaseAssertions<T> WithTempData(string key, object expectedValue, string reason, params object[] reasonArgs)
        {
            Execute.Verification
                    .ForCondition(Subject.TempData.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("TempData does not contain key of '{0}'", key);

            Subject.TempData[key].Should().Be(expectedValue);

            return this;
        }

        public object Model
        {
            get
            {
                return Subject.Model;
            }
        }

        public TModel ModelAs<TModel>()
        {
            Execute.Verification
                    .ForCondition(Subject.Model is TModel)
                    .FailWith("Expected Model to be of type '{0}' but was '{1}'", typeof(TModel).Name, Subject.Model.GetType().Name);

            return (TModel)Subject.Model;
        }
    }
}
