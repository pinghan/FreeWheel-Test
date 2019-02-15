using System;
using System.Collections.Generic;

namespace FreeWheel.Models
{
    public partial class Program
    {
        public int ProgramId { get; set; }
        public int? StationId { get; set; }
        public string ProgramName { get; set; }
        public DateTime? FlightDate { get; set; }
    }
}
