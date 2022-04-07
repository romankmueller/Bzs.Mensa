using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bzs.Mensa.Server.Web.Controllers
{
    /// <summary>
    /// Represents a class controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class KlasseController : ControllerBase
    {
        private readonly IKlasseService klasseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AllergienController" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="klasseService">The class service.</param>
        public KlasseController(IConfiguration configuration, IKlasseService klasseService)
        {
            this.klasseService = klasseService;
        }

        /// <summary>
        /// Returns all classes.
        /// </summary>
        /// <returns>The data.</returns>
        [HttpGet()]
        public async Task<ActionResult<List<KlasseEditDto>>> KlassenAsync()
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.klasseService.GetKlassenAsync().ConfigureAwait(true);
        }

        /// <summary>
        /// Returns the class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpGet("item/{id}")]
        public async Task<ActionResult<KlasseEditDto>> KlasseAsync(Guid id)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.klasseService.GetKlasseAsync(id).ConfigureAwait(true);
        }

        /// <summary>
        /// Saves the class.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        [HttpPost("item")]
        public async Task<ActionResult<ResultDto>> SaveKlasseAsync([FromBody] KlasseEditDto item)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.klasseService.SaveKlasseAsync(item).ConfigureAwait(true);
        }

        /// <summary>
        /// Deletes the class.
        /// </summary>
        /// <param name="id">The identifier of the item to delete.</param>
        /// <returns>The result.</returns>
        [HttpDelete("item/{id}")]
        public async Task<ActionResult<ResultDto>> DeleteKlasseAsync(Guid id)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.klasseService.DeleteKlasseAsync(id).ConfigureAwait(true);
        }
    }
}
