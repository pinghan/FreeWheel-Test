using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeWheel.Models;

namespace FreeWheel.Repositories
{
    public interface IMarketPopRepository
    {
        List<MarketPop> GetMissingRecords();
    }
}
