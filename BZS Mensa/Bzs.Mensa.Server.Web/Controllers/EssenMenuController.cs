using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bzs.Mensa.Server.Web.Controllers
{
    /// <summary>
    /// Represents a meal menu controller.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public sealed class EssenMenuController : ControllerBase
    {
        private readonly IEssenMenuService essenMenuService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenMenuController" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="essenMenuService">The meal menu service.</param>
        public EssenMenuController(IConfiguration configuration, IEssenMenuService essenMenuService)
        {
            this.essenMenuService = essenMenuService;
        }

        /// <summary>
        /// Returns the meal menu.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpPost("requestitem")]
        public async Task<ActionResult<EssenMenuEditDto>> EssenMenuAsync([FromBody] EssenMenuRequestDto requestItem)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.essenMenuService.EssenMenuAsync(requestItem).ConfigureAwait(true);
        }

        /// <summary>
        /// Returns the meal menu.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpGet("item/{id}")]
        public async Task<ActionResult<EssenMenuEditDto>> EssenMenuAsync(Guid id)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.essenMenuService.EssenMenuAsync(id).ConfigureAwait(true);
        }

        /// <summary>
        /// Saves the meal menu.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        [HttpPost("item")]
        public async Task<ActionResult<ResultDto>> SaveEssenMenuAsync([FromBody] EssenMenuEditDto item)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.essenMenuService.SaveEssenMenuAsync(item).ConfigureAwait(true);
        }

        /// <summary>
        /// Deletes the meal menu.
        /// </summary>
        /// <param name="id">The identifier of the item to delete.</param>
        /// <returns>The result.</returns>
        [HttpDelete("item/{id}")]
        public async Task<ActionResult<ResultDto>> DeleteEssenMenuAsync(Guid id)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.essenMenuService.DeleteEssenMenuAsync(id).ConfigureAwait(true);
        }
    }
}
