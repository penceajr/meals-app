using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meals_app.Models
{
    public class SearchMealByLetterResultsModel
    {
        public string Letter { get; set; }

        public List<MealApiEntryResponse> Results { get; set; } = new List<MealApiEntryResponse>();
    }
}
