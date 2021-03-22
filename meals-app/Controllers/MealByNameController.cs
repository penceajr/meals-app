using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using meals_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace meals_app.Controllers
{
    public class MealByNameController : Controller
    {
        private readonly ILogger<MealByNameController> _logger;

        public MealByNameController(ILogger<MealByNameController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchByName([Bind("MealName")]SearchMealByNameModel search)
        {
            // TODO: call API
            // get results

            SearchMealByNameResultsModel results = new SearchMealByNameResultsModel();
            results.SearchedTerm = search.MealName;
            results.MealDetails = search.MealName;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://www.themealdb.com");
                HttpResponseMessage response = await httpClient.GetAsync($"/api/json/v1/1/search.php?s={search.MealName}");

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