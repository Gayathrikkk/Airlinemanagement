using System;
using System.Collections.Generic;

namespace AdminModule.Usermodel
{
    public partial class TicketBooking
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Bookingdate { get; set; }
        public int? Flightnumber { get; set; }
        public string PassengerEmail { get; set; }
        public string PassengerName { get; set; }
        public int? Numberofseats { get; set; }
        public string Optformeal { get; set; }
        public string Seatnumbers { get; set; }
        public int? Pnrnumber { get; set; }
    }
}
