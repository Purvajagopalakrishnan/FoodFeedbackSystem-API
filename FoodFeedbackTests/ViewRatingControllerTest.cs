using FoodFeedbackSystem.Controllers;
using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FoodFeedbackTests
{
    public class ViewRatingControllerTest
    {
        [Fact]
        public void ShouldValidateOnEmpty()
        {
            var average = 2.17;
            var mockViewratingservice = new Mock<IViewRatingService>();
            mockViewratingservice.Setup(details => details.GetAverageRating(It.Is<ViewRatingDTO>(x => x.SelectDate == new DateTime() && x.TypeOfMeal == string.Empty))).Returns(average);
            var averagerating = new ViewRatingController(mockViewratingservice.Object);
            var response = averagerating.GetAverage(new ViewRatingDTO()
            {
                SelectDate = new DateTime(),
                TypeOfMeal = ""
            });
            Assert.Equal(400, ((BadRequestResult)response).StatusCode);
        }
    }
}