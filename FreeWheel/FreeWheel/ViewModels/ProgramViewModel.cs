using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeWheel.Models;

namespace FreeWheel.ViewModels
{
    public class ProgramViewModel
    {
        public int StationId { get; set; }
        public List<Station> Stations { get; set; }
        public string FlightDate { get; set; }
        public string ProgramName { get; set; }
    }
}
