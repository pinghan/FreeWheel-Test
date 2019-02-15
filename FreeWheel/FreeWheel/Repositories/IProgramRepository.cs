using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeWheel.Repositories
{
    public interface IProgramRepository
    {
        IEnumerable<Models.Program> GetAllPrograms();
        string ProcessProgramName();
        Models.Program GetProgramByStationId(int stationId);
    }
}
