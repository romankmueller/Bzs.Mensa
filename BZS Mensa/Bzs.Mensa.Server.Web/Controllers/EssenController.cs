﻿using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bzs.Mensa.Server.Web.Controllers
{
    /// <summary>
    /// Represents a meal controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EssenController : ControllerBase
    {
        private readonly IEssenService essenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EssenController" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="essenService">The meal service.</param>
        public EssenController(IConfiguration configuration, IEssenService essenService)
        {
            this.essenService = essenService;
        }

        /// <summary>
        /// Returns the meal overview.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The data.</returns>
        [HttpGet(@"uebersicht/{userId}")]
        public async Task<ActionResult<EssenUebersichtDto>> GetEssenUebersicht(Guid userId)
        {
            
            this.SetResponseHeaderCacheExpiration();
            return await this.essenService.GetEssenUebersichtAsync(userId).ConfigureAwait(true);
        }

        /// <summary>
        /// Returns a meal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        [HttpGet(@"item/{id}")]
        public async Task<ActionResult<EssenEditDto>> EssenAsync(Guid id)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.essenService.EssenAsync(id).ConfigureAwait(true);
        }

        /// <summary>
        /// Saves a single meal.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns></returns>
        [HttpPost(@"item")]
        public async Task<ActionResult<ResultDto>> SaveEssenAsync([FromBody] EssenEditDto item)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.essenService.SaveEssenAsync(item).ConfigureAwait(true);
        }

        /// <summary>
        /// Deletes the meal.
        /// </summary>
        /// <param name="id">The identifier of the item to delete.</param>
        /// <returns>The result.</returns>
        [HttpDelete(@"item/{id}")]
        public async Task<ActionResult<ResultDto>> DeleteEssenAsync(Guid id)
        {
            this.SetResponseHeaderCacheExpiration();
            return await this.essenService.DeleteEssenAsync(id).ConfigureAwait(true);
        }
    }
}
