using System.ComponentModel.DataAnnotations;

namespace FoodFeedbackSystem.DTO
{
    public class RegistrationDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_.+-]+@(cesltd).com$")]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        public string EmpId { get; set; }
    }
}
