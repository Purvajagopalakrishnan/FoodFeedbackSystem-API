using FoodFeedbackSystem.Controllers;
using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace FoodFeedbackTests
{
    public class LoginControllerTest
    {
        [Fact]
        public void ShouldValidateOnEmpty()
        {
            var adminDTO = new AdminDTO();
            var mockLoginervice = new Mock<ILoginService>();
            var mockConfiguration = new Mock<IConfiguration>();
            mockLoginervice.Setup(details => details.CheckIfUserExists(It.Is<UserDTO>(x => x.Email == string.Empty))).Returns(adminDTO);
            var userlogindetails = new LoginController(mockConfiguration.Object, mockLoginervice.Object);
            var response = userlogindetails.GetUserdetails(new UserDTO()
            {
                Email = "john89@cesltd.com",
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
        [Theory]
        [InlineData("john89@cesltd.com", "welcome123")]
        [InlineData("john89@cesltd.com", "test")]
        public void GetUserDetails_IfPasswordIsInvalid_ReturnsFalse(string email, string password)
        {
            var adminDTO = new AdminDTO();
            var mockLoginervice = new Mock<ILoginService>();
            var mockConfiguration = new Mock<IConfiguration>();
            mockLoginervice.Setup(details => details.CheckIfUserExists(It.Is<UserDTO>(x => x.Email == email && x.Password == password))).Returns(adminDTO);
            var userlogindetails = new LoginController(mockConfiguration.Object, mockLoginervice.Object);
            var response = userlogindetails.GetUserdetails(new UserDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
        [Theory]
        [InlineData("test", "welcome")]
        [InlineData("welcome@cesltd.com", "welcome")]
        public void GetUserDetails_IfEmailIsInvalid_ReturnsFalse(string email, string password)
        {
            var adminDTO = new AdminDTO();
            var mockLoginervice = new Mock<ILoginService>();
            var mockConfiguration = new Mock<IConfiguration>();
            mockLoginervice.Setup(details => details.CheckIfUserExists(It.Is<UserDTO>(x => x.Email == email && x.Password == password))).Returns(adminDTO);
            var userlogindetails = new LoginController(mockConfiguration.Object, mockLoginervice.Object);
            var response = userlogindetails.GetUserdetails(new UserDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
        [Fact]
        public void ShouldReturnFalse_IfDataIsInvalid()
        {
            {
                var adminDTO = new AdminDTO();
                var mockLoginervice = new Mock<ILoginService>();
                var mockConfiguration = new Mock<IConfiguration>();
                mockLoginervice.Setup(details => details.CheckIfUserExists(It.Is<UserDTO>(x => x.Email == "john89@cesltd.com" && x.Password == "welcome"))).Returns(adminDTO);
                var userlogindetails = new LoginController(mockConfiguration.Object, mockLoginervice.Object);
                var response = userlogindetails.GetUserdetails(new UserDTO()
                {
                    Email = "test@cesltd.com",
                    Password = "test123"
                });
                Assert.Equal(200, ((OkObjectResult)response).StatusCode);
            }
        }
    }
}

