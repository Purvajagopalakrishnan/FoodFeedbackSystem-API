using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Models;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FoodFeedbackSystem.Services
{
    public class ViewRatingService : IViewRatingService
    {
        private readonly FoodfeedbackDBContext _foodfeedbackDBContext;
        public ViewRatingService(FoodfeedbackDBContext foodfeedbackDBContext)
        {
            _foodfeedbackDBContext = foodfeedbackDBContext;
        }
        /// <summary>
        /// Check the rating and calculate average rating
        /// </summary>
        /// <param name="viewratingDTO"></param>
        /// <returns>
        /// average rating value
        /// </returns>
        public double GetAverageRating([FromBody]ViewRatingDTO viewratingDTO)
        {
            var entities = new FoodfeedbackDBContext();
            var viewratingresult = entities.Feedback.Where(r => r.SelectDate == viewratingDTO.SelectDate && r.TypeOfMeal == viewratingDTO.TypeOfMeal)
            .GroupBy(g => g.TypeOfMeal, r => r.Rating)
                .Select(g => new ResponseDTO()
                {
                    Average_Rating = g.Average()

                }).FirstOrDefault();
            if(viewratingresult == null)
            {
                return 0;
            }
            else
            {
                var average = Convert.ToDouble(viewratingresult.Average_Rating);
                return average;

            }
        }
    }
}
