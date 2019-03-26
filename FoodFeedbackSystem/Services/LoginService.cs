using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Models;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
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
        /// <param name="adminDTO"></param>
        /// <returns>
        /// true if user exists
        /// false if user does not exist
        /// </returns>
        public bool CheckIfUserIsAdmin(string email)
        {
            var entities = new FoodfeedbackDBContext();
            var CheckAdminUserResult = entities.Users.Where(x => x.Email == email && x.IsAdmin == 1).Any();
            if (CheckAdminUserResult == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public AdminDTO CheckIfUserExists([FromBody]UserDTO userDTO)
        {
            var entities = new FoodfeedbackDBContext();
            bool UserResult;
            var loginresult = entities.Users.Where(x => x.Email == userDTO.Email && x.Password == userDTO.Password).Any();
            if (loginresult == true)
            {
                UserResult = CheckIfUserIsAdmin(userDTO.Email);
                var adminDTO = new AdminDTO();
                adminDTO.Email = userDTO.Email;
                adminDTO.IsAdmin = UserResult;
                return adminDTO;
            }
            else
            {
                return null;
            }
        }
    }
}
