using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class ObjectResultAssertions_Tests
    {
        private const string TestValue = "testValue";
        private const string WrongValue = "wrongValue";

        private readonly object TestObject = new { Value = "testValue" };
        private readonly object GoodObject = new { Value = "testValue" };
        private readonly object WrongObject = new { Value = "wrongValue" };
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;

        [Fact]
        public void Value_GivenObjectResult_ShouldHaveTheSameValue()
        {
            var result = new ObjectResult(TestValue);
            result.Should().BeObjectResult().Value.Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenObjectResult_ShouldHaveTheSameValue()
        {
            var result = new ObjectResult(TestValue);

            result.Should().BeObjectResult().ValueAs<string>().Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new ObjectResult(TestValue);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                "ObjectResult.Value", typeof(int), typeof(string));

            Action a = () => result.Should().BeObjectResult().ValueAs<int>().Should().Be(2);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new ObjectResult(null);
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "ObjectResult.Value", typeof(object));

            Action a = () => result.Should().BeObjectResult().ValueAs<object>();

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsFormatter_GivenExpected_ShouldPass()
        {
            var formatterMock = new Mock<IOutputFormatter>();
            var result = new ObjectResult(TestValue)
            {
                Formatters = { formatterMock.Object }
            };

            result.Should().BeObjectResult().ContainsFormatter(formatter => ReferenceEquals(formatter, formatterMock.Object));
        }

        [Fact]
        public void ContainsFormatter_OnNullFormatters_ShouldFail()
        {
            var result = new ObjectResult(TestValue)
            {
                Formatters = null
            };
            Expression<Func<IOutputFormatter, bool>> expectation = formatter => formatter == null;
            string failureMessage = FailureMessageHelper.ExpectedToContainItemButFoundNull(
                "ObjectResult.Formatters",
                expectation.Body);

            Action a = () => result.Should().BeObjectResult().ContainsFormatter(expectation, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsFormatter_GivenUnexpected_ShouldFail()
        {
            var formatterMock = new Mock<IOutputFormatter>();
            var result = new ObjectResult(TestValue)
            {
                Formatters = { formatterMock.Object }
            };
            string failureMessage = FailureMessageHelper.ExpectedToHaveItemMatching(
                "ObjectResult.Formatters",
                result.Formatters,
                "False");

            Action a = () => result.Should().BeObjectResult().ContainsFormatter(formatter => false, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithContentType_GivenExpected_ShouldPass()
        {
            var mediaType = "text/html";
            var result = new ObjectResult(TestValue)
            {
                ContentTypes = { mediaType }
            };

            result.Should().BeObjectResult().WithContentType(mediaType);
        }
#if NETCOREAPP2_1
        // In NetCore3.1 ContentTypes cant be null.
        [Fact]
        public void WithContentType_OnNullMediaType_ShouldFail()
        {
            var expected = "text/json";
            var result = new ObjectResult(TestValue)
            {
                ContentTypes = null
            };
            string failureMessage = FailureMessageHelper.ExpectedToContainItemButFoundNull(
                "ObjectResult.ContentTypes",
                expected);

            Action a = () => result.Should().BeObjectResult().WithContentType(expected, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
#endif
        [Fact]
        public void WithContentType_GivenUnexpected_ShouldFail()
        {
            var mediaType = "text/html";
            var expected = "text/json";
            var result = new ObjectResult(TestValue)
            {
                ContentTypes = { mediaType }
            };
            string failureMessage = FailureMessageHelper.ExpectedToContainItem(
                "ObjectResult.ContentTypes",
                result.ContentTypes,
                expected);

            Action a = () => result.Should().BeObjectResult().WithContentType(expected, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithDeclaredType_GivenExpected_ShouldPass()
        {
            var expectedType = typeof(string);
            var result = new ObjectResult(TestValue)
            {
                DeclaredType = expectedType
            };

            result.Should().BeObjectResult().WithDeclaredType(expectedType);
        }

        [Fact]
        public void WithDeclaredType_GivenUnexpected_ShouldFail()
        {
            var expectedType = typeof(int);
            var declaredType = typeof(string);
            var result = new ObjectResult(TestValue)
            {
                DeclaredType = declaredType
            };
            string failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundYWithReason(
                "ObjectResult.DeclaredType",
                expectedType,
                declaredType);

            Action a = () => result.Should().BeObjectResult().WithDeclaredType(expectedType, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithStatusCode_GivenExpected_ShouldPass()
        {
            var expectedStatusCode = 200;
            var result = new ObjectResult(TestValue)
            {
                StatusCode = expectedStatusCode
            };

            result.Should().BeObjectResult().WithStatusCode(expectedStatusCode);
        }

        [Fact]
        public void WithStatusCode_GivenUnexpected_ShouldFail()
        {
            var expectedStatusCode = 200;
            var actualStatusCode = 500;
            var result = new ObjectResult(TestValue)
            {
                StatusCode = actualStatusCode
            };
            string failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "ObjectResult.StatusCode",
                expectedStatusCode,
                actualStatusCode);

            Action a = () => result.Should().BeObjectResult().WithStatusCode(expectedStatusCode, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithValue_GivenExpected_ShouldPass()
        {
            var result = new ObjectResult(TestValue);

            result.Should().BeObjectResult()
                .WithValue(TestValue);
        }

        [Fact]
        public void WithValue_GivenUnexpected_ShouldFail()
        {
            var result = new ObjectResult(WrongValue);
            string failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "ObjectResult.Value",
                TestValue,
                WrongValue);

            Action a = () => result.Should().BeObjectResult().WithValue(TestValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithValueEquivalentTo_GivenExpected_ShouldPass()
        {
            var result = new ObjectResult(TestObject);

            result.Should().BeObjectResult()
                .WithValueEquivalentTo(GoodObject);
        }

        [Fact]
        public void WithValueEquivalentTo_GivenUnexpected_ShouldFail()
        {
            var result = new ObjectResult(WrongObject);
#if DEBUG
            var actualRef = "actualValue";
#else
            var actualRef = "root";
#endif
            string failureMessage = $@"Expected property {actualRef}.Value to be ""testValue"" with a length of 9 because it is 10, but ""wrongValue"" has a length of 10, differs near ""wro"" (index 0).

With configuration:
- Use declared types and members
- Compare enums by value
- Compare tuples by their properties
- Compare anonymous types by their properties
- Compare records by their members
- Match member by name (or throw)
- Be strict about the order of items in byte arrays
- Without automatic conversion.
";

            Action a = () => result.Should().BeObjectResult().WithValueEquivalentTo(GoodObject, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

        [Fact]
        public void WithValueMatch_GivenExpected_ShouldPass()
        {
            var result = new ObjectResult(TestValue);

            result.Should().BeObjectResult()
                .WithValueMatch<string>(value => value == TestValue);
        }

        [Fact]
        public void WithValueMatch_GivenUnexpected_ShouldFail()
        {
            var result = new ObjectResult(WrongValue);
            string failureMessage = "Expected ObjectResult.Value to match (value == \"testValue\") because it is 10, but found \"wrongValue\".";

            Action a = () => result.Should().BeObjectResult().WithValueMatch<string>(value => value == TestValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }

    }
}
