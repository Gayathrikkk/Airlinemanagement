using System;
using System.Collections.Generic;

namespace UserModule.Usermodel
{
    public partial class Register
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Phonenumber { get; set; }
    }
}
