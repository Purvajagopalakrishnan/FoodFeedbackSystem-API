
using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Models;
using FoodFeedbackSystem.Services;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace FoodFeedbackTests
{
    public class ViewRatingServiceTest
    {
        [Fact]
        public void GetAverageRating_IfSameType()
        {
            var mockSet = new Mock<DbSet<Feedback>>();
            var mockContext = new Mock<FoodfeedbackDBContext>();
            mockContext.Setup(c => c.Feedback).Returns(mockSet.Object);
            var service = new ViewRatingService(mockContext.Object);
            var response = service.GetAverageRating(new ViewRatingDTO()
            {
                SelectDate = new DateTime(2019, 02, 28),
                TypeOfMeal = "Dinner"
            });
            Assert.IsAssignableFrom<double>(response);
        }
    }
}