using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bzs.Mensa.Server.Web.Controllers
{
    /// <summary>
    /// Represents an allergy controller.
    /// </summary>
    [Route("api/allergien")]
    [ApiController]
    public sealed class AllergienController : ControllerBase
    {
        private readonly IAllergienService allergienService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AllergienController" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="allergienService">The allergy service.</param>
        public AllergienController(IConfiguration configuration, IAllergienService allergienService) 
        { 
            this.allergienService = allergienService;
        }

        /// <summary>
        /// Returns all allergies.
        /// </summary>
        /// <returns>The data.</returns>
        [HttpGet()]
        public async Task<ActionResult<List<AllergieEditDto>>> AllergienAsync()
        {
            return await this.allergienService.GetAllergienAsync().ConfigureAwait(true);
        }

        /// <summary>
        /// Returns the allergy.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpGet("item/{id}")]
        public async Task<ActionResult<AllergieEditDto>> AllergieAsync(Guid id)
        {
            return await this.allergienService.GetAllergieAsync(id).ConfigureAwait(true);
        }

        /// <summary>
        /// Saves the allergy.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        [HttpPost("item")]
        public async Task<ActionResult<ResultDto>> SaveAllergieAsync([FromBody] AllergieEditDto item)
        {
            return await this.allergienService.SaveAllergieAsync(item).ConfigureAwait(true);
        }

        /// <summary>
        /// Deletes the allergy.
        /// </summary>
        /// <param name="id">The identifier of the item to delete.</param>
        /// <returns>The result.</returns>
        [HttpDelete("item/{id}")]
        public async Task<ActionResult<ResultDto>> DeleteAllergieAsync(Guid id)
        {
            return await this.allergienService.DeleteAllergieAsync(id).ConfigureAwait(true);
        }
    }
}
