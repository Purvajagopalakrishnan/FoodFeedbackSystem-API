using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Models;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodFeedbackSystem.Services
{
    public class Loginservice : ILoginService
    {
        private readonly FoodfeedbackDBContext _foodfeedbackDBContext;
        public Loginservice(FoodfeedbackDBContext foodfeedbackDBContext)
        {
            _foodfeedbackDBContext = foodfeedbackDBContext;
        }
        /// <summary>
        /// checks if the given user exist or not
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>
        /// true if user exists
        /// false if user does not exist
        /// </returns>
        public int CheckIfUserExists([FromBody]UserDTO userDTO)
        {
            var entities = new FoodfeedbackDBContext();
            int UserResult;
            var loginresult = entities.Users.Where(x => x.Email == userDTO.Email && x.Password == userDTO.Password).FirstOrDefault();
            if(loginresult != null)
            {
                UserResult = CheckIfUserIsAdmin(userDTO.Email);
            }
            else
            {
                UserResult = 2;
            }
            
            return UserResult;
        }
        public int CheckIfUserIsAdmin(string email)
        {
            var entities = new FoodfeedbackDBContext();
            var CheckAdminUserResult = entities.Users.Where(x => x.Email == email).Select(r => r.IsAdmin).FirstOrDefault();
            if(CheckAdminUserResult == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
