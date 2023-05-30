using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using ServiceBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        IMealService mealService;
        public MealController(IMealService mealService)
        {
            this.mealService = mealService;
        }

        [HttpGet("getAllMeals")]
        [EnableCors("CorsPolicy")]
        public List<Meals> GetAllMeals()
        {
            return mealService.GetAllMeals();
        }

        [HttpGet("getMealListByCategory/{categoryCode}")]
        [EnableCors("CorsPolicy")]
        public List<Meals> GetMealsByCategoryCode(int categoryCode)
        {
            return mealService.GetMealsByCategoryCode(categoryCode);
        }
        [HttpGet("getPriceByMealCode/{mealCode}")]
        [EnableCors("CorsPolicy")]

        public decimal GetPriceByMealCode(int mealCode)
        {
            return mealService.GetPriceByMealCode(mealCode);
        }
        [HttpGet("getAllMealsByCharacter/{cahracters}/{mealCategory}")]
        [EnableCors("CorsPolicy")]

        public List<Meals> GetAllMealsByCharacter(string cahracters, int mealCategory)
        {
            return mealService.GetAllMealsByCharacter(cahracters, mealCategory);
        }

        [HttpGet("getMealByMealCode/{mealCode}")]
        [EnableCors("CorsPolicy")]
        public Meals GetMealByMealCode(int mealCode)
        {
            return mealService.GetMealByMealCode(mealCode);
        }

        [HttpGet("getMealByMealName/{mealName}")]
        [EnableCors("CorsPolicy")]
        public Meals GetMealByMealName(string mealName)
        {
            return mealService.GetMealByMealName(mealName);
        }
    }
}
