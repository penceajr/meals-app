using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meals_app.Models
{
    public class RandomMeal
    {
        public string RandomMealName { get; set; }

        public List<MealApiEntryResponse> Results { get; set; } = new List<MealApiEntryResponse>();
    }
}
