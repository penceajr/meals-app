using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meals_app.Models
{
    public class SearchMealByNameResultsModel
    {
        public string SearchedTerm { get; set; }

        public string MealDetails { get; set; }

        public List<MealApiEntryResponse> Results { get; set; } = new List<MealApiEntryResponse>();
    }
}
