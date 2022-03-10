using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace Bzs.Mensa.Server.Web.Controllers
{
    /// <summary>
    /// Represents a controller base.
    /// </summary>
    public abstract class ControllerBase : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerBase" /> class.
        /// </summary>
        protected ControllerBase()
        {
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        protected Guid UserId
        {
            get
            {
                return new Guid(this.User.Claims.First(f => f.Type == ClaimTypes.NameIdentifier).Value);
            }
        }

        /// <summary>
        /// Gets the user name.
        /// </summary>
        protected string UserName
        {
            get
            {
                return this.User.Claims.First(f => f.Type == ClaimTypes.Name).Value;
            }
        }

        /// <summary>
        /// Sets the response header with a validation time, so that the clients have to request the server again.
        /// </summary>
        /// <param name="minutesOfExpiration">The validation date in minutes.</param>
        protected void SetResponseHeaderCacheExpiration(int minutesOfExpiration = -1)
        {
            this.Response.Headers.Add(@"Expires", minutesOfExpiration.ToString(CultureInfo.InvariantCulture));
            this.Response.Headers.Add(@"Cache-Control", @"no-cache, no-store");
        }
    }
}
