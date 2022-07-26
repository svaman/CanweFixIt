using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixIt.Data;
using CanWeFixIt.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/marketdata")]
    public class MarketDataController : ControllerBase
    {
        private readonly IDatabaseService _database;
        private readonly ILogger _logger;

        public MarketDataController(IDatabaseService database, ILogger logger)
        {
            _database = database;
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<MarketDataDto>>> Get()
        {
            _logger.LogInformation("MarketDataController Get() called");

            return Ok(_database.MarketData().Result);
        }
    }
}