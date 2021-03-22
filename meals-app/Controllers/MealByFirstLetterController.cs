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

            List<string> tempList = new List<string>();

            MealByFirstLetterModel Letters = new MealByFirstLetterModel
            {
                FirstChar = 'A',
                LastChar = 'Z'
            };

            for (; Letters.FirstChar <= Letters.LastChar; Letters.FirstChar++)
            {
                tempList.Add(Letters.FirstChar.ToString());
            }

            Letters.Letters.AddRange(tempList);

            return View(Letters.Letters);
        }
    }
}