using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodFeedbackSystem.Controllers
{
    [Route("api/addfeedback")]
    public class AddFeedbackController : Controller
    {
        private readonly IAddFeedbackService _addFeedbackService;
        public AddFeedbackController(IAddFeedbackService addFeedbackService)
        {
            _addFeedbackService = addFeedbackService;
        }
        [HttpPost]
        /// <summary>
        /// call the service and add feedback
        /// </summary>
        public IActionResult AddFoodFeedback([FromBody]AddFeedbackDTO addFeedbackDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _addFeedbackService.AddFeedback(addFeedbackDTO);
                    if (result == true)
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
        [HttpGet]
        public IActionResult GetFoodFeedback()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _addFeedbackService.GetFeedback();
                    return Ok(result);
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