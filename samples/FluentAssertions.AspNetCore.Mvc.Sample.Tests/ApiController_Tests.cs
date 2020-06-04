using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Claims;
using FluentAssertions.AspNetCore.Mvc.Sample.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Xunit;

namespace FluentAssertions.AspNetCore.Mvc.Sample.Tests
{
    public class ApiController_Tests
    {
        #region Public Methods

        private const string TestValue = "TestValue";
        private const string TestActionName = "TestActionName";
        private const string TestRouteName = "TestRouteName";
        private const string TestControllerName = "TestControllerName";
        private const string TestRouteKey = "TestRouteKey";
        private const string TestRouteValue = "TestRouteValue";
        private const string TestPhysicalPath = "TestPhysicalPath";
        private const string TestContentType = "application/json";
        private const string TestFileDownloadName = "TestFileDownloadName";
        private const string TestFileName = "TestFileName";
        private readonly DateTimeOffset? TestLastModified = DateTimeOffset.Now;
        private readonly EntityTagHeaderValue TestEntityTag = new EntityTagHeaderValue("\"0815\"");
        private readonly object TestRouteValues = new Dictionary<string, object> { { TestRouteKey, TestRouteValue } };

        [Fact]
        public void GetOk_Should_Return_Ok()
        {
            var controller = new ApiController();
            controller.GetOk().Should().BeOkResult();
        }

        [Fact]
        public void GetOk_Should_Return_Ok_With_Value()
        {
            var controller = new ApiController();
            var value = controller.GetOk(TestValue).Should().BeOkObjectResult().ValueAs<string>();
            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetBadRequest_Should_Return_BadRequest()
        {
            var controller = new ApiController();
            controller.BadRequest().Should().BeBadRequestResult();
        }

        [Fact]
        public void GetBadRequest_Should_Return_BadRequest_And_Has_SerializableError()
        {
            var testErrorKey = "testErrorKey";
            var testErrorMessage = "testErrorMessage";
            var testModelState = new ModelStateDictionary();
            testModelState.AddModelError(testErrorKey, testErrorMessage);

            var controller = new ApiController();
            var serializableError = controller.GetBadRequest(testModelState).Should().BeBadRequestObjectResult().SerializableError;
            serializableError.Should().ContainKey(testErrorKey);
        }

        [Fact]
        public void GetBadRequest_Should_Return_BadRequest_And_With_Error()
        {
            const string testError = "error";
            var controller = new ApiController();
            var error = controller.GetBadRequest(testError).Should().BeBadRequestObjectResult().ErrorAs<string>();
            error.Should().Be(testError);
        }

        [Fact]
        public void GetCreated_Should_Return_Created_With_Uri_And_Value()
        {
            const string TestUriAsString = "http://localhost:5000";
            var TestUri = new Uri(TestUriAsString);

            var controller = new ApiController();
            var value = controller.GetCreated(TestUri, TestValue).Should().BeCreatedResult().WithUri(TestUri).ValueAs<string>();
            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetCreated_Should_Return_Created_With_UriAsString_And_Value()
        {
            const string TestUriAsString = "http://localhost:5000";
            var controller = new ApiController();
            var value = controller.GetCreated(TestUriAsString, TestValue).Should().BeCreatedResult().WithUri(TestUriAsString).ValueAs<string>();
            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetChallenge_Should_Return_Challenge()
        {
            var controller = new ApiController();
            controller.GetChallenge().Should().BeChallengeResult();
        }

        [Fact]
        public void GetChallenge_Should_Return_Challenge_For_AuthenticationProperties()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            const string testRedirectUri = "testRedirectUri";
            const bool testIsPersistent = true;
            const bool testAllowRefresh = true;
            var testIssuedUtc = DateTimeOffset.Now;
            var testExpiresUtc = DateTimeOffset.Now.AddHours(1);

            var items = new Dictionary<string, string> { { testKey, testValue } };
            var testAuthenticationProperties = new AuthenticationProperties(items)
            {
                RedirectUri = testRedirectUri,
                IsPersistent = testIsPersistent,
                AllowRefresh = testAllowRefresh,
                IssuedUtc = testIssuedUtc,
                ExpiresUtc = testExpiresUtc,
            };

            var controller = new ApiController();
            controller.GetChallenge(testAuthenticationProperties)
                .Should()
                .BeChallengeResult()
                .WithRedirectUri(testRedirectUri)
                .WithIsPersistent(testIsPersistent)
                .WithAllowRefresh(testAllowRefresh)
                .WithIssuedUtc(testIssuedUtc)
                .WithExpiresUtc(testExpiresUtc)
                .WithAuthenticationProperties(testAuthenticationProperties)
                .ContainsItem(testKey, testValue);
        }

        [Fact]
        public void GetChallenge_Should_Return_Challenge_For_AuthenticationSchemes()
        {
            const string testScheme = "testScheme";

            var testAuthenticationSchemes = new[] { testScheme };

            var controller = new ApiController();
            controller.GetChallenge(testAuthenticationSchemes)
                .Should()
                .BeChallengeResult()
                .WithAuthenticationSchemes(testAuthenticationSchemes)
                .ContainsScheme(testScheme);
        }

        [Fact]
        public void GetChallenge_Should_Return_Challenge_For_AuthenticationProperties_And_AuthenticationSchemes()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            const string testRedirectUri = "testRedirectUri";
            const bool testIsPersistent = true;
            const bool testAllowRefresh = true;
            var testIssuedUtc = DateTimeOffset.Now;
            var testExpiresUtc = DateTimeOffset.Now.AddHours(1);
            const string testScheme = "testScheme";

            var items = new Dictionary<string, string> { { testKey, testValue } };
            var testAuthenticationProperties = new AuthenticationProperties(items)
            {
                RedirectUri = testRedirectUri,
                IsPersistent = testIsPersistent,
                AllowRefresh = testAllowRefresh,
                IssuedUtc = testIssuedUtc,
                ExpiresUtc = testExpiresUtc,
            };

            var testAuthenticationSchemes = new[] { testScheme };

            var controller = new ApiController();
            controller.GetChallenge(testAuthenticationProperties, testAuthenticationSchemes)
                .Should()
                .BeChallengeResult()
                .WithRedirectUri(testRedirectUri)
                .WithIsPersistent(testIsPersistent)
                .WithAllowRefresh(testAllowRefresh)
                .WithIssuedUtc(testIssuedUtc)
                .WithExpiresUtc(testExpiresUtc)
                .WithAuthenticationProperties(testAuthenticationProperties)
                .WithAuthenticationSchemes(testAuthenticationSchemes)
                .ContainsItem(testKey, testValue)
                .ContainsScheme(testScheme);
        }

        [Fact]
        public void GetAccepted_Should_Return_Accepted()
        {
            var controller = new ApiController();
            controller.GetAccepted().Should().BeAcceptedResult();
        }

        [Fact]
        public void GetAccepted_Should_Return_Accepted_With_Uri()
        {
            const string TestUriAsString = "http://localhost:5000";
            var TestUri = new Uri(TestUriAsString);

            var controller = new ApiController();
            controller.GetAccepted(TestUri).Should().BeAcceptedResult().WithUri(TestUri);
        }

        [Fact]
        public void GetAccepted_Should_Return_Accepted_With_Uri_And_Value()
        {
            const string TestUriAsString = "http://localhost:5000";
            var TestUri = new Uri(TestUriAsString);

            var controller = new ApiController();
            var value = controller.GetAccepted(TestUri, TestValue).Should().BeAcceptedResult().WithUri(TestUri).ValueAs<string>();
            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetAccepted_Should_Return_Accepted_With_Value()
        {
            var controller = new ApiController();
            var value = controller.GetAccepted(TestValue as object).Should().BeAcceptedResult().ValueAs<string>();
            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetAccepted_Should_Return_Accepted_With_UriAsString_And_Value()
        {
            const string TestUriAsString = "http://localhost:5000";
            var controller = new ApiController();
            controller.GetAccepted(TestUriAsString).Should().BeAcceptedResult().WithUri(TestUriAsString);
        }

        [Fact]
        public void GetForbid_Should_Return_Forbid()
        {
            var controller = new ApiController();
            controller.GetForbid().Should().BeForbidResult();
        }

        [Fact]
        public void GetForbid_Should_Return_Forbid_For_AuthenticationProperties()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            const string testRedirectUri = "testRedirectUri";
            const bool testIsPersistent = true;
            const bool testAllowRefresh = true;
            var testIssuedUtc = DateTimeOffset.Now;
            var testExpiresUtc = DateTimeOffset.Now.AddHours(1);

            var items = new Dictionary<string, string> { { testKey, testValue } };
            var testAuthenticationProperties = new AuthenticationProperties(items)
            {
                RedirectUri = testRedirectUri,
                IsPersistent = testIsPersistent,
                AllowRefresh = testAllowRefresh,
                IssuedUtc = testIssuedUtc,
                ExpiresUtc = testExpiresUtc,
            };

            var controller = new ApiController();
            controller.GetForbid(testAuthenticationProperties)
                .Should()
                .BeForbidResult()
                .WithRedirectUri(testRedirectUri)
                .WithIsPersistent(testIsPersistent)
                .WithAllowRefresh(testAllowRefresh)
                .WithIssuedUtc(testIssuedUtc)
                .WithExpiresUtc(testExpiresUtc)
                .WithAuthenticationProperties(testAuthenticationProperties)
                .ContainsItem(testKey, testValue);
        }

        [Fact]
        public void GetForbid_Should_Return_Forbid_For_AuthenticationSchemes()
        {
            const string testScheme = "testScheme";

            var testAuthenticationSchemes = new[] { testScheme };

            var controller = new ApiController();
            controller.GetForbid(testAuthenticationSchemes)
                .Should()
                .BeForbidResult()
                .WithAuthenticationSchemes(testAuthenticationSchemes)
                .ContainsScheme(testScheme);
        }

        [Fact]
        public void GetForbid_Should_Return_Forbid_For_AuthenticationProperties_And_AuthenticationSchemes()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            const string testRedirectUri = "testRedirectUri";
            const bool testIsPersistent = true;
            const bool testAllowRefresh = true;
            var testIssuedUtc = DateTimeOffset.Now;
            var testExpiresUtc = DateTimeOffset.Now.AddHours(1);
            const string testScheme = "testScheme";

            var items = new Dictionary<string, string> { { testKey, testValue } };
            var testAuthenticationProperties = new AuthenticationProperties(items)
            {
                RedirectUri = testRedirectUri,
                IsPersistent = testIsPersistent,
                AllowRefresh = testAllowRefresh,
                IssuedUtc = testIssuedUtc,
                ExpiresUtc = testExpiresUtc,
            };

            var testAuthenticationSchemes = new[] { testScheme };

            var controller = new ApiController();
            controller.GetForbid(testAuthenticationProperties, testAuthenticationSchemes)
                .Should()
                .BeForbidResult()
                .WithRedirectUri(testRedirectUri)
                .WithIsPersistent(testIsPersistent)
                .WithAllowRefresh(testAllowRefresh)
                .WithIssuedUtc(testIssuedUtc)
                .WithExpiresUtc(testExpiresUtc)
                .WithAuthenticationProperties(testAuthenticationProperties)
                .WithAuthenticationSchemes(testAuthenticationSchemes)
                .ContainsItem(testKey, testValue)
                .ContainsScheme(testScheme);
        }

        [Fact]
        public void GetNoContent_Should_Return_NoContent()
        {
            var controller = new ApiController();
            controller.GetNoContent().Should().BeNoContentResult();
        }

        [Fact]
        public void GetNotFound_Should_Return_NotFound()
        {
            var controller = new ApiController();
            controller.GetNotFound().Should().BeNotFoundResult();
        }

        [Fact]
        public void GetNotFound_Should_Return_NotFound_With_Value()
        {
            var controller = new ApiController();
            var value = controller.GetNotFound(TestValue).Should().BeNotFoundObjectResult().ValueAs<string>();
            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetUnauthorized_Should_Return_Unauthorized()
        {
            var controller = new ApiController();
            controller.GetUnauthorized().Should().BeUnauthorizedResult();
        }

        [Fact]
        public void GetSignOut_Should_Return_SignOut()
        {
            var controller = new ApiController();
            controller.GetSignOut().Should().BeSignOutResult();
        }

        [Fact]
        public void GetSignOut_Should_Return_SignOut_For_AuthenticationSchemes()
        {
            const string testScheme = "testScheme";

            var testAuthenticationSchemes = new[] { testScheme };

            var controller = new ApiController();
            controller.GetSignOut(testAuthenticationSchemes)
                .Should()
                .BeSignOutResult()
                .WithAuthenticationSchemes(testAuthenticationSchemes)
                .ContainsScheme(testScheme);
        }

        [Fact]
        public void GetSignOut_Should_Return_SignOut_For_AuthenticationProperties_And_AuthenticationSchemes()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            const string testRedirectUri = "testRedirectUri";
            const bool testIsPersistent = true;
            const bool testAllowRefresh = true;
            var testIssuedUtc = DateTimeOffset.Now;
            var testExpiresUtc = DateTimeOffset.Now.AddHours(1);
            const string testScheme = "testScheme";

            var items = new Dictionary<string, string> { { testKey, testValue } };
            var testAuthenticationProperties = new AuthenticationProperties(items)
            {
                RedirectUri = testRedirectUri,
                IsPersistent = testIsPersistent,
                AllowRefresh = testAllowRefresh,
                IssuedUtc = testIssuedUtc,
                ExpiresUtc = testExpiresUtc,
            };

            var testAuthenticationSchemes = new[] { testScheme };

            var controller = new ApiController();
            controller.GetSignOut(testAuthenticationProperties, testAuthenticationSchemes)
                .Should()
                .BeSignOutResult()
                .WithRedirectUri(testRedirectUri)
                .WithIsPersistent(testIsPersistent)
                .WithAllowRefresh(testAllowRefresh)
                .WithIssuedUtc(testIssuedUtc)
                .WithExpiresUtc(testExpiresUtc)
                .WithAuthenticationProperties(testAuthenticationProperties)
                .WithAuthenticationSchemes(testAuthenticationSchemes)
                .ContainsItem(testKey, testValue)
                .ContainsScheme(testScheme);
        }

        [Fact]
        public void GetSignIn_Should_Return_SignIn_For_ClaimsPrincipal_And_AuthenticationScheme()
        {
            const string testScheme = "testScheme";
            var testClaimsPrincipal = new ClaimsPrincipal();

            var controller = new ApiController();
            controller.GetSignIn(testClaimsPrincipal, testScheme)
                .Should()
                .BeSignInResult()
                .WithPrincipal(testClaimsPrincipal)
                .WithAuthenticationScheme(testScheme);
        }

        [Fact]
        public void GetSignIn_Should_Return_SignIn_For_ClaimsPrincipal_And_AuthenticationProperties_And_AuthenticationScheme()
        {
            const string testKey = "testKey";
            const string testValue = "testValue";
            const string testRedirectUri = "testRedirectUri";
            const bool testIsPersistent = true;
            const bool testAllowRefresh = true;
            var testIssuedUtc = DateTimeOffset.Now;
            var testExpiresUtc = DateTimeOffset.Now.AddHours(1);
            const string testScheme = "testScheme";

            var items = new Dictionary<string, string> { { testKey, testValue } };
            var testAuthenticationProperties = new AuthenticationProperties(items)
            {
                RedirectUri = testRedirectUri,
                IsPersistent = testIsPersistent,
                AllowRefresh = testAllowRefresh,
                IssuedUtc = testIssuedUtc,
                ExpiresUtc = testExpiresUtc,
            };

            var testClaimsPrincipal = new ClaimsPrincipal();

            var controller = new ApiController();
            controller.GetSignIn(testClaimsPrincipal, testAuthenticationProperties, testScheme)
                .Should()
                .BeSignInResult()
                .WithRedirectUri(testRedirectUri)
                .WithIsPersistent(testIsPersistent)
                .WithAllowRefresh(testAllowRefresh)
                .WithIssuedUtc(testIssuedUtc)
                .WithExpiresUtc(testExpiresUtc)
                .WithAuthenticationProperties(testAuthenticationProperties)
                .WithAuthenticationScheme(testScheme)
                .WithPrincipal(testClaimsPrincipal)
                .ContainsItem(testKey, testValue);
        }

        [Fact]
        public void GetLocalRedirect_Should_Return_LocalRedirect()
        {
            var testLocalUrl = "localUrl";
            var controller = new ApiController();
            controller.GetLocalRedirect(testLocalUrl)
                .Should()
                .BeLocalRedirectResult()
                .WithLocalUrl(testLocalUrl);
        }

        [Fact]
        public void GetLocalRedirectPermanent_Should_Return_LocalRedirect_WithPermanent()
        {
            var testLocalUrl = "localUrl";
            var controller = new ApiController();
            controller.GetLocalRedirectPermanent(testLocalUrl)
                .Should()
                .BeLocalRedirectResult()
                .WithLocalUrl(testLocalUrl)
                .WithPermanent(true);
        }

        [Fact]
        public void GetLocalRedirectPreserveMethod_Should_Return_LocalRedirect_WithPreserve()
        {
            var testLocalUrl = "localUrl";
            var controller = new ApiController();
            controller.GetLocalRedirectPreserveMethod(testLocalUrl)
                .Should()
                .BeLocalRedirectResult()
                .WithLocalUrl(testLocalUrl)
                .WithPreserveMethod(true);
        }

        [Fact]
        public void GetLocalRedirectPermanentPreserveMethod_Should_Return_LocalRedirect_WithPermanent_WithPreserve()
        {
            var testLocalUrl = "localUrl";
            var controller = new ApiController();
            controller.GetLocalRedirectPermanentPreserveMethod(testLocalUrl)
                .Should()
                .BeLocalRedirectResult()
                .WithLocalUrl(testLocalUrl)
                .WithPreserveMethod(true)
                .WithPreserveMethod(true);
        }

        [Fact]
        public void GetAcceptedAtAction_Should_Return_AcceptedAtAction_WithActionName()
        {
            var controller = new ApiController();
            controller.GetAcceptedAtAction(TestActionName)
                .Should()
                .BeAcceptedAtActionResult()
                .WithActionName(TestActionName);
        }

        [Fact]
        public void GetAcceptedAtAction_Should_Return_AcceptedAtAction_WithActionName_And_With_Value()
        {
            var controller = new ApiController();
            var value = controller.GetAcceptedAtAction(TestActionName, TestValue as object)
                .Should()
                .BeAcceptedAtActionResult()
                .WithActionName(TestActionName)
                .ValueAs<string>();

            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetAcceptedAtAction_Should_Return_AcceptedAtAction_WithActionName_And_WithRouteValues_And_With_Value()
        {
            var controller = new ApiController();
            var value = controller.GetAcceptedAtAction(TestActionName, TestRouteValues, TestValue)
                .Should()
                .BeAcceptedAtActionResult()
                .WithActionName(TestActionName)
                .WithRouteValue(TestRouteKey, TestRouteValue)
                .ValueAs<string>();

            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetAcceptedAtAction_Should_Return_AcceptedAtAction_WithActionName_And_WithControllerName()
        {
            var controller = new ApiController();
            controller.GetAcceptedAtAction(TestActionName, TestControllerName)
                .Should()
                .BeAcceptedAtActionResult()
                .WithActionName(TestActionName)
                .WithControllerName(TestControllerName);
        }

        [Fact]
        public void GetAcceptedAtAction_Should_Return_AcceptedAtAction_WithActionName_And_WithControllerName_WithRouteValues()
        {
            var controller = new ApiController();
            controller.GetAcceptedAtAction(TestActionName, TestControllerName, TestRouteValues)
                .Should()
                .BeAcceptedAtActionResult()
                .WithActionName(TestActionName)
                .WithControllerName(TestControllerName)
                .WithRouteValue(TestRouteKey, TestRouteValue);
        }

        [Fact]
        public void GetAcceptedAtRoute_Should_Return_AcceptedAtRoute_WithRouteName()
        {
            var controller = new ApiController();
            controller.GetAcceptedAtRoute(TestRouteName)
                .Should()
                .BeAcceptedAtRouteResult()
                .WithRouteName(TestRouteName);
        }

        [Fact]
        public void GetAcceptedAtRoute_Should_Return_AcceptedAtRoute_WithRouteName_And_WithRouteValue()
        {
            var controller = new ApiController();
            controller.GetAcceptedAtRoute(TestRouteName, TestRouteValues)
                .Should()
                .BeAcceptedAtRouteResult()
                .WithRouteName(TestRouteName)
                .WithRouteValue(TestRouteKey, TestRouteValue);
        }

        [Fact]
        public void GetAcceptedAtRoute_Should_Return_AcceptedAtRoute_WithRouteValue_And_WithValue()
        {
            var controller = new ApiController();
            var value = controller.GetAcceptedAtRoute(TestRouteValues, TestValue)
                .Should()
                .BeAcceptedAtRouteResult()
                .WithRouteValue(TestRouteKey, TestRouteValue)
                .ValueAs<string>();

            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetAcceptedAtRoute_Should_Return_AcceptedAtRoute_WithRouteValue()
        {
            var controller = new ApiController();
            controller.GetAcceptedAtRoute(TestRouteValues)
                .Should()
                .BeAcceptedAtRouteResult()
                .WithRouteValue(TestRouteKey, TestRouteValue);
        }

        [Fact]
        public void GetAcceptedAtRoute_Should_Return_AcceptedAtRoute_WithRouteName_And_RouteValue_And_WithValue()
        {
            var controller = new ApiController();
            var value = controller.GetAcceptedAtRoute(TestRouteName, TestRouteValues, TestValue)
                .Should()
                .BeAcceptedAtRouteResult()
                .WithRouteName(TestRouteName)
                .WithRouteValue(TestRouteKey, TestRouteValue)
                .ValueAs<string>();

            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetCreatedAtAction_Should_Return_CreatedAtAction_WithActionName_And_WithValue()
        {
            var controller = new ApiController();
            var value = controller.GetCreatedAtAction(TestActionName, TestValue as object)
                .Should()
                .BeCreatedAtActionResult()
                .WithActionName(TestActionName)
                .ValueAs<string>();

            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetCreatedAtAction_Should_Return_CreatedAtAction_WithActionName_And_WithRouteValues_And_WithValue()
        {
            var controller = new ApiController();
            var value = controller.GetCreatedAtAction(TestActionName, TestRouteValues, TestValue)
                .Should()
                .BeCreatedAtActionResult()
                .WithActionName(TestActionName)
                .WithRouteValue(TestRouteKey, TestRouteValue)
                .ValueAs<string>();

            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetCreatedAtAction_Should_Return_CreatedAtAction_WithActionName_And_ControllerName_And_WithRouteValues_And_WithValue()
        {
            var controller = new ApiController();
            var value = controller.GetCreatedAtAction(TestActionName, TestControllerName, TestRouteValues, TestValue)
                .Should()
                .BeCreatedAtActionResult()
                .WithActionName(TestActionName)
                .WithControllerName(TestControllerName)
                .WithRouteValue(TestRouteKey, TestRouteValue)
                .ValueAs<string>();

            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetCreatedAtRoute_Should_Return_CreatedAtRoute_WithRouteName_And_WithValue()
        {
            var controller = new ApiController();
            var value = controller.GetCreatedAtRoute(TestRouteName, TestValue as object)
                .Should()
                .BeCreatedAtRouteResult()
                .WithRouteName(TestRouteName)
                .ValueAs<string>();

            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetCreatedAtRoute_Should_Return_CreatedAtRoute_WithRouteValue_And_WithValue()
        {
            var controller = new ApiController();
            var value = controller.GetCreatedAtRoute(TestRouteValues, TestValue)
                .Should()
                .BeCreatedAtRouteResult()
                .WithRouteValue(TestRouteKey, TestRouteValue)
                .ValueAs<string>();

            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetCreatedAtRoute_Should_Return_CreatedAtRoute_WithRouteName_And_RouteValue_And_WithValue()
        {
            var controller = new ApiController();
            var value = controller.GetCreatedAtRoute(TestRouteName, TestRouteValues, TestValue)
                .Should()
                .BeCreatedAtRouteResult()
                .WithRouteName(TestRouteName)
                .WithRouteValue(TestRouteKey, TestRouteValue)
                .ValueAs<string>();

            value.Should().Be(TestValue);
        }

        [Fact]
        public void GetPhysicalFile_Should_Return_PhysicalFile_WithPhysicalPath_And_WithContentType()
        {
            var controller = new ApiController();
            controller.GetPhysicalFile(TestPhysicalPath, TestContentType)
                .Should()
                .BePhysicalFileResult()
                .WithPhysicalPath(TestPhysicalPath)
                .WithContentType(TestContentType);
        }

        [Fact]
        public void GetPhysicalFile_Should_Return_PhysicalFile_WithPhysicalPath_And_WithContentType_And_WithDownloadFileName()
        {
            var controller = new ApiController();
            controller.GetPhysicalFile(TestPhysicalPath, TestContentType, TestFileDownloadName)
                .Should()
                .BePhysicalFileResult()
                .WithPhysicalPath(TestPhysicalPath)
                .WithContentType(TestContentType)
                .WithFileDownloadName(TestFileDownloadName);
        }

        [Fact]
        public void GetPhysicalFile_Should_Return_PhysicalFile_WithPhysicalPath_And_WithContentType_And_WithLastModified_And_WithEntityTag()
        {
            var controller = new ApiController();
            controller.GetPhysicalFile(TestPhysicalPath, TestContentType, TestLastModified, TestEntityTag)
                .Should()
                .BePhysicalFileResult()
                .WithPhysicalPath(TestPhysicalPath)
                .WithContentType(TestContentType)
                .WithLastModified(TestLastModified)
                .WithEntityTag(TestEntityTag);
        }

        [Fact]
        public void GetPhysicalFile_Should_Return_PhysicalFile_WithPhysicalPath_And_WithContentType_And_WithDownloadFileName_And_WithLastModified_And_WithEntityTag()
        {
            var controller = new ApiController();
            controller.GetPhysicalFile(TestPhysicalPath, TestContentType, TestFileDownloadName, TestLastModified, TestEntityTag)
                .Should()
                .BePhysicalFileResult()
                .WithPhysicalPath(TestPhysicalPath)
                .WithContentType(TestContentType)
                .WithFileDownloadName(TestFileDownloadName)
                .WithLastModified(TestLastModified)
                .WithEntityTag(TestEntityTag);
        }

        [Fact]
        public void GetVirtualFileResult_Should_Return_VirtualFileResult_WithFileName_And_WithContentType_As_String()
        {
            var controller = new ApiController();
            controller.GetVirtualFileResult(TestFileName, TestContentType)
                .Should()
                .BeVirtualFileResult()
                .WithFileName(TestFileName)
                .WithContentType(TestContentType);
        }

        [Fact]
        public void GetVirtualFileResult_Should_Return_VirtualFileResult_WithFileName_And_WithContentType_As_MediaTypeHeaderValue()
        {
            var testMediaTypeHeaderValue = MediaTypeHeaderValue.Parse(new StringSegment(TestContentType));
            var controller = new ApiController();
            controller.GetVirtualFileResult(TestFileName, testMediaTypeHeaderValue)
                .Should()
                .BeVirtualFileResult()
                .WithFileName(TestFileName)
                .WithContentType(testMediaTypeHeaderValue.ToString());
        }

        #endregion Public Methods
    }
}
