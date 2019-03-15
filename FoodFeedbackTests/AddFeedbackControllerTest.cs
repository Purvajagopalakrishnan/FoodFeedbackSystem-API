using FoodFeedbackSystem.Controllers;
using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace FoodFeedbackTests
{
    public class AddFeedbackControllerTest
    {
        [Fact]
        public void ShouldAddFeedback()
        {
            var mockAddFeedbackService = new Mock<IAddFeedbackService>();
            mockAddFeedbackService.Setup(details => details.AddFeedback(It.Is<AddFeedbackDTO>(x => x.SelectDate == new DateTime(2019, 02, 28) && x.TypeOfMeal == "Dinner" && x.Rating == 3 && x.Comments == "Good"))).Returns(true);
            var FeedbackDetails = new AddFeedbackController(mockAddFeedbackService.Object);
            var response = FeedbackDetails.AddFoodFeedback(new AddFeedbackDTO()
            {
                SelectDate = new DateTime(2019, 02, 28),
                TypeOfMeal = "Dinner",
                Rating = 3,
                Comments = "Good"
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
        [Fact]
        public void AddFeedback_IfFieldIsEmpty_ReturnsFalse()
        {
            var mockAddFeedbackService = new Mock<IAddFeedbackService>();
            mockAddFeedbackService.Setup(details => details.AddFeedback(It.Is<AddFeedbackDTO>(x => x.SelectDate == new DateTime() && x.TypeOfMeal == string.Empty && x.Rating == -1 && x.Comments == string.Empty))).Returns(false);
            var FeedbackDetails = new AddFeedbackController(mockAddFeedbackService.Object);
            var response = FeedbackDetails.AddFoodFeedback(new AddFeedbackDTO()
            {
                SelectDate = new DateTime(),
                TypeOfMeal = string.Empty,
                Rating = -1,
                Comments = string.Empty
            });
            Assert.Equal(400, ((BadRequestResult)response).StatusCode);
        }
        [Fact]
        public void AddFeedback_IfCommentsIsEmpty_ReturnsFalse()
        {
            var mockfeedbackservice = new Mock<IAddFeedbackService>();
            mockfeedbackservice.Setup(details => details.AddFeedback(It.Is<AddFeedbackDTO>(x => x.SelectDate == new DateTime(2019, 02, 28) && x.TypeOfMeal == "Dinner" && x.Rating == 3 && x.Comments == string.Empty))).Returns(false);
            var feedbackdetails = new AddFeedbackController(mockfeedbackservice.Object);
            var response = feedbackdetails.AddFoodFeedback(new AddFeedbackDTO()
            {
                SelectDate = new DateTime(2019, 02, 28),
                TypeOfMeal = "Dinner",
                Rating = 3,
                Comments = string.Empty
            });
            Assert.Equal(400, ((BadRequestResult)response).StatusCode);
        }
        [Fact]
        public void AddFeedback_IfSelectDateIsEmpty_ReturnsFalse()
        {
            var mockfeedbackservice = new Mock<IAddFeedbackService>();
            mockfeedbackservice.Setup(details => details.AddFeedback(It.Is<AddFeedbackDTO>(x => x.SelectDate == new DateTime() && x.TypeOfMeal == "Dinner" && x.Rating == 3 && x.Comments == "good"))).Returns(false);
            var feedbackdetails = new AddFeedbackController(mockfeedbackservice.Object);
            var response = feedbackdetails.AddFoodFeedback(new AddFeedbackDTO()
            {
                SelectDate = new DateTime(),
                TypeOfMeal = "Dinner",
                Rating = 3,
                Comments = "good"
            });
            Assert.Equal(400, ((BadRequestResult)response).StatusCode);
        }
        [Fact]
        public void AddFeedback_IfTypeOfMealIsEmpty_ReturnsFalse()
        {
            var mockfeedbackservice = new Mock<IAddFeedbackService>();
            mockfeedbackservice.Setup(details => details.AddFeedback(It.Is<AddFeedbackDTO>(x => x.SelectDate == new DateTime(2019, 02, 28) && x.TypeOfMeal == string.Empty && x.Rating == 3 && x.Comments == "good"))).Returns(false);
            var feedbackdetails = new AddFeedbackController(mockfeedbackservice.Object);
            var response = feedbackdetails.AddFoodFeedback(new AddFeedbackDTO()
            {
                SelectDate = new DateTime(2019, 02, 28),
                TypeOfMeal = string.Empty,
                Rating = 3,
                Comments = "good"
            });
            Assert.Equal(400, ((BadRequestResult)response).StatusCode);
        }
        [Fact]
        public void AddFeedback_IfRatingIsNotValid_ReturnsFalse()
        {
            var mockfeedbackservice = new Mock<IAddFeedbackService>();
            mockfeedbackservice.Setup(details => details.AddFeedback(It.Is<AddFeedbackDTO>(x => x.SelectDate == new DateTime(2019, 02, 28) && x.TypeOfMeal == "Dinner" && x.Rating == -1 && x.Comments == "good"))).Returns(false);
            var feedbackdetails = new AddFeedbackController(mockfeedbackservice.Object);
            var response = feedbackdetails.AddFoodFeedback(new AddFeedbackDTO()
            {
                SelectDate = new DateTime(2019, 02, 28),
                TypeOfMeal = "Dinner",
                Rating = -1,
                Comments = "good"
            });
            Assert.Equal(400, ((BadRequestResult)response).StatusCode);
        }
    }
}
