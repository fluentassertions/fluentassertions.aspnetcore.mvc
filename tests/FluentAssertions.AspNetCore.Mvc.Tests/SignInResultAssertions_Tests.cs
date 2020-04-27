using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class SignInResultAssertions_Tests
    {
        private const string TestAuthenticationScheme = "TestAuthenticationScheme";
        private readonly ClaimsPrincipal TestClaimsPrincipal = new ClaimsPrincipal();

        [Fact]
        public void WithAuthenticationProperties_GivenExpected_ShouldPass()
        {
            var actualAuthenticationProperties = new AuthenticationProperties();
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            result.Should().BeSignInResult().WithAuthenticationProperties(actualAuthenticationProperties);
        }

        [Fact]
        public void WithAuthenticationProperties_GivenUnexpected_ShouldFail()
        {
            var actualAuthenticationProperties = new AuthenticationProperties();
            var expectedAuthenticationProperties = new AuthenticationProperties();
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.AuthenticationProperties", expectedAuthenticationProperties, actualAuthenticationProperties);

            Action a = () => result.Should().BeSignInResult().WithAuthenticationProperties(expectedAuthenticationProperties);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIsPersistent_GivenExpected_ShouldPass()
        {
            var actualIsPersistent = true;
            var actualAuthenticationProperties = new AuthenticationProperties { IsPersistent = actualIsPersistent };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            result.Should().BeSignInResult().WithIsPersistent(actualIsPersistent);
        }

        [Fact]
        public void WithIsPersistent_GivenUnexpected_ShouldFail()
        {
            var actualIsPersistent = true;
            var expectedIsPersistent = false;
            var actualAuthenticationProperties = new AuthenticationProperties { IsPersistent = actualIsPersistent };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.AuthenticationProperties.IsPersistent", expectedIsPersistent, actualIsPersistent);

            Action a = () => result.Should().BeSignInResult().WithIsPersistent(expectedIsPersistent);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRedirectUri_GivenExpected_ShouldPass()
        {
            var actualRedirectUri = "redirectUri";
            var actualAuthenticationProperties = new AuthenticationProperties { RedirectUri = actualRedirectUri };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            result.Should().BeSignInResult().WithRedirectUri(actualRedirectUri);
        }

        [Fact]
        public void WithRedirectUri_GivenUnexpected_ShouldFail()
        {
            var actualRedirectUri = "redirectUri";
            var expectedRedirectUri = "otherUri";
            var actualAuthenticationProperties = new AuthenticationProperties { RedirectUri = actualRedirectUri };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.AuthenticationProperties.RedirectUri", expectedRedirectUri, actualRedirectUri);

            Action a = () => result.Should().BeSignInResult().WithRedirectUri(expectedRedirectUri);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenExpected_ShouldPass()
        {
            var actualIssuedUtc = DateTimeOffset.Now;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            result.Should().BeSignInResult().WithIssuedUtc(actualIssuedUtc);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_ShouldPass()
        {
            var actualIssuedUtc = null as DateTimeOffset?;
            var expectedIssuedUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            result.Should().BeSignInResult().WithIssuedUtc(expectedIssuedUtc);
        }

        [Fact]
        public void WithIssuedUtc_GivenUnexpected_ShouldFail()
        {
            var actualIssuedUtc = DateTimeOffset.Now;
            var expectedIssuedUtc = DateTimeOffset.Now.AddSeconds(1);
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedExpectedIssuedUtc = GetConvertedDateTimeOffset(expectedIssuedUtc);
            var convertedActualIssuedUtc = GetConvertedDateTimeOffset(actualIssuedUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.AuthenticationProperties.IssuedUtc", convertedExpectedIssuedUtc, convertedActualIssuedUtc);

            Action a = () => result.Should().BeSignInResult().WithIssuedUtc(expectedIssuedUtc);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_For_Actual_ShouldFail()
        {
            var actualIssuedUtc = null as DateTimeOffset?;
            var expectedIssuedUtc = DateTimeOffset.Now;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedExpectedIssuedUtc = GetConvertedDateTimeOffset(expectedIssuedUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.AuthenticationProperties.IssuedUtc", convertedExpectedIssuedUtc, null);

            Action a = () => result.Should().BeSignInResult().WithIssuedUtc(expectedIssuedUtc);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_For_Expected_ShouldFail()
        {
            var actualIssuedUtc = DateTimeOffset.Now;
            var expectedIssuedUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedActualIssuedUtc = GetConvertedDateTimeOffset(actualIssuedUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.AuthenticationProperties.IssuedUtc", null, convertedActualIssuedUtc);

            Action a = () => result.Should().BeSignInResult().WithIssuedUtc(expectedIssuedUtc);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenExpected_ShouldPass()
        {
            var actualExpiresUtc = DateTimeOffset.Now;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            result.Should().BeSignInResult().WithExpiresUtc(actualExpiresUtc);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_ShouldPass()
        {
            var actualExpiresUtc = null as DateTimeOffset?;
            var expectedExpiresUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            result.Should().BeSignInResult().WithExpiresUtc(expectedExpiresUtc);
        }

        [Fact]
        public void WithExpiresUtc_GivenUnexpected_ShouldFail()
        {
            var actualExpiresUtc = DateTimeOffset.Now;
            var expectedExpiresUtc = DateTimeOffset.Now.AddSeconds(1);
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedExpectedExpiresUtc = GetConvertedDateTimeOffset(expectedExpiresUtc);
            var convertedActualExpiresUtc = GetConvertedDateTimeOffset(actualExpiresUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.AuthenticationProperties.ExpiresUtc", convertedExpectedExpiresUtc, convertedActualExpiresUtc);

            Action a = () => result.Should().BeSignInResult().WithExpiresUtc(expectedExpiresUtc);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_For_Actual_ShouldFail()
        {
            var actualExpiresUtc = null as DateTimeOffset?;
            var expectedExpiresUtc = DateTimeOffset.Now;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedExpectedExpiresUtc = GetConvertedDateTimeOffset(expectedExpiresUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.AuthenticationProperties.ExpiresUtc", convertedExpectedExpiresUtc, null);

            Action a = () => result.Should().BeSignInResult().WithExpiresUtc(expectedExpiresUtc);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_For_Expected_ShouldFail()
        {
            var actualExpiresUtc = DateTimeOffset.Now;
            var expectedExpiresUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedActualExpiresUtc = GetConvertedDateTimeOffset(actualExpiresUtc);

            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.AuthenticationProperties.ExpiresUtc", null, convertedActualExpiresUtc);

            Action a = () => result.Should().BeSignInResult().WithExpiresUtc(expectedExpiresUtc);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithAllowRefresh_GivenExpected_ShouldPass()
        {
            var actualAllowRefresh = true;
            var actualAuthenticationProperties = new AuthenticationProperties { AllowRefresh = actualAllowRefresh };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            result.Should().BeSignInResult().WithAllowRefresh(actualAllowRefresh);
        }

        [Fact]
        public void WithAllowRefresh_GivenUnexpected_ShouldFail()
        {
            var actualAllowRefresh = true;
            var expectedAllowRefresh = false;
            var actualAuthenticationProperties = new AuthenticationProperties { AllowRefresh = actualAllowRefresh };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.AuthenticationProperties.AllowRefresh", expectedAllowRefresh, actualAllowRefresh);

            Action a = () => result.Should().BeSignInResult().WithAllowRefresh(expectedAllowRefresh);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsItem_GivenExpected_ShouldPass()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            var properties = new Dictionary<string, string> { { testKey, testValue } };
            var actualAuthenticationProperties = new AuthenticationProperties(properties);
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            result.Should().BeSignInResult().ContainsItem(testKey, testValue);
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
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var failureMessage = string.Format(FailureMessages.CommonItemsContain, expectedKey, expectedValue);

            Action a = () => result.Should().BeSignInResult().ContainsItem(expectedKey, expectedValue);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithAuthenticationScheme_GivenExpected_ShouldPass()
        {
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal);
            result.Should().BeSignInResult().WithAuthenticationScheme(TestAuthenticationScheme);
        }

        [Fact]
        public void WithAuthenticationScheme_GivenUnexpected_ShouldFail()
        {
            var excpectedAuthenticationScheme = "other Scheme";
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal);
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.AuthenticationScheme", excpectedAuthenticationScheme, TestAuthenticationScheme);

            Action a = () => result.Should().BeSignInResult().WithAuthenticationScheme(excpectedAuthenticationScheme);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithPrincipal_GivenExpected_ShouldPass()
        {
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal);
            result.Should().BeSignInResult().WithPrincipal(TestClaimsPrincipal);
        }

        [Fact]
        public void WithPrincipal_GivenUnexpected_ShouldFail()
        {
            var excpectedClaimsPrincipal = new ClaimsPrincipal();
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal);
            var failureMessage = string.Format(FailureMessages.CommonFailMessage, "SignInResult.Principal", excpectedClaimsPrincipal, TestClaimsPrincipal);

            Action a = () => result.Should().BeSignInResult().WithPrincipal(excpectedClaimsPrincipal);
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
