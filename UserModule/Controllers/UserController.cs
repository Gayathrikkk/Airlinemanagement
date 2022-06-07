using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using UserModule.Usermodel;

namespace UserModule.Controllers
{
  
    [Route("api/[controller]")]
   // [Authorize]
    public class UserController : ControllerBase
    {
              
        [HttpPost]
        [Route("UserRegistration")]
        public IActionResult Registeruser([FromBody] Register userRegister)
        {
            using (FlightsContext fc = new FlightsContext())
            {
                fc.Register.Add(userRegister);
                fc.SaveChanges();
            }
            return Ok(new { success = 1 });
        }


        //[Route("Api/Login/UserLogin")]
        //[HttpPost]
        //public Register Login(Register rg)
        //{
        //    using(FlightsContext fc= new FlightsContext()) {
        //    var Obj = fc.Register;

        //    }
        //}
        [Route("UserLogin")]
        [HttpPost]
        public IActionResult LoginUser([FromBody] Register objregister)
        {
            if (objregister == null)
                return BadRequest();
            else
            {
                var db = new FlightsContext();
                var admin = db.Register.Where(a =>
                    a.Username == objregister.Username
                    && a.Password == objregister.Password).FirstOrDefault();
                if (admin != null)
                {
                    var token = LoginUsingJwt_user(objregister.Username);

                    return Ok(new
                    {
                        success = 1,
                        message = "Logged In Successfully",
                        token = token
                    });
                }
                else
                    return BadRequest();
            }
        }
        public string LoginUsingJwt_user(string userName)
        {
            var signinngKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BA7816BF8F01CFEA414140DE5DAE2223B00361A396177A9CB410FF61F20015AD"));
            var signingCredentials = new SigningCredentials(signinngKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, userName)
            }; var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }



        //[Authorize]
        [HttpPost]
        [Route("Ticketbook")]
        public int BookingTicket([FromBody] TicketBooking ticket)
        {
            int Result;
            using (FlightsContext fc = new FlightsContext())
            {
                Random rmd = new Random();                
                int PNR = rmd.Next(00000, 99999);
                Console.WriteLine("Your ticket booked successfully PNR is:" + PNR);
                Result = PNR;
                ticket.Pnrnumber = Result;
                fc.TicketBooking.Add(ticket);
                fc.SaveChanges();
            }
            
            return Result;
        }


        [Route("Alluserdetails")]
        [HttpGet]
        public IEnumerable<TblUser> Get()
        {
            using (var context = new FlightsContext())
            {
                return context.TblUser.ToList();
            }
        }


        //[Route("Getusercreds")]
        //[HttpGet]
        //public IEnumerable<Register> Getusercred()
        //{
        //    using (var context = new FlightsContext())
        //    {
        //        return context.Register.ToList();
        //    }
        //}


        [HttpGet]
        [Route("GetBookinghistory")]
        public IEnumerable<TicketBooking> Gettickethistory(string Email)
        {
            using (FlightsContext context = new FlightsContext())
            {
                return context.TicketBooking.Where(a => a.PassengerEmail == Email).ToList();

            }
        }

        [HttpGet]
        [Route("GetBookingdetails")]
        public TicketBooking Getticketdetails(int Pnrnumber)
        {
            using (FlightsContext context = new FlightsContext())
            {
                return context.TicketBooking.Where(TicketBooking => TicketBooking.Pnrnumber == Pnrnumber).FirstOrDefault();
            }
        }

        [HttpDelete]
        [Route("CancelTicket")]
        public IActionResult Ticket_cancel(int Pnrnumber)
        {
            using (FlightsContext context = new FlightsContext())
            {
                var aid = context.TicketBooking.Find(Pnrnumber);
                context.TicketBooking.Remove(aid);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet]
        [Route("Getuser")]
        public TblUser Getuser(int Userid)
        {
            using (FlightsContext context = new FlightsContext())
            {
                return context.TblUser.Where(TblUser => TblUser.Userid == Userid).FirstOrDefault();
            }
        }

        //[HttpGet]
        //[Route("Getairlines")]

        //public IEnumerable<TblAirlines> Getairlines()
        //{
        //    using (var context = new FlightsContext())
        //    {
        //        return context.TblAirlines.ToList();
        //    }
        //}

        [HttpGet]
        [Route("SearchSourceDestination")]
        public IList<TblAirlines> SearchSourceDestination(string Source, string Destination)
        {
            using (FlightsContext fc = new FlightsContext())
            {
               return  fc.TblAirlines.Where(m => m.Sourse == Source && m.Destination == Destination).ToList();
            }
        }

        [HttpGet]
        [Route("Onewayroundtrip")]
        public IList<TblAirlines> Onewayroundtrip(string Oneway, string roundtrip)
        {
            using (FlightsContext fc = new FlightsContext())
            {
                return fc.TblAirlines.Where(m => m.Oneway == Oneway && m.Roundtrip == roundtrip).ToList();
            }
        }

        [HttpGet]
        [Route("Datetimesearch")]
        public IList<TblAirlines> Datetimesearch(DateTime date)
        {
            //TblAirlines tbl = new TblAirlines();
            using (FlightsContext fc = new FlightsContext())
            {
                return fc.TblAirlines.Where(m => m.Flighttime == date).ToList();
            }
        }

    }
}
