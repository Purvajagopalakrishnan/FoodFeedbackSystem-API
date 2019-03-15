using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Models;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FoodFeedbackSystem.Services
{
    public class AddFeedbackService : IAddFeedbackService
    {
        private readonly FoodfeedbackDBContext _foodfeedbackDBContext;
        public AddFeedbackService(FoodfeedbackDBContext foodfeedbackDBContext)
        {
            _foodfeedbackDBContext = foodfeedbackDBContext;
        }
        public bool AddFeedback([FromBody]AddFeedbackDTO addFeedbackDTO)
        {
            var entities = new FoodfeedbackDBContext();
            var FeedbackDetails = new Feedback()
            {
                SelectDate = addFeedbackDTO.SelectDate,
                TypeOfMeal = addFeedbackDTO.TypeOfMeal,
                Rating = addFeedbackDTO.Rating,
                Comments = addFeedbackDTO.Comments,
                Email = addFeedbackDTO.Email
            };
            entities.Feedback.Add(FeedbackDetails);
            entities.SaveChanges();
            return true;
        }
        public List<Feedback> GetFeedback()
        {
            var entities = new FoodfeedbackDBContext();
            var feedback = entities.Feedback.ToList();
            return feedback;
        }
    }
}
