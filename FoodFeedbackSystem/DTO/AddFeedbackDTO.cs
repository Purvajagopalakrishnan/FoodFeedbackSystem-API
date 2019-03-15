using System;
using System.ComponentModel.DataAnnotations;

namespace FoodFeedbackSystem.DTO
{
    public class AddFeedbackDTO
    {
        [Required]
        public DateTime SelectDate { get; set; }
        [Required]
        public string TypeOfMeal { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Comments { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
