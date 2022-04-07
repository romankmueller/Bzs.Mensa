using Bzs.Mensa.Server.Services;
using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bzs.Mensa.Server.Web.Controllers
{
    /// <summary>
    /// Represents a vacation controller.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public sealed class FerienController : ControllerBase
    {
        private readonly IFerienService ferienService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FerienController" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="ferienService">The vacation service.</param>
        public FerienController(IConfiguration configuration, IFerienService ferienService)
        {
            this.ferienService = ferienService;
        }

        /// <summary>
        /// Returns all vacations.
        /// </summary>
        /// <returns>The data.</returns>
        [HttpGet()]
        public async Task<ActionResult<List<FerienEditDto>>> FerienAsync()
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.ferienService.GetFerienAsync().ConfigureAwait(true);
        }

        /// <summary>
        /// Returns the vacation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpGet("item/{id}")]
        public async Task<ActionResult<FerienEditDto>> FerienAsync(Guid id)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.ferienService.GetFerienAsync(id).ConfigureAwait(true);
        }

        /// <summary>
        /// Saves the vacation.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        [HttpPost("item")]
        public async Task<ActionResult<ResultDto>> SaveFeiertagAsync([FromBody] FerienEditDto item)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.ferienService.SaveFerienAsync(item).ConfigureAwait(true);
        }

        /// <summary>
        /// Deletes the vacation.
        /// </summary>
        /// <param name="id">The identifier of the item to delete.</param>
        /// <returns>The result.</returns>
        [HttpDelete("item/{id}")]
        public async Task<ActionResult<ResultDto>> DeleteFerienAsync(Guid id)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.ferienService.DeleteFerienAsync(id).ConfigureAwait(true);
        }
    }
}
