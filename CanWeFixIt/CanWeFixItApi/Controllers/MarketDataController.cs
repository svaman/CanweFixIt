using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixIt.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/marketdata")]
    public class MarketDataController : ControllerBase
    {
        // GET
        public async Task<ActionResult<IEnumerable<MarketDataDto>>> Get()
        {
            // TODO:

            return NotFound();
        }
    }
}