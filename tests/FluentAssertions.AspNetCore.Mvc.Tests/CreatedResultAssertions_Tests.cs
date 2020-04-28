using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class CreatedResultAssertions_Tests
    {
        private const string TestValue = "testValue";
        
        private const string TestUriAsString = "http://localhost:5000";
        private const string TestWrongUriAsString = "http://somedomain.com:5000";
        
        private Uri TestUri = new Uri(TestUriAsString);
        private Uri TestWrongUri = new Uri(TestWrongUriAsString);

        [Fact]
        public void Value_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().Created(TestUri, TestValue);
            result.Should().BeCreatedResult().Value.Should().Be(TestValue);
        }

        [Fact]
        public void Value_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().Created(TestUri, TestValue);
            Action a = () => result.Should().BeCreatedResult().Value.Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().Created(TestUri, TestValue);
            result.Should().BeCreatedResult().ValueAs<string>().Should().Be(TestValue);
        }

        [Fact]
        public void ValueAs_GivenUnexpectedValue_ShouldFail()
        {
            var result = new TestController().Created(TestUri, TestValue);
            Action a = () => result.Should().BeCreatedResult().ValueAs<string>().Should().Be("xyx");
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().Created(TestUri, TestValue);
            Action a = () => result.Should().BeCreatedResult().ValueAs<int>().Should().Be(2);
            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new CreatedResult(TestUri, null);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonNullWasSuppliedFailMessage, "CreatedResult.Value", typeof(object).Name);
            Action a = () => result.Should().BeCreatedResult().ValueAs<object>();
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithUri_GivenExpectedUri_ShouldPass()
        {
            var result = new TestController().Created(TestUri, TestValue);
            Action a = () => result.Should().BeCreatedResult().WithUri(TestUri);
        }

        [Fact]
        public void WithUri_GivenWrongUri_ShouldFail()
        {
            var result = new TestController().Created(TestWrongUri, TestValue);
            Action a = () => result.Should().BeCreatedResult().WithUri(TestUri);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "CreatedResult.Uri", TestUri.ToString(), TestWrongUri.ToString());
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithUri_GivenExpectedUriAsString_ShouldPass()
        {
            var result = new TestController().Created(TestUriAsString, TestValue);
            Action a = () => result.Should().BeCreatedResult().WithUri(TestUriAsString);
        }

        [Fact]
        public void WithUri_GivenWrongUriAsString_ShouldFail()
        {
            var result = new TestController().Created(TestWrongUriAsString, TestValue);
            Action a = () => result.Should().BeCreatedResult().WithUri(TestUriAsString);
            var failureMessage = FailureMessageHelper.Format(FailureMessages.CommonFailMessage, "CreatedResult.Uri", TestUriAsString, TestWrongUriAsString);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
