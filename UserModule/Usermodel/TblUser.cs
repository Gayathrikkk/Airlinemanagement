using System;
using System.Collections.Generic;

namespace UserModule.Usermodel
{
    public partial class TblUser
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string EmailId { get; set; }
        public int NoOfSeats { get; set; }
        public string Pname { get; set; }
        public string Pgender { get; set; }
        public int Page { get; set; }
        public string OptVeg { get; set; }
        public string OptNonveg { get; set; }
        public string SelectedSeatNumber { get; set; }
        public string Pnrstatus { get; set; }
    }
}
