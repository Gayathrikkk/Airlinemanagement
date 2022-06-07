using System;
using System.Collections.Generic;

namespace AdminModule.Models
{
    public partial class AirlineaddBlock
    {
        public int Id { get; set; }
        public string AirlineId { get; set; }
        public string Airlinename { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? BlockedDate { get; set; }
        public string Status { get; set; }
    }
}
