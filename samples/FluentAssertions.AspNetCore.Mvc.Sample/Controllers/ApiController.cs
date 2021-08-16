using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Net.Http.Headers;
using System;
using System.Security.Claims;

namespace FluentAssertions.AspNetCore.Mvc.Sample.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ApiController : Controller
    {
        #region Accepted
        [HttpGet]
        public IActionResult GetAccepted()
        {
            return Accepted();
        }

        [HttpGet]
        public IActionResult GetAccepted(Uri uri)
        {
            return Accepted(uri);
        }

        [HttpGet]
        public IActionResult GetAccepted(Uri uri, object value)
        {
            return Accepted(uri, value);
        }

        [HttpGet]
        public IActionResult GetAccepted(object value)
        {
            return Accepted(value);
        }

        [HttpGet]
        public IActionResult GetAccepted(string uri)
        {
            return Accepted(uri);
        }

        #endregion

        #region AcceptedAtAction
        [HttpGet]
        public IActionResult GetAcceptedAtAction(string actionName)
        {
            return AcceptedAtAction(actionName);
        }

        [HttpGet]
        public IActionResult GetAcceptedAtAction(string actionName, object routeValues, object value)
        {
            return AcceptedAtAction(actionName, routeValues, value);
        }

        [HttpGet]
        public IActionResult GetAcceptedAtAction(string actionName, object value)
        {
            return AcceptedAtAction(actionName, value);
        }

        [HttpGet]
        public IActionResult GetAcceptedAtAction(string actionName, string controllerName)
        {
            return AcceptedAtAction(actionName, controllerName);
        }

        [HttpGet]
        public IActionResult GetAcceptedAtAction(string actionName, string controllerName, object routeValues)
        {
            return AcceptedAtAction(actionName, controllerName, routeValues);
        }
        #endregion

        #region AcceptedAtRoute
        [HttpGet]
        public IActionResult GetAcceptedAtRoute(string routeName)
        {
            return AcceptedAtRoute(routeName);
        }

        [HttpGet]
        public IActionResult GetAcceptedAtRoute(string routeName, object routeValues)
        {
            return AcceptedAtRoute(routeName, routeValues);
        }

        [HttpGet]
        public IActionResult GetAcceptedAtRoute(object routeValues, object value)
        {
            return AcceptedAtRoute(routeValues, value);
        }

        [HttpGet]
        public IActionResult GetAcceptedAtRoute(object routeValues)
        {
            return AcceptedAtRoute(routeValues);
        }

        [HttpGet]
        public IActionResult GetAcceptedAtRoute(string routeName, object routeValues, object value)
        {
            return AcceptedAtRoute(routeName, routeValues, value);
        }
        #endregion

        #region Ok
        [HttpGet]
        public IActionResult GetOk()
        {
            return Ok();
        }

        public IActionResult GetOk(object value)
        {
            return Ok(value);
        }
        #endregion

        #region BadRequest
        [HttpGet]
        public IActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetBadRequest(ModelStateDictionary modelState)
        {
            return BadRequest(modelState);
        }

        [HttpGet]
        public IActionResult GetBadRequest(object error)
        {
            return BadRequest(error);
        }

        #endregion

        #region Created
        [HttpGet]
        public IActionResult GetCreated(Uri uri, object value)
        {
            return Created(uri, value);
        }

        [HttpGet]
        public IActionResult GetCreated(string uri, object value)
        {
            return Created(uri, value);
        }
        #endregion

        #region CreatedAtAction
        [HttpGet]
        public IActionResult GetCreatedAtAction(string actionName, object routeValues, object value)
        {
            return CreatedAtAction(actionName, routeValues, value);
        }

        [HttpGet]
        public IActionResult GetCreatedAtAction(string actionName, object value)
        {
            return CreatedAtAction(actionName, value);
        }

        [HttpGet]
        public IActionResult GetCreatedAtAction(string actionName, string controllerName, object routeValues, object value)
        {
            return CreatedAtAction(actionName, controllerName, routeValues, value);
        }
        #endregion

        #region CreatedAtRoute
        [HttpGet]
        public IActionResult GetCreatedAtRoute(string routeName, object value)
        {
            return CreatedAtRoute(routeName, value);
        }

        [HttpGet]
        public IActionResult GetCreatedAtRoute(object routeValues, object value)
        {
            return CreatedAtRoute(routeValues, value);
        }

        [HttpGet]
        public IActionResult GetCreatedAtRoute(string routeName, object routeValues, object value)
        {
            return CreatedAtRoute(routeName, routeValues, value);
        }
        #endregion

        #region Challenge
        [HttpGet]
        public IActionResult GetChallenge()
        {
            return Challenge();
        }

        [HttpGet]
        public IActionResult GetChallenge(AuthenticationProperties authenticationProperties)
        {
            return Challenge(authenticationProperties);
        }

        [HttpGet]
        public IActionResult GetChallenge(string[] authenticationSchemes)
        {
            return Challenge(authenticationSchemes);
        }

        [HttpGet]
        public IActionResult GetChallenge(AuthenticationProperties authenticationProperties, string[] authenticationSchemes)
        {
            return Challenge(authenticationProperties, authenticationSchemes);
        }

        #endregion

        #region Forbid
        [HttpGet]
        public IActionResult GetForbid()
        {
            return Forbid();
        }

        [HttpGet]
        public IActionResult GetForbid(AuthenticationProperties authenticationProperties)
        {
            return Forbid(authenticationProperties);
        }

        [HttpGet]
        public IActionResult GetForbid(string[] authenticationSchemes)
        {
            return Forbid(authenticationSchemes);
        }

        [HttpGet]
        public IActionResult GetForbid(AuthenticationProperties authenticationProperties, string[] authenticationSchemes)
        {
            return Forbid(authenticationProperties, authenticationSchemes);
        }

        #endregion

        #region NoContent
        [HttpGet]
        public IActionResult GetNoContent()
        {
            return NoContent();
        }

        #endregion

        #region NotFound
        [HttpGet]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }

        public IActionResult GetNotFound(object value)
        {
            return NotFound(value);
        }
        #endregion

        #region Unauthorized
        [HttpGet]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        #endregion

        #region SignIn
        [HttpGet]
        public IActionResult GetSignIn(ClaimsPrincipal claimsPrincipal, string authenticationScheme)
        {
            return SignIn(claimsPrincipal, authenticationScheme);
        }

        [HttpGet]
        public IActionResult GetSignIn(ClaimsPrincipal claimsPrincipal, AuthenticationProperties authenticationProperties, string authenticationScheme)
        {
            return SignIn(claimsPrincipal, authenticationProperties, authenticationScheme);
        }
        #endregion

        #region SignOut
        [HttpGet]
        public IActionResult GetSignOut()
        {
            return SignOut();
        }

        [HttpGet]
        public IActionResult GetSignOut(string[] authenticationSchemes)
        {
            return SignOut(authenticationSchemes);
        }

        [HttpGet]
        public IActionResult GetSignOut(AuthenticationProperties authenticationProperties, string[] authenticationSchemes)
        {
            return SignOut(authenticationProperties, authenticationSchemes);
        }

        #endregion

        #region LocalRedirect
        [HttpGet]
        public IActionResult GetLocalRedirect(string localUrl)
        {
            return LocalRedirect(localUrl);
        }
        #endregion

        #region LocalRedirectPermanent
        [HttpGet]
        public IActionResult GetLocalRedirectPermanent(string localUrl)
        {
            return LocalRedirectPermanent(localUrl);
        }
        #endregion

        #region LocalRedirectPreserveMethod
        [HttpGet]
        public IActionResult GetLocalRedirectPreserveMethod(string localUrl)
        {
            return LocalRedirectPreserveMethod(localUrl);
        }
        #endregion

        #region LocalRedirectPermanentPreserveMethod
        [HttpGet]
        public IActionResult GetLocalRedirectPermanentPreserveMethod(string localUrl)
        {
            return LocalRedirectPermanentPreserveMethod(localUrl);
        }
        #endregion

        #region PhysicalFile
        [HttpGet]
        public IActionResult GetPhysicalFile(string physicalPath, string contentType)
        {
            return PhysicalFile(physicalPath, contentType);
        }

        [HttpGet]
        public IActionResult GetPhysicalFile(string physicalPath, string contentType, string fileDownloadName)
        {
            return PhysicalFile(physicalPath, contentType, fileDownloadName);
        }

        [HttpGet]
        public IActionResult GetPhysicalFile(string physicalPath, string contentType, DateTimeOffset? lastModified, EntityTagHeaderValue entityTag)
        {
            return PhysicalFile(physicalPath, contentType, lastModified, entityTag);
        }

        [HttpGet]
        public IActionResult GetPhysicalFile(string physicalPath, string contentType, string fileDownloadName, DateTimeOffset? lastModified, EntityTagHeaderValue entityTag)
        {
            return PhysicalFile(physicalPath, contentType, fileDownloadName, lastModified, entityTag);
        }
        #endregion

        #region VirtualFile
        [HttpGet]
        public IActionResult GetVirtualFileResult(string fileName, string contentType)
        {
            return File(fileName, contentType);
        }

        [HttpGet]
        public IActionResult GetVirtualFileResult(string fileName, MediaTypeHeaderValue mediaTypeHeaderValue)
        {
            return new VirtualFileResult(fileName, mediaTypeHeaderValue);
        }

        #endregion
    }
}