using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixIt.Data;
using CanWeFixIt.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CanWeFixIt.Api.Controllers
{
    [ApiController]
    [Route("v1/instruments")]
    public class InstrumentController : ControllerBase
    {
        private readonly IDatabaseService _database;
        private readonly ILogger _logger;

        public InstrumentController(IDatabaseService database, ILogger logger)
        {
            _database = database;
            _logger = logger;
        }

        // GET
        public async Task<ActionResult<IEnumerable<Instrument>>> Get()
        {
            _logger.LogInformation("Instrument get called");
            return Ok(_database.Instruments().Result);
        }
    }
}