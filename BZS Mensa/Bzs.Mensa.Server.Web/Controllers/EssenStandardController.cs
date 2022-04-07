using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bzs.Mensa.Server.Web.Controllers
{
    /// <summary>
    /// Represents a meal default controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class EssenStandardController : ControllerBase
    {
        private readonly IEssenStandardService essenStandardService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenStandardController" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="essenStandardService">The meal default service.</param>
        public EssenStandardController(IConfiguration configuration, IEssenStandardService essenStandardService)
        {
            this.essenStandardService = essenStandardService;
        }

        /// <summary>
        /// Returns the meal menu.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpGet("item/byuser/{id}")]
        public async Task<ActionResult<EssenStandardEditDto>> EssenStandardByBenutzerAsync(Guid benutzerId)
        {
            return await this.essenStandardService.EssenStandardByBenutzerAsync(benutzerId).ConfigureAwait(true);
        }

        /// <summary>
        /// Returns the meal menu.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpGet("item/{id}")]
        public async Task<ActionResult<EssenStandardEditDto>> EssenStandardAsync(Guid id)
        {
            return await this.essenStandardService.EssenStandardAsync(id).ConfigureAwait(true);
        }

        /// <summary>
        /// Returns the meal menu.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpPost("item")]
        public async Task<ActionResult<ResultDto>> SaveEssenStandardAsync([FromBody] EssenStandardEditDto item)
        {
            return await this.essenStandardService.SaveEssenStandardAsync(item).ConfigureAwait(true);
        }
    }
}
