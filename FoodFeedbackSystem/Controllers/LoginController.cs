using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FoodFeedbackSystem.Controllers
{
    [Route("api/login")]
    /// <summary>
    /// provides login information
    /// </summary>
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginService _loginService;
        public LoginController(IConfiguration configuration,ILoginService loginService)
        {
            _configuration = configuration;
            _loginService = loginService;
        }
        [HttpPost]
        /// <summary>
        /// call the service and check if the user exists
        /// </summary>
        public IActionResult GetUserdetails([FromBody]UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _loginService.CheckIfUserExists(userDTO);
                    if (result != null)
                    {
                        var authDTO = new AuthDTO();
                        authDTO.email = userDTO.Email;
                        authDTO.isAdmin = result.IsAdmin;
                        authDTO.token = GenerateJwtToken();
                        return Ok(authDTO);
                    }
                    else
                    {
                        return Ok(result);
                    }
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
            return BadRequest();
        }

        private string GenerateJwtToken()
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[Constants.JWTSecretKey]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



            var jwtToken = new JwtSecurityToken(

                issuer: _configuration[Constants.JWTIssuer],

                audience: _configuration[Constants.JWTAudience],

                signingCredentials: credentials,

                expires: DateTime.Now.AddHours(1)

                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}