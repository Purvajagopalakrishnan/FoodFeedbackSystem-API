using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodFeedbackSystem.Controllers
{
    [Route("api/viewrating")]
    /// <summary>
    /// provides login information
    /// </summary>
    public class ViewRatingController : Controller
    {
        private readonly IViewRatingService _viewRatingService;
        public ViewRatingController(IViewRatingService viewRatingService)
        {
            _viewRatingService = viewRatingService;
        }
        [HttpPost]
        /// <summary>
        /// call the service and check if the user exists
        /// </summary>
        public IActionResult GetAverage([FromBody]ViewRatingDTO viewratingDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _viewRatingService.GetAverageRating(viewratingDTO);
                    if (result != 0)
                    {
                        return Ok(result);
                    }
                    else 
                    {
                        return BadRequest(result);
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