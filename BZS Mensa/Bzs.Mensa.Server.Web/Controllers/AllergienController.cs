using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bzs.Mensa.Server.Web.Controllers
{
    [Route("api/allergien")]
    [ApiController]
    public class AllergienController : ControllerBase
    {
        private readonly IAllergienService allergienService;
        public AllergienController(IConfiguration configuration, IAllergienService allergienService) 
        { 
            this.allergienService = allergienService;
        }

        [HttpGet()]
        public ActionResult<List<AllergieEditDto>> Allergien()
        {
            return this.allergienService.AllergienListe();
        }
    }
}
