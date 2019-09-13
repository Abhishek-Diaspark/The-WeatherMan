using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WeatherAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AuthController : ControllerBase
    {
        public string Login(string username)
        {
            //By passing login authentication for time being database is not up and running.
            //Please provide your custom login for login and register user.
            var now = DateTime.UtcNow;
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token_Handler = new JwtSecurityTokenHandler();
            var securitytokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                            new Claim("UserID", username)
                    }),

                Expires = now.AddDays(Convert.ToInt32(1)),                
                SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            };

            var tokeOptions = new JwtSecurityToken(
          // issuer: "http://localhost:5000",  
          // audience: "http://localhost:5000",  
        
          );
            var stoken = token_Handler.CreateToken(securitytokenDescriptor);

            var token = token_Handler.WriteToken(stoken);

    

            return token;
    

        }
    }
}