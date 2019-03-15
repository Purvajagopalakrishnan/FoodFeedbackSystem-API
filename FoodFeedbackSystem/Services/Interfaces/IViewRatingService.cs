using FoodFeedbackSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFeedbackSystem.Services.Interfaces
{
    public interface IViewRatingService
    {
        double GetAverageRating(ViewRatingDTO viewratingDTO);
    }
}
