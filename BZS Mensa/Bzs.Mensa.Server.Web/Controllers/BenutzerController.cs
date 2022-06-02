using Bzs.Mensa.Server.Services;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Bzs.Mensa.Server.Web.Controllers
{
    /// <summary>
    /// Represents a user controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class BenutzerController : ControllerBase
    {
        private readonly IBenutzerService benutzerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerController" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="benutzerService">The user service.</param>
        public BenutzerController(IConfiguration configuration, IBenutzerService benutzerService)
        {
            this.benutzerService = benutzerService;
        }

        /// <summary>
        /// Returns a meal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpGet(@"ping")]
        public async Task<ActionResult<string>> PingAsync()
        {
            this.SetResponseHeaderCacheExpiration();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"---------- PING ----------");
            sb.Append(@"Database: ");
            sb.AppendLine(((BenutzerService)this.benutzerService).IsDatabaseAlive ? @"Connected" : @"Disconnected");

            return sb.ToString();
        }

        /// <summary>
        /// Returns all user.
        /// </summary>
        /// <returns>The data.</returns>
        [HttpGet()]
        public async Task<ActionResult<List<BenutzerEditDto>>> BenutzerAsync()
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.benutzerService.GetBenutzerAsync().ConfigureAwait(true);
        }

        /// <summary>
        /// Returns the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpGet("item/{id}")]
        public async Task<ActionResult<BenutzerEditDto>> BenutzerAsync(Guid id)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.benutzerService.GetBenutzerAsync(id).ConfigureAwait(true);
        }

        /// <summary>
        /// Saves the user.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        [HttpPost("item")]
        public async Task<ActionResult<ResultDto>> SaveBenutzerAsync([FromBody] BenutzerEditDto item)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.benutzerService.SaveBenutzerAsync(item).ConfigureAwait(true);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier of the item to delete.</param>
        /// <returns>The result.</returns>
        [HttpDelete("item/{id}")]
        public async Task<ActionResult<ResultDto>> DeleteBenutzerAsync(Guid id)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.benutzerService.DeleteBenutzerAsync(id).ConfigureAwait(true);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier of the item to delete.</param>
        /// <returns>The result.</returns>
        [HttpPost("item/{id}/password")]
        public async Task<ActionResult<ResultDto>> SetPasswordAsync([FromBody] BenutzerPasswortDto item)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.benutzerService.SetBenutzerPasswortAsync(item).ConfigureAwait(true);
        }
    }
}
