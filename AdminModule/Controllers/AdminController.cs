using AdminModule.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminModule.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
   // [EnableCors]
    public class AdminController : ControllerBase
    {

        // GET: api/<AdminController>
        [HttpGet]
        [Route("Getadmincreds")]
        public IEnumerable<AdminCredentials> GetAdmincreds()
        {
            using (var context = new AdminDBContext())
            {
                return context.AdminCredentials.ToList();
            }
        }

        [HttpGet]
        [Route("getairline")]
        public IEnumerable<AirlineaddBlock> Getairline()
        {
            using (AdminDBContext context = new AdminDBContext())
            {
                return context.AirlineaddBlock.ToList();
            }
        }


        [HttpGet]
        [Route("getscheduleairline")]
        public IEnumerable<AirlineSchedule> getschedule()
        {
            using (AdminDBContext context = new AdminDBContext())
            {
                return context.AirlineSchedule.ToList();
            }
        }

        // POST api/<AdminController>
        [HttpPost]
        [Route("Addairline")]
        public IActionResult Addairline([FromBody] AirlineaddBlock airlineaddBlock)
        {
            using (AdminDBContext context = new AdminDBContext())
            {
                airlineaddBlock.AddDate = System.DateTime.Now;
                airlineaddBlock.BlockedDate = Convert.ToDateTime("1900-01-01 00:00:00.000");
                airlineaddBlock.Status = "Active";
                context.AirlineaddBlock.Add(airlineaddBlock);
                 context.SaveChanges();
                return Ok(new {success=1});
            }
        }

        [HttpPost]
        [Route("Scheduleairline")]
        public IActionResult scheduleairline([FromBody] AirlineSchedule airlineschedule)
        {
            using (AdminDBContext context = new AdminDBContext())
            {
                context.AirlineSchedule.Add(airlineschedule);
                 context.SaveChanges();
                return Ok(new { success = 1 });
            }
        }

        [HttpPut]
        [Route("blockairline")]
        public IActionResult Airline_Block(AirlineaddBlock objairline)
        {          
            using (AdminDBContext context = new AdminDBContext())
            {
                var aid = context.AirlineaddBlock.Where(s=>s.AirlineId==objairline.AirlineId && s.Status=="Active");
                if (aid != null)
                {
                    objairline.Status = "Inactive";                    
                }
                context.SaveChanges();
                return Ok();
            }
        }

    }
}

