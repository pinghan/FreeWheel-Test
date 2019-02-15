using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeWheel.Common;
using FreeWheel.Models;

namespace FreeWheel.Repositories
{
    public class MarketPopRepository
    {
        private readonly FreeWheelDBContext _freeWheelDbContext;

        public MarketPopRepository(FreeWheelDBContext freeWheelDbContext)
        {
            _freeWheelDbContext = freeWheelDbContext;
        }

        /// <summary>
        /// Get the missing records in MarketPop table 
        /// </summary>
        /// <returns></returns>
        public List<MarketPop> GetMissingRecords()
        {
            // Get the existing records in MarketPop table
            var existingMarketPops = _freeWheelDbContext.MarketPop.ToList();

            // Find out all the combinations
            var marketIds = _freeWheelDbContext.Market.Select(m => m.MarketId);
            var cellIds = _freeWheelDbContext.Cells.Select(c => c.CellId);
            var wholeMarketPops = (from m in marketIds
                                   from c in cellIds
                                   select new MarketPop { MarketId = m, CellId = c }).ToList();

            // Get the missing records
            var missingRecords = wholeMarketPops.Except(existingMarketPops, new MyEqualityComparer()).ToList();

            return missingRecords;
        }
    }
}
