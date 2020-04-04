using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class ChallengeResultAssertions_Tests
    {
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
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "ChallengeResult.AuthenticationProperties", expectedAuthenticationProperties, actualAuthenticationProperties);

            Action a = () => result.Should().BeChallengeResult().WithAuthenticationProperties(expectedAuthenticationProperties);
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
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "ChallengeResult.AuthenticationProperties.IsPersistent", expectedIsPersistent, actualIsPersistent);

            Action a = () => result.Should().BeChallengeResult().WithIsPersistent(expectedIsPersistent);
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
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "ChallengeResult.AuthenticationProperties.RedirectUri", expectedRedirectUri, actualRedirectUri);

            Action a = () => result.Should().BeChallengeResult().WithRedirectUri(expectedRedirectUri);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenExpected_ShouldPass()
        {
            var actualIssuedUtc = DateTimeOffset.Now;
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
            var actualIssuedUtc = DateTimeOffset.Now;
            var expectedIssuedUtc = DateTimeOffset.Now.AddSeconds(1);
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedExpectedIssuedUtc = GetConvertedDateTimeOffset(expectedIssuedUtc);
            var convertedActualIssuedUtc = GetConvertedDateTimeOffset(actualIssuedUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "ChallengeResult.AuthenticationProperties.IssuedUtc", convertedExpectedIssuedUtc, convertedActualIssuedUtc);

            Action a = () => result.Should().BeChallengeResult().WithIssuedUtc(expectedIssuedUtc);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_For_Actual_ShouldFail()
        {
            var actualIssuedUtc = null as DateTimeOffset?;
            var expectedIssuedUtc = DateTimeOffset.Now;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedExpectedIssuedUtc = GetConvertedDateTimeOffset(expectedIssuedUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "ChallengeResult.AuthenticationProperties.IssuedUtc", convertedExpectedIssuedUtc, null);

            Action a = () => result.Should().BeChallengeResult().WithIssuedUtc(expectedIssuedUtc);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_For_Expected_ShouldFail()
        {
            var actualIssuedUtc = DateTimeOffset.Now;
            var expectedIssuedUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedActualIssuedUtc = GetConvertedDateTimeOffset(actualIssuedUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "ChallengeResult.AuthenticationProperties.IssuedUtc", null, convertedActualIssuedUtc);

            Action a = () => result.Should().BeChallengeResult().WithIssuedUtc(expectedIssuedUtc);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenExpected_ShouldPass()
        {
            var actualExpiresUtc = DateTimeOffset.Now;
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
            var actualExpiresUtc = DateTimeOffset.Now;
            var expectedExpiresUtc = DateTimeOffset.Now.AddSeconds(1);
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedExpectedExpiresUtc = GetConvertedDateTimeOffset(expectedExpiresUtc);
            var convertedActualExpiresUtc = GetConvertedDateTimeOffset(actualExpiresUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "ChallengeResult.AuthenticationProperties.ExpiresUtc", convertedExpectedExpiresUtc, convertedActualExpiresUtc);

            Action a = () => result.Should().BeChallengeResult().WithExpiresUtc(expectedExpiresUtc);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_For_Actual_ShouldFail()
        {
            var actualExpiresUtc = null as DateTimeOffset?;
            var expectedExpiresUtc = DateTimeOffset.Now;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedExpectedExpiresUtc = GetConvertedDateTimeOffset(expectedExpiresUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "ChallengeResult.AuthenticationProperties.ExpiresUtc", convertedExpectedExpiresUtc, null);

            Action a = () => result.Should().BeChallengeResult().WithExpiresUtc(expectedExpiresUtc);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_For_Expected_ShouldFail()
        {
            var actualExpiresUtc = DateTimeOffset.Now;
            var expectedExpiresUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var convertedActualExpiresUtc = GetConvertedDateTimeOffset(actualExpiresUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "ChallengeResult.AuthenticationProperties.ExpiresUtc", null, convertedActualExpiresUtc);

            Action a = () => result.Should().BeChallengeResult().WithExpiresUtc(expectedExpiresUtc);
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
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "ChallengeResult.AuthenticationProperties.AllowRefresh", expectedAllowRefresh, actualAllowRefresh);

            Action a = () => result.Should().BeChallengeResult().WithAllowRefresh(expectedAllowRefresh);
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
            result.Should().BeChallengeResult().ContainsItem(testKey, testValue);
        }

        [Fact]
        public void ContainsItem_GivenUnexpected_ShouldFail()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            const string expectedKey = "wrong key";
            const string expectedValue = "wrong value";

            var properties = new Dictionary<string, string> { { testKey, testValue } };
            var actualAuthenticationProperties = new AuthenticationProperties(properties);
            ActionResult result = new ChallengeResult(actualAuthenticationProperties);
            var failureMessage = string.Format(FailureMessages.CommonItemsContain, expectedKey, expectedValue);

            Action a = () => result.Should().BeChallengeResult().ContainsItem(expectedKey, expectedValue);
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
            var actualAuthenticationSchemes = new List<string>() { "one", "two", "three"};
            var expectedAuthenticationSchemes = new List<string> { "three", "four", "five"};

            ActionResult result = new ChallengeResult(actualAuthenticationSchemes);
            var failureMessage = string.Format(FailureMessages.CommonListsNotIdentical, "ChallengeResult.AuthenticationSchemes");

            Action a = () => result.Should().BeChallengeResult().WithAuthenticationSchemes(expectedAuthenticationSchemes);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsScheme_GivenExpected_ShouldPass()
        {
            const string testScheme = "testScheme";
            var actualSchemes = new List<string> {testScheme};
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

            Action a = () => result.Should().BeChallengeResult().ContainsScheme(expectedScheme);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        // DateTimeOffset is stored as string and converted back in ASP.NET Core Framework
        private DateTimeOffset? GetConvertedDateTimeOffset(DateTimeOffset value)
        {
            var expectedIssuedUtcAsString = value.ToString("r", (IFormatProvider)CultureInfo.InvariantCulture);

            return DateTimeOffset.TryParseExact(expectedIssuedUtcAsString, "r", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var result)
                ? new DateTimeOffset?(result)
                : new DateTimeOffset?();
        }
    }
}
