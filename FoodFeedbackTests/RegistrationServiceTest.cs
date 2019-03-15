using FoodFeedbackSystem.Controllers;
using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Models;
using FoodFeedbackSystem.Services;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace FoodFeedbackTests
{
    public class RegistrationServiceTest
    {
        [Fact]
        public void RegisterUser_IfValid_ReturnsTrue()
        {
            var mockSet = new Mock<DbSet<Users>>();
            var mockContext = new Mock<FoodfeedbackDBContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);
            var service = new RegistrationService(mockContext.Object);
            var response = service.RegisterUser(new RegistrationDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome",
                Username = "John",
                EmpId = "CES/100"
            });
            Assert.IsAssignableFrom<int>(response);
        }
        [Fact]
        public void RegisterUser_IfUsernameIsEmpty_ReturnsInvalid()
        {
            var mockLoginervice = new Mock<IRegistrationService>();
            mockLoginervice.Setup(details => details.RegisterUser(It.Is<RegistrationDTO>(x => x.Email == "john89@cesltd.com" && x.Password == "test" && x.EmpId == "CES/100" && x.Username == string.Empty))).Returns(0);
            var UserRegistrationDetails = new RegistrationController(mockLoginervice.Object);
            var response = UserRegistrationDetails.RegisterUserDetails(new RegistrationDTO()
            {
                Email = "john89@cesltd.com",
                Password = "test",
                EmpId = "CES/100",
                Username = ""
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
        [Fact]
        public void RegisterUser_IfEmailIsEmpty_ReturnsInvalid()
        {
            var mockLoginervice = new Mock<IRegistrationService>();
            mockLoginervice.Setup(details => details.RegisterUser(It.Is<RegistrationDTO>(x => x.Email == string.Empty && x.Password == "test" && x.EmpId == "CES/100" && x.Username == "john"))).Returns(0);
            var UserRegistrationDetails = new RegistrationController(mockLoginervice.Object);
            var response = UserRegistrationDetails.RegisterUserDetails(new RegistrationDTO()
            {
                Email = "",
                Password = "test",
                EmpId = "CES/100",
                Username = "john"
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
        [Fact]
        public void RegisterUser_IfPasswordIsEmpty_ReturnsInvalid()
        {
            var mockLoginervice = new Mock<IRegistrationService>();
            mockLoginervice.Setup(details => details.RegisterUser(It.Is<RegistrationDTO>(x => x.Email == "john89@cesltd.com" && x.Password == string.Empty && x.EmpId == "CES/100" && x.Username == "john"))).Returns(0);
            var UserRegistrationDetails = new RegistrationController(mockLoginervice.Object);
            var response = UserRegistrationDetails.RegisterUserDetails(new RegistrationDTO()
            {
                Email = "john89@cesltd.com",
                Password = string.Empty,
                EmpId = "CES/100",
                Username = "john"
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
        [Fact]
        public void RegisterUser_IfEmployeeIDIsEmpty_ReturnsInvalid()
        {
            var mockLoginervice = new Mock<IRegistrationService>();
            mockLoginervice.Setup(details => details.RegisterUser(It.Is<RegistrationDTO>(x => x.Email == "john89@cesltd.com" && x.Password == "welcome" && x.EmpId == string.Empty && x.Username == "john"))).Returns(0);
            var UserRegistrationDetails = new RegistrationController(mockLoginervice.Object);
            var response = UserRegistrationDetails.RegisterUserDetails(new RegistrationDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome",
                EmpId = string.Empty,
                Username = "john"
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
    }
}

