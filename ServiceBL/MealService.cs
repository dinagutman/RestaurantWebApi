using System;
using System.Collections.Generic;
using System.Text;
using Repositories.Models;
using Repositories.Repositories;

namespace ServiceBL
{
   public class MealService : IMealService
    {
        IMealRepository mealRepo;

        public MealService(IMealRepository mealRepository)
        {
            //Dependency Injection
            mealRepo = mealRepository;
        }
        public List<Meals> GetAllMeals()
        {
            return mealRepo.GetAllMeals();           
        }
        public List<Meals> GetAllMealsByCharacter(string characters, int categoryCode)
        {
            return mealRepo.GetAllMealsByCharacter(characters, categoryCode);
        }
        public Meals GetMealByMealCode(int mealCode)
        {
            return mealRepo.GetMealByMealCode(mealCode);
        }
        public Meals GetMealByMealName(string mealName)
        {
            return mealRepo.GetMealByMealName(mealName);
        }
        public Meals GetMealByName(string mealName)
        {
            return mealRepo.GetMealByName(mealName);
        }
        public List<Meals> GetMealsByCategoryCode(int categoryCode)
        {
            return mealRepo.GetMealsByCategoryCode(categoryCode);
        }
        public List<Meals> GetMealsByStyleCode(int styleCode)
        {
            return mealRepo.GetMealsByStyleCode(styleCode);
        }
        public List<Meals> GetMealsByTimeCode(int timeCode)
        {
            return mealRepo.GetMealsByTimeCode(timeCode);
        }
        public List<Meals> GetMealsWithPriceBetween(int minPrice, int maxPrice)
        {
            return mealRepo.GetMealsWithPriceBetween(minPrice, maxPrice);
        }
        public decimal GetPriceByMealCode(int mealCode)
        {
            return mealRepo.GetPriceByMealCode(mealCode);
        }
    }
}
