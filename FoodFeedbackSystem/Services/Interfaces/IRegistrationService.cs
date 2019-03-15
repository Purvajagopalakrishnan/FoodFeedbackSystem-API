using FoodFeedbackSystem.DTO;

namespace FoodFeedbackSystem.Services.Interfaces
{
    public interface IRegistrationService
    {
        int RegisterUser(RegistrationDTO registrationDTO);
        bool CheckIfEmailAlreadyExists(RegistrationDTO registrationDTO);
        bool CheckIfEmployeeIdAlreadyExists(RegistrationDTO registrationDTO);
    }
}
