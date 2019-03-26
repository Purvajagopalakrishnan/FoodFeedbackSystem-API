using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFeedbackSystem.DTO
{
    public class AuthDTO
    {
        public string email { get; set; }
        public bool isAdmin { get; set; }
        public string token { get; set; }
    }
}
