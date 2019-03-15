using System;
using System.Collections.Generic;

namespace FoodFeedbackSystem.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmpId { get; set; }
        public int IsAdmin { get; set; }
    }
}
