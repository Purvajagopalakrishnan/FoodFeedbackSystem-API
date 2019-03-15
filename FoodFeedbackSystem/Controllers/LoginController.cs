using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodFeedbackSystem.Controllers
{
    [Route("api/login")]
    /// <summary>
    /// provides login information
    /// </summary>
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
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
                    if (result == 1)
                    {
                        return Ok(result);
                    }
                    else if(result == 0)
                    {
                        return Ok(result);
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
    }
}