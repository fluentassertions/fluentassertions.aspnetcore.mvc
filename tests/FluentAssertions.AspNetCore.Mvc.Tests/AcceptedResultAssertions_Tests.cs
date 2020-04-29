using System;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{
    public class AcceptedResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;

        private const string TestValue = "testValue";
        
        private const string TestUriAsString = "http://localhost:5000";
        private const string TestWrongUriAsString = "http://somedomain.com:5000";
        
        private readonly Uri TestUri = new Uri(TestUriAsString);
        private readonly Uri TestWrongUri = new Uri(TestWrongUriAsString);

        [Fact]
        public void Value_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().Accepted(TestUri, TestValue);

            result.Should().BeAcceptedResult().Value.Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenExpectedValue_ShouldPass()
        {
            var result = new TestController().Accepted(TestUri, TestValue);
            result.Should().BeAcceptedResult().ValueAs<string>().Should().BeSameAs(TestValue);
        }

        [Fact]
        public void ValueAs_GivenWrongType_ShouldFail()
        {
            var result = new TestController().Accepted(TestUri, TestValue);
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundY(
                "AcceptedResultAssertions.Value", typeof(int), typeof(string));

            Action a = () => result.Should().BeAcceptedResult().ValueAs<int>().Should().Be(2);

            a.Should().Throw<Exception>();
        }

        [Fact]
        public void ValueAs_Null_ShouldFail()
        {
            ActionResult result = new AcceptedResult(TestUri, null);
            var failureMessage = FailureMessageHelper.ExpectedContextTypeXButFoundNull(
                "AcceptedResultAssertions.Value", typeof(object));

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
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("AcceptedResultAssertions.Uri", TestUri.ToString(), TestWrongUri.ToString());

            Action a = () => result.Should().BeAcceptedResult().WithUri(TestUri, Reason, ReasonArgs);
            
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
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("AcceptedResultAssertions.Uri", TestUriAsString, TestWrongUriAsString);

            Action a = () => result.Should().BeAcceptedResult().WithUri(TestUriAsString, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
