using Bzs.Mensa.Server.Services;
using Bzs.Mensa.Server.Services.Security;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bzs.Mensa.Server.Web.Controllers
{
    /// <summary>
    /// Represents a security controller.
    /// </summary>
    [Route("api/security")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ISecurityService securityService;
        private readonly IBenutzerService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityController" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="securityService">The security service.</param>
        /// <param name="userService">The user service.</param>
        public SecurityController(IConfiguration configuration, ISecurityService securityService, IBenutzerService userService)
        {
            this.configuration = configuration;
            this.securityService = securityService;
            this.userService = userService;
        }

        /// <summary>
        /// Login to the application.
        /// </summary>
        /// <returns>The result.</returns>
        [HttpPost("login")]
        public async Task<ActionResult<LoginResultDto>> LoginAsync()
        {
            this.SetResponseHeaderCacheExpiration();

            string userName = null;
            string password = null;

            // Read user/password from HTTP header.
            if (this.Request.Headers.TryGetValue(@"Authorization", out StringValues authToken))
            {
                string authHeader = authToken.First();
                string encodedUsernamePassword = authHeader.Substring(@"Basic ".Length).Trim();
                string usernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
                int separatorIndex = usernamePassword.IndexOf(':', StringComparison.InvariantCulture);
                userName = usernamePassword.Substring(0, separatorIndex);
                password = usernamePassword.Substring(separatorIndex + 1);
            }

            this.userService.CreateAdministrator();
            AuthenticationUser authenticationUser = ((SecurityService)this.securityService).GetLoginUser(userName, password);
            if (authenticationUser == null)
            {
                return this.Unauthorized();
            }

            // Generates the token.
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(this.configuration.GetSection(@"AppSettings:Token").Value);
            SecurityTokenDescriptor? tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, authenticationUser.UserId.ToString()),
                    new Claim(ClaimTypes.Name, authenticationUser.UserName),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);
            return new LoginResultDto(tokenString);
        }
    }
}
