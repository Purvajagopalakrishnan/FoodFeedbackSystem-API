﻿using FoodFeedbackSystem.DTO;
using FoodFeedbackSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFeedbackSystem.Services.Interfaces
{
    public interface IAddFeedbackService
    {
        bool AddFeedback(AddFeedbackDTO addFeedbackDTO);
        List<Feedback> GetFeedback();
    }
}
