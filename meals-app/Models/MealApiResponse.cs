using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meals_app.Models
{
    public class MealApiResponse
    {
        [JsonProperty("meals")]
        public List<MealApiEntryResponse> Meals { get; set; } = new List<MealApiEntryResponse>();
    }
}
