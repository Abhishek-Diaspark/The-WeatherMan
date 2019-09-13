using WeatherAppApi.Models;
using WeatherAppApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;

namespace WeatherAppApi.Controllers
{

    [ApiController]
    public class WeatherAppUserController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherAppUserController(WeatherService weatherservice)
        {
            _weatherService = weatherservice;
        }

        /// <summary>
        ///Get Detail Of All Users.
        /// </summary> 
        [HttpGet, Route("AllUser")]
        // [Authorize]
        public ActionResult<List<WeatherAppUser>> Get()
        {
            // Console.WriteLine("Hi");
            // Console.WriteLine(c.Type);
            //  string userId = User.Claims.FirstOrDefault(c => c.Type == "Email").Value;
            // Console.WriteLine("hellow"+userId);

            return _weatherService.Get();
        }

        [HttpGet("{Email}")]
        public ActionResult<WeatherAppUser> GetUserByEmail(string Email)
        {
            Console.WriteLine(Email);
            var weatherappuser = _weatherService.Get(Email);

            if (weatherappuser == null)
            {
                return NotFound();
            }

            return weatherappuser;
        }

        //[HttpPost, Route("register")]
        //public ActionResult CreateUser(LoginResponse login)
        //{
        //    string Token = "";
        //    var weatherappuser1 = _weatherService.Get(login.username);
        //    //  Console.WriteLine("After Check"+login.Email);
        //    if (weatherappuser1 == null)
        //    {
        //        //  if(IsValidEmail(login.Email))
        //        // {  
        //        // MailMessage mail = new MailMessage();
        //        // SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

        //        // mail.From = new MailAddress("abhishek.anandjpr@gmail.com");
        //        // mail.To.Add(login.Email);
        //        // mail.Subject = "Signup Confirmation from The WeatherMan App";
        //        // mail.Body = "This is for testing SMTP mail from GMAIL";

        //        // SmtpServer.Port = 587;
        //        // SmtpServer.Credentials = new System.Net.NetworkCredential("abhishek.anandjpr@gmail.com", "ABhi0912");
        //        // SmtpServer.EnableSsl = true;
        //        // SmtpServer.Send(mail);

        //        // Console.WriteLine("mail Send");

        //        _weatherService.CreateUser(login);
        //        AuthController obj = new AuthController();
        //        Token = obj.Login(login.username);
        //        return Ok(new
        //        {
        //            // Email = login.Email,
        //            // FirstName=login.FirstName,
        //            // LastName=login.LastName,
        //            // Token = Token
        //            username = login.username
        //        });
        //        //  }
        //        // else
        //        // {
        //        //     return BadRequest(new { message = "Email Does not Exists please tru with different Email" });
        //        // }
        //    }
        //    else
        //    {
        //        WeatherAppUser weatherappuserexists = new WeatherAppUser();
        //        return BadRequest(new { message = "UserName Already Exists" });

        //    }

        //    // return weatherappuser;
        //}

        [HttpPost, Route("login")]
        public ActionResult CreateLogin(LoginResponse login)
        {

            string Token = "";
            Console.WriteLine(login.username);
            var weatherappuser1 = _weatherService.GetByName(login.username);
            Console.WriteLine(login.password);
            var weatherappuser2 = _weatherService.GetByName1(login.password);
            if ((weatherappuser1 == null || weatherappuser2 == null))
            {
                Console.WriteLine("Already Exists");
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            else
            {

                AuthController obj = new AuthController();
                Token = obj.Login(login.username);
            }

            JObject obj1 = new JObject();
            obj1.Add("token", Token);
            obj1.Add("userId", weatherappuser1.username);
            Response response = new Response();
            response.status = "OK";
            response.payload = obj1;            
            return Ok(response);

        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost, Route("authenticate")]
        public ActionResult AuthUser(LoginResponse login)
        {
            string Token = "";
            Console.WriteLine(login.username);
            AuthController obj = new AuthController();
            Token = obj.Login(login.username);
            JObject obj1 = new JObject();
            obj1.Add("userId", 1);
            obj1.Add("token", Token);

            Response response = new Response();
            response.status = "OK";
            response.payload = obj1;
            return Ok(response);
        }
        
        [HttpPost, Route("register")]
        public ActionResult Register(LoginResponse login)
        {
            string Token = "";
            Console.WriteLine(login.username);
            AuthController obj = new AuthController();
            Token = obj.Login(login.username);
            JObject obj1 = new JObject();
            obj1.Add("id", 1);
            obj1.Add("username", login.username);

            Response response = new Response();
            response.status = "OK";
            response.payload = obj1;
            return Ok(response);
        }


        // [AllowAnonymous]

        // [HttpPut("{Email}")]
        // public IActionResult Update(string Email, WeatherAppUser weatherappuserIn)
        // {
        //     var weatherappuser = _weatherService.Get(Email);

        //     if (weatherappuser == null)
        //     {
        //         return NotFound();
        //     }

        //     _weatherService.Update(Email, weatherappuserIn);

        //     return NoContent();
        // }

        // [HttpDelete("{Email:length(24)}")]
        // public IActionResult Delete(string Email)
        // {
        //     var weatherappuser = _weatherService.Get(Email);

        //     if (weatherappuser == null)
        //     {
        //         return NotFound();
        //     }

        //     _weatherService.Remove(weatherappuser.Email);

        //     return NoContent();
        // }     

        //  [HttpPost]
        // [Route("Login1")]
        // //POST : /api/ApplicationUser/Login
        // public async Task<IActionResult> Login(LoginResponse login)
        // {
        //     // var key = Encoding.UTF8.GetBytes("1234567891234567");
        //    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567891234567")); 
        //      var weatherappuser1 = _weatherService.GetByName(login.Email);
        //     if (weatherappuser1 != null )
        //     {
        //         var tokenDescriptor = new SecurityTokenDescriptor
        //         {
        //             Subject = new ClaimsIdentity(new Claim[]
        //             {
        //                 new Claim("Email",weatherappuser1.Email.ToString())

        //             }),
        //             Expires = DateTime.UtcNow.AddMinutes(5),
        //              SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
        //         };
        //         var tokenHandler = new JwtSecurityTokenHandler();
        //         var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //         var token = tokenHandler.WriteToken(securityToken);
        //        // string userId = User.Claims.First(c => c.Type == "UserID").Value;
        //        // Console.WriteLine("Hi"+userId);
        //         return Ok(new { token });
        //     }
        //     else
        //         return BadRequest(new { message = "Username or password is incorrect." });
        // }

        // [HttpGet]
        // [Authorize]
        // //GET : /api/UserProfile
        // public string GetUserProfile() {
        //     Console.WriteLine("Hi");
        //     string userId = User.Claims.First(c => c.Type == "UserID").Value;
        //     Console.WriteLine("Hi"+userId);
        //    // var user = await _userManager.FindByIdAsync(userId);
        //    // return new
        //    // {
        //      //    user.FullName,
        //     //     user.Email,
        //     //     user.UserName
        //    // };
        //    return "Abhi";
        // }

    }
}