using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFeedbackSystem.DTO
{
    public class ViewFeedbackDTO
    {
        public DateTime SelectDate { get; set; }
        public string TypeOfMeal { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public string Email { get; set; }
    }
}
