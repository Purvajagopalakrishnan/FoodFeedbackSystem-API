using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Models;
using FoodFeedbackSystem.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FoodFeedbackTests
{
    public class LoginServicetest
    {
        [Fact]
        public void CheckIfUserExists_IfExists_ReturnsTrue()
        {
            var mockSet = new Mock<DbSet<Users>>();
            var mockContext = new Mock<FoodfeedbackDBContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);
            var service = new Loginservice(mockContext.Object);
            var response = service.CheckIfUserExists(new UserDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.IsAssignableFrom<AdminDTO>(response);
        }
       
    }
}
