using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public async Task<IActionResult> SearchMealByLetter(string letter)
        {
            SearchMealByLetterResultsModel results = new SearchMealByLetterResultsModel();

            if (string.IsNullOrEmpty(letter))
            {
                letter = RouteData.Values["id"].ToString();
            }
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://www.themealdb.com");
                HttpResponseMessage response = await httpClient.GetAsync($"/api/json/v1/1/search.php?f={letter}");

                if (response.IsSuccessStatusCode)
                {
                    // _logger.LogInformation(await response.Content.ReadAsStringAsync());
                    MealApiResponse mealResponse = await response.Content.ReadAsAsync<MealApiResponse>();
                    if (mealResponse.Meals is null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    results.Results.AddRange(mealResponse.Meals);
                    return View(results);


                }
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://www.themealdb.com");
                HttpResponseMessage response = await httpClient.GetAsync($"/api/json/v1/1/lookup.php?i={id}");

                if (response.IsSuccessStatusCode)
                {
                    // _logger.LogInformation(await response.Content.ReadAsStringAsync());
                    MealApiResponse results = await response.Content.ReadAsAsync<MealApiResponse>();
                    if (results.Meals.Any())
                    {
                        return View(results.Meals.First());
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

    }
}