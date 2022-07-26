using CanWeFixIt.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixIt.Data
{
    public interface IDatabaseService
    {
        Task<IEnumerable<Instrument>> Instruments();
        Task<IEnumerable<MarketDataDto>> MarketData();
        Task<IEnumerable<Valuation>> Valuations();
        void SetupDatabase();
    }
}