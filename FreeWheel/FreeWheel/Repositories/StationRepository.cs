using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeWheel.Models;

namespace FreeWheel.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly FreeWheelDBContext _freeWheelDbContext;

        public StationRepository(FreeWheelDBContext freeWheelDbContext)
        {
            _freeWheelDbContext = freeWheelDbContext;
        }

        /// <summary>
        /// Get all the stations
        /// </summary>
        /// <returns>A collection of Stations</returns>
        public IEnumerable<Station> GetAllStations()
        {
            return _freeWheelDbContext.Station.AsEnumerable();
        }
    }
}
