using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using AuthenticationProperties = Microsoft.AspNetCore.Authentication.AuthenticationProperties;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="SignInResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class SignInResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:SignInResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public SignInResultAssertions(object subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties
        public AuthenticationProperties AuthenticationProperties => SignInResultSubject.Properties;
        public IDictionary<string, string> Items => SignInResultSubject.Properties?.Items;
        public bool IsPersistent => SignInResultSubject.Properties?.IsPersistent ?? false;
        public string RedirectUri => SignInResultSubject.Properties?.RedirectUri;
        public DateTimeOffset? IssuedUtc => SignInResultSubject.Properties?.IssuedUtc;
        public DateTimeOffset? ExpiresUtc => SignInResultSubject.Properties?.ExpiresUtc;
        public bool? AllowRefresh => SignInResultSubject.Properties?.AllowRefresh;
        public string AuthenticationScheme => SignInResultSubject.AuthenticationScheme;
        public ClaimsPrincipal Principal => SignInResultSubject.Principal;

        #endregion

        #region Private Properties

        private SignInResult SignInResultSubject => (SignInResult) Subject;

        #endregion

        #region Public Methods

        /// <summary>
        /// Asserts that the AuthenticationProperties is exactly the same as the expected AuthenticationProperties.
        /// </summary>
        /// <param name="expectedAuthenticationProperties">The expected AuthenticationProperties.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public SignInResultAssertions WithAuthenticationProperties(AuthenticationProperties expectedAuthenticationProperties, string reason = "", params object[] reasonArgs)
        {
            var actualAuthenticationProperties = AuthenticationProperties;

            Execute.Assertion
                .ForCondition(actualAuthenticationProperties == expectedAuthenticationProperties)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignInResult.AuthenticationProperties")
                .FailWith(FailureMessages.CommonFailMessage, expectedAuthenticationProperties, actualAuthenticationProperties);

            return this;
        }

        /// <summary>
        /// Asserts that the IsPersistent is exactly the same as the expected IsPersistent.
        /// </summary>
        /// <param name="expectedIsPersistent">The expected IsPersistent.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public SignInResultAssertions WithIsPersistent(bool expectedIsPersistent, string reason = "", params object[] reasonArgs)
        {
            var actualIsPersistent = IsPersistent;

            Execute.Assertion
                .ForCondition(actualIsPersistent == expectedIsPersistent)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignInResult.AuthenticationProperties.IsPersistent")
                .FailWith(FailureMessages.CommonFailMessage, expectedIsPersistent, actualIsPersistent);

            return this;
        }

        /// <summary>
        /// Asserts that the RedirectUri is exactly the same as the expected RedirectUri.
        /// </summary>
        /// <param name="expectedRedirectUri">The expected RedirectUri.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public SignInResultAssertions WithRedirectUri(string expectedRedirectUri, string reason = "", params object[] reasonArgs)
        {
            var actualRedirectUri = RedirectUri;

            Execute.Assertion
                .ForCondition(string.Equals(actualRedirectUri, expectedRedirectUri))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignInResult.AuthenticationProperties.RedirectUri")
                .FailWith(FailureMessages.CommonFailMessage, expectedRedirectUri, actualRedirectUri);

            return this;
        }

        /// <summary>
        /// Asserts that the IssuedUtc is exactly the same as the expected IssuedUtc.
        /// </summary>
        /// <param name="expectedIssuedUtc">The expected IssuedUtc.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public SignInResultAssertions WithIssuedUtc(DateTimeOffset? expectedIssuedUtc, string reason = "", params object[] reasonArgs)
        {
            var actualResult = IssuedUtc;

            var expectedResult = AssertionHelpers.RoundToSeconds(expectedIssuedUtc);

            Execute.Assertion
                .ForCondition(expectedResult == actualResult)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignInResult.AuthenticationProperties.IssuedUtc")
                .FailWith(FailureMessages.CommonFailMessage, expectedResult, actualResult);

            return this;
        }

        /// <summary>
        /// Asserts that the ExpiresUtc is exactly the same as the expected ExpiresUtc.
        /// </summary>
        /// <param name="expectedExpiresUtc">The expected ExpiresUtc.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public SignInResultAssertions WithExpiresUtc(DateTimeOffset? expectedExpiresUtc, string reason = "", params object[] reasonArgs)
        {
            var actualResult = ExpiresUtc;

            var expectedResult = AssertionHelpers.RoundToSeconds(expectedExpiresUtc);

            Execute.Assertion
                .ForCondition(expectedResult == actualResult)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignInResult.AuthenticationProperties.ExpiresUtc")
                .FailWith(FailureMessages.CommonFailMessage, expectedResult, actualResult);

            return this;
        }

        /// <summary>
        /// Asserts that the AllowRefresh is exactly the same as the expected AllowRefresh.
        /// </summary>
        /// <param name="expectedAllowRefresh">The expected AllowRefresh.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public SignInResultAssertions WithAllowRefresh(bool? expectedAllowRefresh, string reason = "", params object[] reasonArgs)
        {
            var actualAllowRefresh = AllowRefresh;

            Execute.Assertion
                .ForCondition(actualAllowRefresh == expectedAllowRefresh)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignInResult.AuthenticationProperties.AllowRefresh")
                .FailWith(FailureMessages.CommonFailMessage, expectedAllowRefresh, actualAllowRefresh);

            return this;
        }

        /// <summary>
        /// Asserts that the Items contain the the expected Key Value Pair.
        /// </summary>
        /// <param name="expectedKey">The expected Key in Items.</param>
        /// <param name="expectedValue">The expected Value in Items.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public SignInResultAssertions ContainsItem(string expectedKey, string expectedValue, string reason = "", params object[] reasonArgs)
        {
            var actualItems = Items;
            
            AssertionHelpers.AssertStringObjectDictionary(actualItems, "SignInResult.Items", expectedKey, expectedValue, reason, reasonArgs);

            return this;
        }

        /// <summary>
        /// Asserts that the AuthenticationSchemes is exactly the same as the expected AuthenticationScheme.
        /// </summary>
        /// <param name="expectedAuthenticationScheme">The expected AuthenticationScheme.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public SignInResultAssertions WithAuthenticationScheme(string expectedAuthenticationScheme, string reason = "", params object[] reasonArgs)
        {
            var actualAuthenticationScheme = AuthenticationScheme;

            Execute.Assertion
                .ForCondition(string.Equals(actualAuthenticationScheme, expectedAuthenticationScheme))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignInResult.AuthenticationScheme")
                .FailWith(FailureMessages.CommonFailMessage, expectedAuthenticationScheme, actualAuthenticationScheme);

            return this;
        }

        /// <summary>
        /// Asserts that the Principals is exactly the same as the expected Principal.
        /// </summary>
        /// <param name="expectedPrincipal">The expected Principal.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public SignInResultAssertions WithPrincipal(ClaimsPrincipal expectedPrincipal, string reason = "", params object[] reasonArgs)
        {
            var actualPrincipal = Principal;

            Execute.Assertion
                .ForCondition(actualPrincipal == expectedPrincipal)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignInResult.Principal")
                .FailWith(FailureMessages.CommonFailMessage, expectedPrincipal, actualPrincipal);

            return this;

        }

        #endregion
    }
}
