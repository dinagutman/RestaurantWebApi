using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Repositories
{
    public class MealRepository : IMealRepository
    {
        RestaurantObject context;

        public MealRepository(RestaurantObject context)
        {
            this.context = context;
        }

        public List<Meals> GetAllMeals()
        {
            return context.Meals.ToList();
        }

        public List<Meals> GetAllMealsByCharacter(string characters, int categoryCode)
        {        
            return context.Meals.Where(m => m.MealCategoryCode == categoryCode && m.MealName.ToUpper().StartsWith(characters.ToUpper())).ToList();
        }

        public Meals GetMealByMealCode(int mealCode)
        {
            return context.Meals.Where(m => m.MealCode == mealCode).FirstOrDefault();
        }

        public Meals GetMealByMealName(string mealName)
        {
            return context.Meals.Where(m => m.MealName == mealName).FirstOrDefault();
        }

        public Meals GetMealByName(string mealName)
        {
            return context.Meals.Where(m => m.MealName == mealName).FirstOrDefault();
        }

        public List<Meals> GetMealsByCategoryCode(int categoryCode)
        {
            return context.Meals.Where(m => m.MealCategoryCode == categoryCode).ToList();
        }

        public List<Meals> GetMealsByStyleCode(int styleCode)
        {
            return context.Meals.Where(m => m.MealStyleCode == styleCode).ToList();
        }

        public List<Meals> GetMealsByTimeCode(int timeCode)
        {
            return context.Meals.Where(m => m.MealTimeCode == timeCode).ToList();
        }

        public List<Meals> GetMealsWithPriceBetween(int minPrice, int maxPrice)
        {
            List<Meals> regularPrice = context.Meals.Where(m => m.MealPrice >= minPrice && m.MealPrice <= maxPrice).ToList();
            List<Meals> salePrice = context.Meals.Where(m => m.MealSalePrice >= minPrice && m.MealSalePrice <= maxPrice).ToList();
            List<Meals> allPrices = new List<Meals>();
            foreach (var meal in regularPrice)
            {
                allPrices.Add(meal);
            }
            foreach (var meal in salePrice)
            {
                allPrices.Add(meal);
            }
            return allPrices;
        }

        public decimal GetPriceByMealCode(int mealCode)
        {
            Meals meal = context.Meals.Where(m => m.MealCode == mealCode).FirstOrDefault();
            return meal.MealPrice;
        }
    }
}

