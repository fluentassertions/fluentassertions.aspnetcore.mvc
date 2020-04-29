using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class SignInResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;
        private const string TestAuthenticationScheme = "TestAuthenticationScheme";
        private readonly ClaimsPrincipal TestClaimsPrincipal = new ClaimsPrincipal();
        private readonly DateTimeOffset? TestLastModified = DateTimeOffset.Parse("2020-04-28 15:48:33.6672395 +2", CultureInfo.InvariantCulture);

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
            var failureMessage = @"Expected SignInResult.AuthenticationProperties to be 

Microsoft.AspNetCore.Authentication.AuthenticationProperties
{
   AllowRefresh = <null>
   ExpiresUtc = <null>
   IsPersistent = False
   IssuedUtc = <null>
   Items = {empty}
   RedirectUri = <null>
} because it is 10 but found 

Microsoft.AspNetCore.Authentication.AuthenticationProperties
{
   AllowRefresh = <null>
   ExpiresUtc = <null>
   IsPersistent = False
   IssuedUtc = <null>
   Items = {empty}
   RedirectUri = <null>
}.";

            Action a = () => result.Should().BeSignInResult().WithAuthenticationProperties(expectedAuthenticationProperties, Reason, ReasonArgs);

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
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("SignInResult.AuthenticationProperties.IsPersistent", expectedIsPersistent, actualIsPersistent);

            Action a = () => result.Should().BeSignInResult().WithIsPersistent(expectedIsPersistent, Reason, ReasonArgs);

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
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("SignInResult.AuthenticationProperties.RedirectUri", expectedRedirectUri, actualRedirectUri);

            Action a = () => result.Should().BeSignInResult().WithRedirectUri(expectedRedirectUri, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenExpected_ShouldPass()
        {
            var actualIssuedUtc = TestLastModified;
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
            var actualIssuedUtc = TestLastModified;
            var expectedIssuedUtc = TestLastModified.Value.AddSeconds(1);
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedExpectedIssuedUtc = FailureMessageHelper.RoundToSeconds(expectedIssuedUtc);
            var convertedActualIssuedUtc = FailureMessageHelper.RoundToSeconds(actualIssuedUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("SignInResult.AuthenticationProperties.IssuedUtc", convertedExpectedIssuedUtc, convertedActualIssuedUtc);

            Action a = () => result.Should().BeSignInResult().WithIssuedUtc(expectedIssuedUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_For_Actual_ShouldFail()
        {
            var actualIssuedUtc = null as DateTimeOffset?;
            var expectedIssuedUtc = TestLastModified;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedExpectedIssuedUtc = FailureMessageHelper.RoundToSeconds(expectedIssuedUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("SignInResult.AuthenticationProperties.IssuedUtc", convertedExpectedIssuedUtc, null);

            Action a = () => result.Should().BeSignInResult().WithIssuedUtc(expectedIssuedUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_For_Expected_ShouldFail()
        {
            var actualIssuedUtc = TestLastModified;
            var expectedIssuedUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedActualIssuedUtc = FailureMessageHelper.RoundToSeconds(actualIssuedUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("SignInResult.AuthenticationProperties.IssuedUtc", null, convertedActualIssuedUtc);

            Action a = () => result.Should().BeSignInResult().WithIssuedUtc(expectedIssuedUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenExpected_ShouldPass()
        {
            var actualExpiresUtc = TestLastModified;
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
            var actualExpiresUtc = TestLastModified;
            var expectedExpiresUtc = TestLastModified.Value.AddSeconds(1);
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedExpectedExpiresUtc = FailureMessageHelper.RoundToSeconds(expectedExpiresUtc);
            var convertedActualExpiresUtc = FailureMessageHelper.RoundToSeconds(actualExpiresUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("SignInResult.AuthenticationProperties.ExpiresUtc", convertedExpectedExpiresUtc, convertedActualExpiresUtc);

            Action a = () => result.Should().BeSignInResult().WithExpiresUtc(expectedExpiresUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_For_Actual_ShouldFail()
        {
            var actualExpiresUtc = null as DateTimeOffset?;
            var expectedExpiresUtc = TestLastModified;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedExpectedExpiresUtc = FailureMessageHelper.RoundToSeconds(expectedExpiresUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("SignInResult.AuthenticationProperties.ExpiresUtc", convertedExpectedExpiresUtc, null);

            Action a = () => result.Should().BeSignInResult().WithExpiresUtc(expectedExpiresUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_For_Expected_ShouldFail()
        {
            var actualExpiresUtc = TestLastModified;
            var expectedExpiresUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var convertedActualExpiresUtc = FailureMessageHelper.RoundToSeconds(actualExpiresUtc);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("SignInResult.AuthenticationProperties.ExpiresUtc", null, convertedActualExpiresUtc);

            Action a = () => result.Should().BeSignInResult().WithExpiresUtc(expectedExpiresUtc, Reason, ReasonArgs);

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
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("SignInResult.AuthenticationProperties.AllowRefresh", expectedAllowRefresh, actualAllowRefresh);

            Action a = () => result.Should().BeSignInResult().WithAllowRefresh(expectedAllowRefresh, Reason, ReasonArgs);

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
        public void ContainsItem_GivenNull_ShouldFail()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal);
            var failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButFoundNull(
                "SignInResult.Items", testValue, testKey);

            Action a = () => result.Should().BeSignInResult().ContainsItem(testKey, testValue, Reason, ReasonArgs);

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
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButKeyNotFound(
                    "SignInResult.Items", testValue, expectedKey);

            Action a = () => result.Should().BeSignInResult().ContainsItem(expectedKey, testValue, Reason, ReasonArgs);

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
            ActionResult result = new SignInResult(TestAuthenticationScheme, TestClaimsPrincipal, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY("SignInResult.Items", testKey, expectedValue, testValue);

            Action a = () => result.Should().BeSignInResult().ContainsItem(testKey, expectedValue, Reason, ReasonArgs);

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
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY("SignInResult.AuthenticationScheme", excpectedAuthenticationScheme, TestAuthenticationScheme);

            Action a = () => result.Should().BeSignInResult().WithAuthenticationScheme(excpectedAuthenticationScheme, Reason, ReasonArgs);

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
            var failureMessage = @"Expected SignInResult.Principal to be 

System.Security.Claims.ClaimsPrincipal
{
   Claims = {empty}
   Identities = {empty}
   Identity = <null>
} because it is 10 but found 

System.Security.Claims.ClaimsPrincipal
{
   Claims = {empty}
   Identities = {empty}
   Identity = <null>
}.";

            Action a = () => result.Should().BeSignInResult().WithPrincipal(excpectedClaimsPrincipal, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }
    }
}
