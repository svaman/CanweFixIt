using CanWeFixIt.Data;
using CanWeFixIt.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixIt.Api.Controllers
{
    [ApiController]
    [Route("v1/valuations")]
    public class ValuationsController : ControllerBase
    {

        private readonly IDatabaseService _database;
        private readonly ILogger _logger;

        public ValuationsController(IDatabaseService database, ILogger logger)
        {
            _database = database;
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<Valuation>>> Get()
        {
            _logger.LogInformation("ValuationsController Get() called");

            return Ok(_database.Valuations().Result);
        }
    }
}
