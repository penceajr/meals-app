using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using meals_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace meals_app.Controllers
{
    public class RandomMealController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // TODO: call API
            // get results

            RandomMeal results = new RandomMeal();

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://www.themealdb.com");
                HttpResponseMessage response = await httpClient.GetAsync("/api/json/v1/1/random.php");

                if (response.IsSuccessStatusCode)
                {
                    MealApiResponse mealResponse = await response.Content.ReadAsAsync<MealApiResponse>();
                    results.Results.AddRange(mealResponse.Meals);
                }
            }

            return View(results);
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