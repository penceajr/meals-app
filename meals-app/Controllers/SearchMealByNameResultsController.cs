using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using meals_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace meals_app.Controllers
{
    public class SearchMealByNameResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MealDetails([Bind("MealName")]SearchMealByNameModel search)
        {
            // TODO: call API
            // get results

            SearchMealByNameResultsModel results = new SearchMealByNameResultsModel
            {
                SearchedTerm = search.MealName,
                MealDetails = search.MealName
            };

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

    }
}