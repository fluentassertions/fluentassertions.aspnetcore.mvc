using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class ChallengeResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;
        private readonly DateTimeOffset? TestLastModified = DateTimeOffset.Parse("2020-04-28 15:48:33.6672395 +2", CultureInfo.InvariantCulture);

        [Fact]
        public void WithAuthenticationProperties_GivenExpected_ShouldPass()
        {
            var actualAuthenticationProperties = new AuthenticationProperties();
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);

            result.Should().BeChallengeResult().WithAuthenticationProperties(actualAuthenticationProperties);
        }

        [Fact]
        public void WithAuthenticationProperties_GivenUnexpected_ShouldFail()
        {
            var actualAuthenticationProperties = new AuthenticationProperties();
            var expectedAuthenticationProperties = new AuthenticationProperties();
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.AuthenticationPropertiesExpectations(result);

            Action a = () => result.Should().BeChallengeResult().WithAuthenticationProperties(expectedAuthenticationProperties, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIsPersistent_GivenExpected_ShouldPass()
        {
            var actualIsPersistent = true;
            var actualAuthenticationProperties = new AuthenticationProperties { IsPersistent = actualIsPersistent };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);

            result.Should().BeChallengeResult().WithIsPersistent(actualIsPersistent);
        }

        [Fact]
        public void WithIsPersistent_GivenUnexpected_ShouldFail()
        {
            var actualIsPersistent = true;
            var expectedIsPersistent = false;
            var actualAuthenticationProperties = new AuthenticationProperties { IsPersistent = actualIsPersistent };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("ChallengeResult.AuthenticationProperties.IsPersistent", expectedIsPersistent, actualIsPersistent);

            Action a = () => result.Should().BeChallengeResult().WithIsPersistent(expectedIsPersistent, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRedirectUri_GivenExpected_ShouldPass()
        {
            var actualRedirectUri = "redirectUri";
            var actualAuthenticationProperties = new AuthenticationProperties { RedirectUri = actualRedirectUri };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);

            result.Should().BeChallengeResult().WithRedirectUri(actualRedirectUri);
        }

        [Fact]
        public void WithRedirectUri_GivenUnexpected_ShouldFail()
        {
            var actualRedirectUri = "redirectUri";
            var expectedRedirectUri = "otherUri";
            var actualAuthenticationProperties = new AuthenticationProperties { RedirectUri = actualRedirectUri };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("ChallengeResult.AuthenticationProperties.RedirectUri", expectedRedirectUri, actualRedirectUri);

            Action a = () => result.Should().BeChallengeResult().WithRedirectUri(expectedRedirectUri, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenExpected_ShouldPass()
        {
            var actualIssuedUtc = TestLastModified;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);

            result.Should().BeChallengeResult().WithIssuedUtc(actualIssuedUtc);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_ShouldPass()
        {
            var actualIssuedUtc = null as DateTimeOffset?;
            var expectedIssuedUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);

            result.Should().BeChallengeResult().WithIssuedUtc(expectedIssuedUtc);
        }

        [Fact]
        public void WithIssuedUtc_GivenUnexpected_ShouldFail()
        {
            var actualIssuedUtc = TestLastModified;
            var expectedIssuedUtc = TestLastModified.Value.AddSeconds(1);
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedExpectedIssuedUtc = FailureMessageHelper.RoundToSeconds(expectedIssuedUtc);
            var convertedActualIssuedUtc = FailureMessageHelper.RoundToSeconds(actualIssuedUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("ChallengeResult.AuthenticationProperties.IssuedUtc", convertedExpectedIssuedUtc, convertedActualIssuedUtc);

            Action a = () => result.Should().BeChallengeResult().WithIssuedUtc(expectedIssuedUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_For_Actual_ShouldFail()
        {
            var actualIssuedUtc = null as DateTimeOffset?;
            var expectedIssuedUtc = TestLastModified;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedExpectedIssuedUtc = FailureMessageHelper.RoundToSeconds(expectedIssuedUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("ChallengeResult.AuthenticationProperties.IssuedUtc", convertedExpectedIssuedUtc, null);

            Action a = () => result.Should().BeChallengeResult().WithIssuedUtc(expectedIssuedUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_For_Expected_ShouldFail()
        {
            var actualIssuedUtc = TestLastModified;
            var expectedIssuedUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedActualIssuedUtc = FailureMessageHelper.RoundToSeconds(actualIssuedUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("ChallengeResult.AuthenticationProperties.IssuedUtc", null, convertedActualIssuedUtc);

            Action a = () => result.Should().BeChallengeResult().WithIssuedUtc(expectedIssuedUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenExpected_ShouldPass()
        {
            var actualExpiresUtc = TestLastModified;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);

            result.Should().BeChallengeResult().WithExpiresUtc(actualExpiresUtc);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_ShouldPass()
        {
            var actualExpiresUtc = null as DateTimeOffset?;
            var expectedExpiresUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);

            result.Should().BeChallengeResult().WithExpiresUtc(expectedExpiresUtc);
        }

        [Fact]
        public void WithExpiresUtc_GivenUnexpected_ShouldFail()
        {
            var actualExpiresUtc = TestLastModified;
            var expectedExpiresUtc = TestLastModified.Value.AddSeconds(1);
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedExpectedExpiresUtc = FailureMessageHelper.RoundToSeconds(expectedExpiresUtc);
            var convertedActualExpiresUtc = FailureMessageHelper.RoundToSeconds(actualExpiresUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("ChallengeResult.AuthenticationProperties.ExpiresUtc", convertedExpectedExpiresUtc, convertedActualExpiresUtc);

            Action a = () => result.Should().BeChallengeResult().WithExpiresUtc(expectedExpiresUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_For_Actual_ShouldFail()
        {
            var actualExpiresUtc = null as DateTimeOffset?;
            var expectedExpiresUtc = TestLastModified;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedExpectedExpiresUtc = FailureMessageHelper.RoundToSeconds(expectedExpiresUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("ChallengeResult.AuthenticationProperties.ExpiresUtc", convertedExpectedExpiresUtc, null);

            Action a = () => result.Should().BeChallengeResult().WithExpiresUtc(expectedExpiresUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_For_Expected_ShouldFail()
        {
            var actualExpiresUtc = TestLastModified;
            var expectedExpiresUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedActualExpiresUtc = FailureMessageHelper.RoundToSeconds(actualExpiresUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("ChallengeResult.AuthenticationProperties.ExpiresUtc", null, convertedActualExpiresUtc);

            Action a = () => result.Should().BeChallengeResult().WithExpiresUtc(expectedExpiresUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithAllowRefresh_GivenExpected_ShouldPass()
        {
            var actualAllowRefresh = true;
            var actualAuthenticationProperties = new AuthenticationProperties { AllowRefresh = actualAllowRefresh };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);

            result.Should().BeChallengeResult().WithAllowRefresh(actualAllowRefresh);
        }

        [Fact]
        public void WithAllowRefresh_GivenUnexpected_ShouldFail()
        {
            var actualAllowRefresh = true;
            var expectedAllowRefresh = false;
            var actualAuthenticationProperties = new AuthenticationProperties { AllowRefresh = actualAllowRefresh };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("ChallengeResult.AuthenticationProperties.AllowRefresh", expectedAllowRefresh, actualAllowRefresh);

            Action a = () => result.Should().BeChallengeResult().WithAllowRefresh(expectedAllowRefresh, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsItem_GivenExpected_ShouldPass()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            var properties = new Dictionary<string, string> { { testKey, testValue } };
            var actualAuthenticationProperties = new AuthenticationProperties(properties);
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);

            result.Should().BeChallengeResult().ContainsItem(testKey, testValue, Reason, ReasonArgs);
        }

        [Fact]
        public void ContainsItem_GivenNull_ShouldFail()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            ActionResult result = new ChallengeResult();
            var failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButFoundNull(
                "ChallengeResult.AuthenticationProperties.Items", testValue, testKey);

            Action a = () => result.Should().BeChallengeResult().ContainsItem(testKey, testValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsItem_GivenUnexpectedKey_ShouldFail()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            const string expectedKey = "wrong key";
            var properties = new Dictionary<string, string> { { testKey, testValue } };
            var actualAuthenticationProperties = new AuthenticationProperties(properties);
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButKeyNotFound(
                    "ChallengeResult.AuthenticationProperties.Items", testValue, expectedKey);

            Action a = () => result.Should().BeChallengeResult().ContainsItem(expectedKey, testValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsItem_GivenUnexpectedValue_ShouldFail()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            const string expectedValue = "wrong value";
            var properties = new Dictionary<string, string> { { testKey, testValue } };
            var actualAuthenticationProperties = new AuthenticationProperties(properties);
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY(
                "ChallengeResult.AuthenticationProperties.Items", testKey, expectedValue, testValue);

            Action a = () => result.Should().BeChallengeResult().ContainsItem(testKey, expectedValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithAuthenticationSchemes_GivenExpected_ShouldPass()
        {
            var actualAuthenticationSchemes = new List<string> { "one", "two" };
            var expectedAuthenticationSchemes = new List<string> { "two", "one" };
            ActionResult result = new ChallengeResult(actualAuthenticationSchemes);

            result.Should().BeChallengeResult().WithAuthenticationSchemes(expectedAuthenticationSchemes);
        }

        [Fact]
        public void WithAuthenticationSchemes_GivenUnexpected_ShouldFail()
        {
            var actualAuthenticationSchemes = new List<string>() { "one", "two", "three" };
            var expectedAuthenticationSchemes = new List<string> { "three", "four", "five" };
            ActionResult result = new ChallengeResult(actualAuthenticationSchemes);
            var failureMessage = string.Format(FailureMessages.CommonListsNotIdentical, "ChallengeResult.AuthenticationSchemes");

            Action a = () => result.Should().BeChallengeResult().WithAuthenticationSchemes(expectedAuthenticationSchemes, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsScheme_GivenExpected_ShouldPass()
        {
            const string testScheme = "testScheme";
            var actualSchemes = new List<string> { testScheme };
            ActionResult result = new ChallengeResult(actualSchemes);

            result.Should().BeChallengeResult().ContainsScheme(testScheme);
        }

        [Fact]
        public void ContainsScheme_GivenUnexpected_ShouldFail()
        {
            const string testScheme = "testScheme";
            const string expectedScheme = "expectedScheme";
            var actualSchemes = new List<string> { testScheme };
            ActionResult result = new ChallengeResult(actualSchemes);
            var failureMessage = string.Format(FailureMessages.CommonAuthenticationSchemesContainScheme, expectedScheme);

            Action a = () => result.Should().BeChallengeResult().ContainsScheme(expectedScheme, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
