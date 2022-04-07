 using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bzs.Mensa.Server.Web.Controllers
{
    /// <summary>
    /// Represents a holiday controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class FeiertagController : ControllerBase
    {
        private readonly IFeiertagService feiertagService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeiertagController" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="feiertagService">The holiday service.</param>
        public FeiertagController(IConfiguration configuration, IFeiertagService feiertagService)
        {
            this.feiertagService = feiertagService;
        }

        /// <summary>
        /// Returns all holidays.
        /// </summary>
        /// <returns>The data.</returns>
        [HttpGet()]
        public async Task<ActionResult<List<FeiertagEditDto>>> FeiertageAsync()
        {
            return await this.feiertagService.GetFeiertageAsync().ConfigureAwait(true);
        }

        /// <summary>
        /// Returns the holiday.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpGet("item/{id}")]
        public async Task<ActionResult<FeiertagEditDto>> FeiertagAsync(Guid id)
        {
            return await this.feiertagService.GetFeiertagAsync(id).ConfigureAwait(true);
        }

        /// <summary>
        /// Saves the holiday.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        [HttpPost("item")]
        public async Task<ActionResult<ResultDto>> SaveFeiertagAsync([FromBody] FeiertagEditDto item)
        {
            return await this.feiertagService.SaveFeiertagAsync(item).ConfigureAwait(true);
        }

        /// <summary>
        /// Deletes the holiday.
        /// </summary>
        /// <param name="id">The identifier of the item to delete.</param>
        /// <returns>The result.</returns>
        [HttpDelete("item/{id}")]
        public async Task<ActionResult<ResultDto>> DeleteFeiertagAsync(Guid id)
        {
            return await this.feiertagService.DeleteFeiertagAsync(id).ConfigureAwait(true);
        }
    }
}
