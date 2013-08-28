using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Web.Mvc;
using System.Diagnostics;

namespace FluentAssertions.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="ViewResultBase"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public abstract class ViewResultBaseAssertions<T> : ObjectAssertions
        where T : ViewResultBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ViewResultBaseAssertions" /> class.
        /// </summary>
        public ViewResultBaseAssertions(ViewResultBase subject) : base(subject)
        {
            Subject = (T)subject;
        }

        /// <summary>
        /// Asserts that the view name is the expected view name.
        /// </summary>
        /// <param name="expectedViewName">The view name.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ViewResultBaseAssertions<T> WithViewName(string expectedViewName, string reason = "", params object[] reasonArgs)
        {
            string actualViewName = (Subject as ViewResultBase).ViewName;

            Execute.Assertion
                    .ForCondition(string.Equals(expectedViewName, actualViewName, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.ViewResultBase_ViewName, expectedViewName, actualViewName);
            return this;
        }

        /// <summary>
        /// Asserts that the view data contains the expected data.
        /// </summary>
        /// <param name="key">The expected view data key.</param>
        /// <param name="expectedValue">The expected view data.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ViewResultBaseAssertions<T> WithViewData(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            ViewDataDictionary actualViewData = (Subject as ViewResultBase).ViewData;

            Execute.Assertion
                    .ForCondition(actualViewData.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.ViewResultBase_ViewData_ContainsKey, key);

            var actualValue = actualViewData[key];

            Execute.Assertion
                    .ForCondition(actualValue.Equals(expectedValue))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.ViewResultBase_ViewData_HaveValue, key, expectedValue, actualValue); 

            return this;
        }

        /// <summary>
        /// Asserts that the temp data contains the expected data.
        /// </summary>
        /// <param name="key">The expected temp data key.</param>
        /// <param name="expectedValue">The expected temp data.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ViewResultBaseAssertions<T> WithTempData(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            TempDataDictionary actualTempData = (Subject as ViewResultBase).TempData;

            Execute.Assertion
                    .ForCondition(actualTempData.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("TempData does not contain key of '{0}'", key);

            actualTempData[key].Should().Be(expectedValue);

            return this;
        }

        
        /// <summary>
        /// The model.
        /// </summary>
        public object Model
        {
            get
            {
                var model = (Subject as ViewResult).Model;
                return model;
            }
        }

        /// <summary>
        /// Asserts the model is of the expected type.
        /// </summary>
        /// <typeparam name="TModel">The expected type.</typeparam>
        /// <returns>The typed model.</returns>
        public TModel ModelAs<TModel>()
        {
            object model = (Subject as ViewResultBase).Model;

            if (model == null)
                Execute.Assertion.FailWith(FailureMessages.ViewResultBase_NullModel, typeof(TModel).Name);

            Execute.Assertion
                    .ForCondition(model is TModel)
                    .FailWith("Expected Model to be of type '{0}' but was '{1}'", typeof(TModel).Name, model.GetType().Name);

            return (TModel)model;
        }

        /// <summary>
        /// Asserts that the default view will be used.
        /// </summary>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="reason" />.
        /// </param>
        public ViewResultBaseAssertions<T> WithDefaultViewName(string reason = "", params object[] reasonArgs)
        {
            string viewName = (Subject as ViewResultBase).ViewName;

            Execute.Assertion
                    .ForCondition(viewName == string.Empty)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith(FailureMessages.ViewResultBase_WithDefaultViewName, viewName);
            
            return this;
        }
    }
}
