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
    public class MealCategoryController: ControllerBase
    {
        IMealCategoryService mealCategoryService;
        public MealCategoryController(IMealCategoryService mealCategoryService)
        {
            this.mealCategoryService = mealCategoryService;
        }
        [HttpGet("getAllCategories")]
        [EnableCors("CorsPolicy")]
        public List<MealCategory> GettAllCategories()
        {
            return mealCategoryService.GettAllCategories();
        }
    }
}
