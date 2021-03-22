using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using meals_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace meals_app.Controllers
{
    public class MealByFirstLetterController : Controller
    {
        
        public IActionResult Index()
        {
            MealByFirstLetterModel Letters = new MealByFirstLetterModel();

            for (int i=65; i <= 90; i++)
            {
                LetterModel letter = new LetterModel
                {
                    Letter = ((char)i).ToString()
                };

                Letters.Letters.Add(letter);
            }

            return View(Letters);
        }
    }
}