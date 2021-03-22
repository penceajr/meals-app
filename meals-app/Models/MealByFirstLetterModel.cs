using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meals_app.Models
{
    public class MealByFirstLetterModel
    {
        public char FirstChar { get; set; }

        public char LastChar { get; set; }

        public List<LetterModel> Letters { get; set; } = new List<LetterModel>();

    }
}
