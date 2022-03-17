using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Http;
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
    }
}
