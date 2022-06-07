using AdminModule.Models;
using AdminModule.Usermodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        // GET: api/<LoginController>

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [Route("admincreds")]
        [HttpGet]
        public IEnumerable<AdminCredentials> Get()
        {
            using (var context = new AdminDBContext())
            {
                return context.AdminCredentials.ToList();
            }
        }


        [Route("AdminLogin")]
        [HttpPost]
        public IActionResult LoginAdmin([FromBody] AdminCredentials credentialsObj)
        {


            if (credentialsObj == null)
                return BadRequest();
            else
            {
                var db = new AdminDBContext();
                var admin = db.AdminCredentials.Where(a =>
                    a.Ausername == credentialsObj.Ausername
                    && a.Apassword == credentialsObj.Apassword).FirstOrDefault();

                if (admin != null)
                {
                    var token = LoginUsingJwt(credentialsObj.Ausername);

                    return Ok(new
                    {
                        success = 1,
                        message = "Logged In Successfully",
                        token = token
                    });
                }
                else
                {
                    var dbs = new FlightsContext();
                    var user = dbs.Register.Where(a =>
                        a.Email == credentialsObj.Ausername
                        && a.Password == credentialsObj.Apassword).FirstOrDefault(); var token = LoginUsingJwt(credentialsObj.Ausername);
                    if (user != null)
                    {
                        return Ok(new
                        {
                            success = 2,
                            message = "Logged In Successfully",
                            token = token,
                            email = user.Email
                        }) ;
                    }
                    else
                    
                        return BadRequest();
                    
                }

            }
        }
        public string LoginUsingJwt(string userName)
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

    }
}
