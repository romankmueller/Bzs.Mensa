using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
