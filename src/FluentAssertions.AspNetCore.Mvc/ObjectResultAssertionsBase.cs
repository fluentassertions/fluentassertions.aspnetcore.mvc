using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Base class for <see cref="ObjectResultAssertions"/>.
    /// </summary>
    [DebuggerNonUserCode]
    public class ObjectResultAssertionsBase<TObjectResult, TObjectResultAssertion> : ObjectAssertions
        where TObjectResult : ObjectResult
        where TObjectResultAssertion : ObjectResultAssertionsBase<TObjectResult, TObjectResultAssertion>
    {
        #region Public Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public ObjectResultAssertionsBase(TObjectResult subject)
            : base(subject)
        {

        }
        #endregion

        #region Public Properties

        /// <summary>
        ///     The value on the ObjectResult
        /// </summary>
        public object Value => ObjectResultSubject.Value;

        #endregion

        #region Protected Properties

        /// <inheritdoc />
        protected override string Identifier => typeof(TObjectResult).Name;
        /// <summary>
        /// The <see cref="ReferenceTypeAssertions{TSubject, TAssertions}.Subject"/> casted to the correct type.
        /// </summary>
        protected TObjectResult ObjectResultSubject => (TObjectResult)Subject;

        #endregion

        #region Public Methods
        /// <summary>
        ///     Asserts the value is of the expected type.
        /// </summary>
        /// <typeparam name="TValue">The expected type.</typeparam>
        /// <returns>The typed value.</returns>
        public TValue ValueAs<TValue>()
        {
            var value = ObjectResultSubject.Value;

            if (value == null)
                Execute.Assertion
                    .WithDefaultIdentifier($"{Identifier}.Value")
                    .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(TValue));

            Execute.Assertion
                .ForCondition(value is TValue)
                .WithDefaultIdentifier($"{Identifier}.Value")
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(TValue), value.GetType());

            return (TValue)value;
        }

        /// <summary>
        /// Asserts that the <see cref="ObjectResult.Formatters"/> contains at least one item that matches the predicate.
        /// </summary>
        /// <param name="expectation">A predicate to match the items in the <see cref="ObjectResult.Formatters"/> against.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TObjectResultAssertion ContainsFormatter(Expression<Func<IOutputFormatter, bool>> expectation, string reason = "", params object[] reasonArgs)
        {
            if (expectation is null)
                throw new ArgumentNullException(nameof(expectation));

            var formatters = ObjectResultSubject.Formatters;

            if (formatters is null)
            {
                Execute.Assertion
                    .BecauseOf(reason, reasonArgs)
                    .WithDefaultIdentifier(Identifier + ".Formatters")
                    .FailWith("Expected {context} to contain {0}{reason} but found {1}.", expectation.Body, formatters);
            }

            var func = expectation.Compile();

            Execute.Assertion
                .ForCondition(formatters.Any(func))
                .WithDefaultIdentifier(Identifier+ ".Formatters")
                .BecauseOf(reason, reasonArgs)
                .FailWith("Expected {context} {0} to have an item matching {1}{reason}.", formatters, expectation.Body);

            return (TObjectResultAssertion)this;
        }

        /// <summary>
        /// Asserts that the <see cref="ObjectResult.ContentTypes"/> contains the specified content type.
        /// </summary>
        /// <param name="expected">The expectation content type.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TObjectResultAssertion WithContentType(string expected, string reason = "", params object[] reasonArgs)
        {
            var contentTypes = ObjectResultSubject.ContentTypes;

            if (contentTypes is null)
            {
                Execute.Assertion
                    .BecauseOf(reason, reasonArgs)
                    .WithDefaultIdentifier(Identifier + ".ContentTypes")
                    .FailWith("Expected {context} to contain {0}{reason} but found {1}.", expected, contentTypes);
            }

            Execute.Assertion
                .ForCondition(contentTypes.Contains(expected))
                .WithDefaultIdentifier(Identifier + ".ContentTypes")
                .BecauseOf(reason, reasonArgs)
                .FailWith("Expected {context} {0} to contain {1}{reason}.", contentTypes, expected);

            return (TObjectResultAssertion)this;
        }

        /// <summary>
        /// Asserts that the <see cref="ObjectResult.DeclaredType"/> is the expected declared type.
        /// </summary>
        /// <param name="expectedDeclaredType">The expected declared type.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TObjectResultAssertion WithDeclaredType(Type expectedDeclaredType, string reason = "", params object[] reasonArgs)
        {
            var actual = ObjectResultSubject.DeclaredType;

            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(expectedDeclaredType == actual)
                .WithDefaultIdentifier(Identifier + ".DeclaredType")
                .FailWith(FailureMessages.CommonTypeFailMessage, expectedDeclaredType, actual);

            return (TObjectResultAssertion)this;
        }

        /// <summary>
        /// Asserts that the <see cref="ObjectResult.Value"/> is the expected value.
        /// </summary>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TObjectResultAssertion WithValue(object expectedValue, string reason = "", params object[] reasonArgs)
        {
            object actualValue = ObjectResultSubject.Value;

            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(actualValue.IsSameOrEqualTo(expectedValue))
                .WithDefaultIdentifier(Identifier + ".Value")
                .FailWith(FailureMessages.CommonFailMessage, expectedValue, actualValue);

            return (TObjectResultAssertion)this;
        }

        /// <summary>
        /// Asserts that the <see cref="ObjectResult.Value"/> is equivalent to another object.
        /// </summary>
        /// <param name="expectation">The expected value.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TObjectResultAssertion WithValueEquivalentTo<TExpectation>(TExpectation expectation,
            string reason = "", params object[] reasonArgs)
        {
            return WithValueEquivalentTo(expectation, config => config, reason, reasonArgs);
        }

        /// <summary>
        /// Asserts that the <see cref="ObjectResult.Value"/> is equivalent to another object.
        /// </summary>
        /// <param name="expectation">The expected status code.</param>
        /// <param name="config">
        /// A reference to the <see cref="EquivalencyAssertionOptions{TSubject}"/> configuration object that can be used
        /// to influence the way the object graphs are compared. You can also provide an alternative instance of the
        /// <see cref="EquivalencyAssertionOptions{TSubject}"/> class. The global defaults are determined by the
        /// <see cref="AssertionOptions"/> class.
        /// </param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TObjectResultAssertion WithValueEquivalentTo<TExpectation>(TExpectation expectation,
            Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>> config, string reason = "", params object[] reasonArgs)
        {
            object actualValue = ObjectResultSubject.Value;

            actualValue.Should().BeEquivalentTo(expectation, config, reason, reasonArgs);

            return (TObjectResultAssertion)this;
        }


        /// <summary>
        /// Asserts that the <see cref="ObjectResult.Value"/> statisfies the <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">
        /// The predicate which must be satisfied by the <see cref="ObjectResult.Value"/>.
        /// </param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TObjectResultAssertion WithValueMatch<TExpectation>(Expression<Func<TExpectation, bool>> predicate,
            string reason = "", params object[] reasonArgs)
        {
            object actualValue = ValueAs<TExpectation>();

            using(var scope = new AssertionScope(Identifier + ".Value"))
            {
                actualValue.Should().Match(predicate, reason, reasonArgs);
            }

            return (TObjectResultAssertion)this;
        }

        /// <summary>
        /// Asserts that the <see cref="ObjectResult.StatusCode"/> is the expected status code.
        /// </summary>
        /// <param name="expectedStatusCode">The expected status code.</param>
        /// <param name="reason">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public TObjectResultAssertion WithStatusCode(int? expectedStatusCode, string reason = "", params object[] reasonArgs)
        {
            var actual = ObjectResultSubject.StatusCode;

            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(expectedStatusCode == actual)
                .WithDefaultIdentifier(Identifier + ".StatusCode")
                .FailWith(FailureMessages.CommonFailMessage, expectedStatusCode, actual);

            return (TObjectResultAssertion)this;
        }
        #endregion

    }
}
