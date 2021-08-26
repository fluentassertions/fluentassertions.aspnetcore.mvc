using FluentAssertions.Mvc.Tests.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Tests
{

    public class SignOutResultAssertions_Tests
    {
        public const string Reason = FailureMessageHelper.Reason;
        public readonly static object[] ReasonArgs = FailureMessageHelper.ReasonArgs;
        private readonly List<string> TestAuthenticationSchemes = new List<string> { "one", "two" };
        private readonly DateTimeOffset? TestIssuedUtc = DateTimeOffset.Parse("2020-04-28 15:48:33.6672395 +2", CultureInfo.InvariantCulture);

        [Fact]
        public void WithAuthenticationProperties_GivenExpected_ShouldPass()
        {
            var actualAuthenticationProperties = new AuthenticationProperties();
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            result.Should().BeSignOutResult().WithAuthenticationProperties(actualAuthenticationProperties);
        }

        [Fact]
        public void WithAuthenticationProperties_GivenUnexpected_ShouldFail()
        {
            var actualAuthenticationProperties = new AuthenticationProperties();
            var expectedAuthenticationProperties = new AuthenticationProperties();
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.AuthenticationPropertiesExpectations(result);

            Action a = () => result.Should().BeSignOutResult().WithAuthenticationProperties(expectedAuthenticationProperties, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIsPersistent_GivenExpected_ShouldPass()
        {
            var actualIsPersistent = true;
            var actualAuthenticationProperties = new AuthenticationProperties { IsPersistent = actualIsPersistent };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            result.Should().BeSignOutResult().WithIsPersistent(actualIsPersistent);
        }

        [Fact]
        public void WithIsPersistent_GivenUnexpected_ShouldFail()
        {
            var actualIsPersistent = true;
            var expectedIsPersistent = false;
            var actualAuthenticationProperties = new AuthenticationProperties { IsPersistent = actualIsPersistent };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "SignOutResult.AuthenticationProperties.IsPersistent",
                expectedIsPersistent,
                actualIsPersistent);

            Action a = () => result.Should().BeSignOutResult().WithIsPersistent(expectedIsPersistent, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithRedirectUri_GivenExpected_ShouldPass()
        {
            var actualRedirectUri = "redirectUri";
            var actualAuthenticationProperties = new AuthenticationProperties { RedirectUri = actualRedirectUri };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            result.Should().BeSignOutResult().WithRedirectUri(actualRedirectUri);
        }

        [Fact]
        public void WithRedirectUri_GivenUnexpected_ShouldFail()
        {
            var actualRedirectUri = "redirectUri";
            var expectedRedirectUri = "otherUri";
            var actualAuthenticationProperties = new AuthenticationProperties { RedirectUri = actualRedirectUri };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "SignOutResult.AuthenticationProperties.RedirectUri",
                expectedRedirectUri,
                actualRedirectUri);

            Action a = () => result.Should().BeSignOutResult().WithRedirectUri(expectedRedirectUri, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenExpected_ShouldPass()
        {
            var actualIssuedUtc = TestIssuedUtc;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            result.Should().BeSignOutResult().WithIssuedUtc(actualIssuedUtc);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_ShouldPass()
        {
            var actualIssuedUtc = null as DateTimeOffset?;
            var expectedIssuedUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            result.Should().BeSignOutResult().WithIssuedUtc(expectedIssuedUtc);
        }

        [Fact]
        public void WithIssuedUtc_GivenUnexpected_ShouldFail()
        {
            var actualIssuedUtc = TestIssuedUtc;
            var expectedIssuedUtc = TestIssuedUtc.Value.AddSeconds(1);
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "SignOutResult.AuthenticationProperties.IssuedUtc",
                FailureMessageHelper.RoundToSeconds(expectedIssuedUtc),
                FailureMessageHelper.RoundToSeconds(actualIssuedUtc));

            Action a = () => result.Should().BeSignOutResult().WithIssuedUtc(expectedIssuedUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_For_Actual_ShouldFail()
        {
            var actualIssuedUtc = null as DateTimeOffset?;
            var expectedIssuedUtc = TestIssuedUtc;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "SignOutResult.AuthenticationProperties.IssuedUtc",
                FailureMessageHelper.RoundToSeconds(expectedIssuedUtc),
                FailureMessageHelper.RoundToSeconds(actualIssuedUtc));

            Action a = () => result.Should().BeSignOutResult().WithIssuedUtc(expectedIssuedUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithIssuedUtc_GivenNull_For_Expected_ShouldFail()
        {
            var actualIssuedUtc = TestIssuedUtc;
            var expectedIssuedUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { IssuedUtc = actualIssuedUtc };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "SignOutResult.AuthenticationProperties.IssuedUtc",
                FailureMessageHelper.RoundToSeconds(expectedIssuedUtc),
                FailureMessageHelper.RoundToSeconds(actualIssuedUtc));

            Action a = () => result.Should().BeSignOutResult().WithIssuedUtc(expectedIssuedUtc, Reason, ReasonArgs);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenExpected_ShouldPass()
        {
            var actualExpiresUtc = TestIssuedUtc;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            result.Should().BeSignOutResult().WithExpiresUtc(actualExpiresUtc);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_ShouldPass()
        {
            var actualExpiresUtc = null as DateTimeOffset?;
            var expectedExpiresUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            result.Should().BeSignOutResult().WithExpiresUtc(expectedExpiresUtc);
        }

        [Fact]
        public void WithExpiresUtc_GivenUnexpected_ShouldFail()
        {
            var actualExpiresUtc = TestIssuedUtc;
            var expectedExpiresUtc = TestIssuedUtc.Value.AddSeconds(1);
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "SignOutResult.AuthenticationProperties.ExpiresUtc",
                FailureMessageHelper.RoundToSeconds(expectedExpiresUtc),
                FailureMessageHelper.RoundToSeconds(actualExpiresUtc));

            Action a = () => result.Should().BeSignOutResult().WithExpiresUtc(expectedExpiresUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_For_Actual_ShouldFail()
        {
            var actualExpiresUtc = null as DateTimeOffset?;
            var expectedExpiresUtc = TestIssuedUtc;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "SignOutResult.AuthenticationProperties.ExpiresUtc",
                FailureMessageHelper.RoundToSeconds(expectedExpiresUtc),
                FailureMessageHelper.RoundToSeconds(actualExpiresUtc));

            Action a = () => result.Should().BeSignOutResult().WithExpiresUtc(expectedExpiresUtc, Reason, ReasonArgs);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithExpiresUtc_GivenNull_For_Expected_ShouldFail()
        {
            var actualExpiresUtc = TestIssuedUtc;
            var expectedExpiresUtc = null as DateTimeOffset?;
            var actualAuthenticationProperties = new AuthenticationProperties { ExpiresUtc = actualExpiresUtc };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "SignOutResult.AuthenticationProperties.ExpiresUtc",
                FailureMessageHelper.RoundToSeconds(expectedExpiresUtc),
                FailureMessageHelper.RoundToSeconds(actualExpiresUtc));

            Action a = () => result.Should().BeSignOutResult().WithExpiresUtc(expectedExpiresUtc, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithAllowRefresh_GivenExpected_ShouldPass()
        {
            var actualAllowRefresh = true;
            var actualAuthenticationProperties = new AuthenticationProperties { AllowRefresh = actualAllowRefresh };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            result.Should().BeSignOutResult().WithAllowRefresh(actualAllowRefresh);
        }

        [Fact]
        public void WithAllowRefresh_GivenUnexpected_ShouldFail()
        {
            var actualAllowRefresh = true;
            var expectedAllowRefresh = false;
            var actualAuthenticationProperties = new AuthenticationProperties { AllowRefresh = actualAllowRefresh };
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextToBeXButY(
                "SignOutResult.AuthenticationProperties.AllowRefresh",
                expectedAllowRefresh,
                actualAllowRefresh);

            Action a = () => result.Should().BeSignOutResult().WithAllowRefresh(expectedAllowRefresh, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsItem_GivenExpected_ShouldPass()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            var properties = new Dictionary<string, string> { { testKey, testValue } };
            var actualAuthenticationProperties = new AuthenticationProperties(properties);
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            result.Should().BeSignOutResult().ContainsItem(testKey, testValue);
        }

        [Fact]
        public void ContainsItem_GivenNull_ShouldFail()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            ActionResult result = new SignOutResult(TestAuthenticationSchemes);
            var failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButFoundNull(
                "SignOutResult.AuthenticationProperties.Items", testValue, testKey);

            Action a = () => result.Should().BeSignOutResult().ContainsItem(testKey, testValue, Reason, ReasonArgs);

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
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedContextContainValueAtKeyButKeyNotFound(
                    "SignOutResult.AuthenticationProperties.Items", testValue, expectedKey);

            Action a = () => result.Should().BeSignOutResult().ContainsItem(expectedKey, testValue, Reason, ReasonArgs);

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
            ActionResult result = new SignOutResult(TestAuthenticationSchemes, actualAuthenticationProperties);
            var failureMessage = FailureMessageHelper.ExpectedAtKeyValueXButFoundY(
                "SignOutResult.AuthenticationProperties.Items", testKey, expectedValue, testValue);

            Action a = () => result.Should().BeSignOutResult().ContainsItem(testKey, expectedValue, Reason, ReasonArgs);

            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void WithAuthenticationSchemes_GivenExpected_ShouldPass()
        {
            var actualAuthenticationSchemes = new List<string> { "one", "two" };
            var expectedAuthenticationSchemes = new List<string> { "two", "one" };

            ActionResult result = new SignOutResult(actualAuthenticationSchemes);
            result.Should().BeSignOutResult().WithAuthenticationSchemes(expectedAuthenticationSchemes);
        }

        [Fact]
        public void WithAuthenticationSchemes_GivenUnexpected_ShouldFail()
        {
            var actualAuthenticationSchemes = new List<string>() { "one", "two", "three" };
            var expectedAuthenticationSchemes = new List<string> { "three", "four", "five" };

            ActionResult result = new SignOutResult(actualAuthenticationSchemes);
            var failureMessage = string.Format(FailureMessages.CommonListsNotIdentical, "SignOutResult.AuthenticationSchemes");

            Action a = () => result.Should().BeSignOutResult().WithAuthenticationSchemes(expectedAuthenticationSchemes, Reason, ReasonArgs);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

        [Fact]
        public void ContainsScheme_GivenExpected_ShouldPass()
        {
            const string testScheme = "testScheme";
            var actualSchemes = new List<string> { testScheme };
            ActionResult result = new SignOutResult(actualSchemes);
            result.Should().BeSignOutResult().ContainsScheme(testScheme);
        }

        [Fact]
        public void ContainsScheme_GivenUnexpected_ShouldFail()
        {
            const string testScheme = "testScheme";
            const string expectedScheme = "expectedScheme";
            var actualSchemes = new List<string> { testScheme };
            ActionResult result = new SignOutResult(actualSchemes);
            var failureMessage = string.Format(FailureMessages.CommonAuthenticationSchemesContainScheme, expectedScheme);

            Action a = () => result.Should().BeSignOutResult().ContainsScheme(expectedScheme, Reason, ReasonArgs);
            a.Should().Throw<Exception>().WithMessage(failureMessage);
        }

    }
}
