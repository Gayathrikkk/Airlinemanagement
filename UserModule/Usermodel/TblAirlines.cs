using System;
using System.Collections.Generic;

namespace UserModule.Usermodel
{
    public partial class TblAirlines
    {
        public int Flightnumber { get; set; }
        public string Flightname { get; set; }
        public string Place { get; set; }
        public DateTime Flighttime { get; set; }
        public string Flightlogo { get; set; }
        public string Sourse { get; set; }
        public string Destination { get; set; }
        public string Oneway { get; set; }
        public string Roundtrip { get; set; }
        public decimal OnewayPrice { get; set; }
        public decimal TwowayPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalTicketprice { get; set; }
    }
}
