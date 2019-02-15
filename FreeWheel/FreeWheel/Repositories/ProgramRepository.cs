using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeWheel.Models;

namespace FreeWheel.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly FreeWheelDBContext _freeWheelDbContext;

        public ProgramRepository(FreeWheelDBContext freeWheelDbContext)
        {
            _freeWheelDbContext = freeWheelDbContext;
        }

        /// <summary>
        /// Get all the Program Names from Program table
        /// </summary>
        /// <returns>A collection of Program Names</returns>
        public IEnumerable<Models.Program> GetAllPrograms()
        {
            return _freeWheelDbContext.Program.AsEnumerable();
        }

        /// <summary>
        /// Process program names and return a comma-separated string
        /// </summary>
        /// <returns>comma-separated string containing all the program namess</returns>
        public string ProcessProgramName()
        {
            string nameStr = string.Empty;
            try
            {
                // Get all the program names
                var programNames = (from p in _freeWheelDbContext.Program
                                    where !string.IsNullOrEmpty(p.ProgramName)
                                    select p.ProgramName);

                // Sort the names in in alphabetical order and add apostrophe to them
                var processedNames = programNames.OrderBy(p => p).Select(p => $"'{ p.Trim().Replace("'", "''")}'").ToArray();

                // Get a comma-separated string
                nameStr = string.Join(",", processedNames);
            }
            catch (Exception ex)
            {
                // handle exceptions
            }

            return nameStr;
        }

        /// <summary>
        /// Get program by station id. If there are multiple records with the same earliest FLIGHT_DATE 
        /// for the station, it should display the first PROGRAM_NAME in alphabetical order.
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public Models.Program GetProgramByStationId(int stationId)
        {
            var program = _freeWheelDbContext.Program.Where(p => p.StationId == stationId)
                .OrderBy(p => p.FlightDate).ThenBy(p => p.ProgramName)?.FirstOrDefault();
            return program;
        }
    }
}
