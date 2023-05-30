using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
    public interface IMealRepository
    {
        List<Meals> GetAllMeals();
        List<Meals> GetMealsByStyleCode(int styleCode);

        List<Meals> GetMealsByTimeCode(int timeCode);

        List<Meals> GetMealsByCategoryCode(int categoryCode);

        List<Meals> GetMealsWithPriceBetween(int minPrice, int maxPrice);

        Meals GetMealByName(string mealName);
        Meals GetMealByMealCode(int mealCode);

        decimal GetPriceByMealCode(int mealCode);
        List<Meals> GetAllMealsByCharacter(string characters, int categoryCode);
        Meals GetMealByMealName(string mealName);
    }
}
