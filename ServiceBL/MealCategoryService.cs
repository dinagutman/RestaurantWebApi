using Repositories.Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBL
{
    public class MealCategoryService : IMealCategoryService
    {
        IMealCategoryRepository mealRepo;
        public MealCategoryService(IMealCategoryRepository mealRepo)
        {
            //Dependency Injection
            this.mealRepo = mealRepo;
        }
        public List<MealCategory> GettAllCategories()
        {
            return mealRepo.GettAllCategories();
        }
    }
}
