using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class AcceptedResultAssertions_Tests
    {
        private const string TestValue = "testValue";
        
        private const string TestUriAsString = "http://localhost:5000";
        private const string TestWrongUriAsString = "http://somedomain.com:5000";
        
        private readonly Uri TestUri = new Uri(TestUriAsString);
        private readonly Uri TestWrongUri = new Uri(TestWrongUriAsString);

        [Fact]
        public void Value_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().Accepted(TestUri, TestValue);
            result.Should().BeAcceptedResult().Value.Should().Be(TestValue);
        }

        [Fact]
        public void Value_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().Accepted(TestUri, TestValue);
            Action a = () => result.Should().BeAcceptedResult().Value.Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().Accepted(TestUri, TestValue);
            result.Should().BeAcceptedResult().ValueAs<string>().Should().Be(TestValue);
        }

        [Fact]
        public void ValueAs_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().Accepted(TestUri, TestValue);
            Action a = () => result.Should().BeAcceptedResult().ValueAs<string>().Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().Accepted(TestUri, TestValue);
            Action a = () => result.Should().BeAcceptedResult().ValueAs<int>().Should().Be(2);
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new AcceptedResult(TestUri, null);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonNullWasSuppliedFailMessage, "AcceptedResultAssertions.Value", typeof(object).Name);
            Action a = () => result.Should().BeAcceptedResult().ValueAs<object>();
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithUri_GivenExpectedUri_ShouldPass()
        {
            var result = new TestController().Accepted(TestUri, TestValue);

            result.Should().BeAcceptedResult().WithUri(TestUri);
        }

        [Fact]
        public void WithUri_GivenWrongUri_ShouldFail()
        {
            var result = new TestController().Accepted(TestWrongUri, TestValue);
            Action a = () => result.Should().BeAcceptedResult().WithUri(TestUri);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "AcceptedResultAssertions.Uri", TestUri.ToString(), TestWrongUri.ToString());
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithUri_GivenExpectedUriAsString_ShouldPass()
        {
            var result = new TestController().Accepted(TestUriAsString, TestValue);

            result.Should().BeAcceptedResult().WithUri(TestUriAsString);
        }

        [Fact]
        public void WithUri_GivenWrongUriAsString_ShouldFail()
        {
            var result = new TestController().Accepted(TestWrongUriAsString, TestValue);
            Action a = () => result.Should().BeAcceptedResult().WithUri(TestUriAsString);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "AcceptedResultAssertions.Uri", TestUriAsString, TestWrongUriAsString);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
