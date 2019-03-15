using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Models;
using FoodFeedbackSystem.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FoodFeedbackTests
{
    public class AddFeedbackServiceTest
    {
        [Fact]
        public void AddFeedback_IfValid_ReturnsTrue()
        {
            var mockSet = new Mock<DbSet<Feedback>>();
            var mockContext = new Mock<FoodfeedbackDBContext>();
            mockContext.Setup(c => c.Feedback).Returns(mockSet.Object);
            var service = new AddFeedbackService(mockContext.Object);
            var response = service.AddFeedback(new AddFeedbackDTO()
            {
                SelectDate = new DateTime(2019, 02, 05),
                TypeOfMeal = "dinner",
                Rating = 3,
                Comments = "good",
                Email = "john89@cesltd.com"
            });
            Assert.True(response);
        }
    }
}