﻿using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFeedbackSystem.Services.Interfaces
{
    public interface ILoginService
    {
        int CheckIfUserExists(UserDTO userDTO);
        int CheckIfUserIsAdmin(string email);
    }
}
