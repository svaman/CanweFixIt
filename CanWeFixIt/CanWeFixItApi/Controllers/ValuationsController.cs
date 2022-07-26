using CanWeFixIt.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixIt.Api.Controllers
{
    [ApiController]
    [Route("v1/valuations")]
    public class ValuationsController : ControllerBase
    {
        // GET
        public async Task<ActionResult<IEnumerable<MarketValuation>>> Get()
        {
            // TODO:

            return NotFound();
        }
    }
}
