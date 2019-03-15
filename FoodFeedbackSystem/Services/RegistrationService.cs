using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Models;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFeedbackSystem.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly FoodfeedbackDBContext _foodfeedbackDBContext;
        public RegistrationService(FoodfeedbackDBContext foodfeedbackDBContext)
        {
            _foodfeedbackDBContext = foodfeedbackDBContext;
        }
        /// <summary>
        /// Register the user details
        /// </summary>
        /// <param name="registrationDTO"></param>
        /// <returns>
        /// true if user register
        /// </returns>
        public int RegisterUser([FromBody]RegistrationDTO registrationDTO)
        {
            //string exists = "";
            var entities = new FoodfeedbackDBContext();

            var RegisteredUserDetails = new Users()
            {
                Email = registrationDTO.Email,
                Password = registrationDTO.Password,
                EmpId = registrationDTO.EmpId,
                Username = registrationDTO.Username,
            };
            var UserExists = CheckIfEmailAlreadyExists(registrationDTO);
            var EmployeeIdExists = CheckIfEmployeeIdAlreadyExists(registrationDTO);
            if(UserExists == true)
            {
                return 2;
            }
            else if(EmployeeIdExists == true)
            {
                return 0;
            }
            else
            {
                entities.Users.Add(RegisteredUserDetails);
                entities.SaveChanges();
                return 1;
            }
        }
        public bool CheckIfEmailAlreadyExists(RegistrationDTO registrationDTO)
        {
            var entities = new FoodfeedbackDBContext();
            var CheckEmailIdresult = entities.Users.Where(x => x.Email == registrationDTO.Email).Any();
            return CheckEmailIdresult;
        }
        public bool CheckIfEmployeeIdAlreadyExists(RegistrationDTO registrationDTO)
        {
            var entities = new FoodfeedbackDBContext();
            var CheckEmployeeIdresult = entities.Users.Where(x => x.EmpId == registrationDTO.EmpId).Any();
            return CheckEmployeeIdresult;
        }
    }
}

