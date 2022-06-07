using System;
using System.Collections.Generic;

namespace AdminModule.Models
{
    public partial class AirlineSchedule
    {
        public int Id { get; set; }
        public string AirlineId { get; set; }
        public int? Flightnumber { get; set; }
        public string Fromplace { get; set; }
        public string ToPlace { get; set; }
        public string StartDatetime { get; set; }
        public string EndDatetime { get; set; }
        public string ScheduledDay { get; set; }
        public string InstrumentUsed { get; set; }
        public int? TotalBcseats { get; set; }
        public int? TotalNbcseats { get; set; }
        public decimal? Ticketcharge { get; set; }
        public int? Numberofrows { get; set; }
        public string Meal { get; set; }
    }
}
