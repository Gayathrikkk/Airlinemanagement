using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserModule.Usermodel;

namespace UserModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Useractions : ControllerBase
    {

        [Route("Alluserdetails")]
        [HttpGet]
        public IEnumerable<TblUser> Get()
        {
            using (var context = new FlightsContext())
            {
                return context.TblUser.ToList();
            }
        }

    }
}
