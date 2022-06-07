using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserModule.Usermodel;

namespace UserModule
{
    public class Tokens
    {
        private Register userRegister;

        public Tokens(Register userRegister)
        {
            this.userRegister = userRegister;
        }

        public string token { get; set; }

        public DateTime TokenExpires { get; set; }
    }
}
