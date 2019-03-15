using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFeedbackSystem.DTO
{
    public class ViewRatingDTO
    {
        [Required]
        public DateTime SelectDate { get; set; }
        [Required]
        public string TypeOfMeal { get; set; }
    }
}
