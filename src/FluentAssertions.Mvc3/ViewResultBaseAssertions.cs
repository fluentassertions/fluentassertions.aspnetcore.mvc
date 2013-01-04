using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Web.Mvc;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
{
    [DebuggerNonUserCode]
    public abstract class ViewResultBaseAssertions<T> : ObjectAssertions
        where T : ViewResultBase
    {
        public ViewResultBaseAssertions(ViewResultBase subject) : base(subject)
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
            string actualViewName = (Subject as ViewResultBase).ViewName;

            Execute.Verification
                    .ForCondition(string.Equals(expectedViewName, actualViewName, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.ViewResultBase_ViewName, expectedViewName, actualViewName);
            return this;
        }

        public ViewResultBaseAssertions<T> WithViewData(string key, object expectedValue)
        {
            WithViewData(key, expectedValue, string.Empty, null);
            return this;
        }

        public ViewResultBaseAssertions<T> WithViewData(string key, object expectedValue, string reason, params object[] reasonArgs)
        {
            ViewDataDictionary actualViewData = (Subject as ViewResultBase).ViewData;

            Execute.Verification
                    .ForCondition(actualViewData.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.ViewResultBase_ViewData_ContainsKey, key);

            var actualValue = actualViewData[key];

            Execute.Verification
                    .ForCondition(actualValue.Equals(expectedValue))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.ViewResultBase_ViewData_HaveValue, key, expectedValue, actualValue); 

            return this;
        }

        public ViewResultBaseAssertions<T> WithTempData(string key, object expectedValue)
        {
            WithTempData(key, expectedValue, string.Empty, null);
            return this;
        }

        public ViewResultBaseAssertions<T> WithTempData(string key, object expectedValue, string reason, params object[] reasonArgs)
        {
            TempDataDictionary actualTempData = (Subject as ViewResultBase).TempData;

            Execute.Verification
                    .ForCondition(actualTempData.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("TempData does not contain key of '{0}'", key);

            actualTempData[key].Should().Be(expectedValue);

            return this;
        }

        public object Model
        {
            get
            {
                var model = (Subject as ViewResult).Model;
                return model;
            }
        }

        public TModel ModelAs<TModel>()
        {
            object model = (Subject as ViewResultBase).Model;

            if (model == null)
                Execute.Verification.FailWith(FailureMessages.ViewResultBase_NullModel, typeof(TModel).Name);

            Execute.Verification
                    .ForCondition(model is TModel)
                    .FailWith("Expected Model to be of type '{0}' but was '{1}'", typeof(TModel).Name, model.GetType().Name);

            return (TModel)model;
        }

        public ViewResultBaseAssertions<T> WithDefaultViewName()
        {
            WithDefaultView(string.Empty, null);
            return this;
        }

        public ViewResultBaseAssertions<T> WithDefaultView(string reason, params object[] reasonArgs)
        {
            string viewName = (Subject as ViewResultBase).ViewName;

            Execute.Verification
                    .ForCondition(viewName == string.Empty)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.ViewResultBase_WithDefaultViewName, viewName);
            
            return this;
        }
    }
}
