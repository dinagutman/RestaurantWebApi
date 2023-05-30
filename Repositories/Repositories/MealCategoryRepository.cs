using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.Models;

namespace Repositories.Repositories
{
    public class MealCategoryRepository : IMealCategoryRepository
    {
        RestaurantObject context = new RestaurantObject();
        public MealCategoryRepository(RestaurantObject context)
        {
            this.context = context;
        }
        public List<MealCategory> GettAllCategories()
        {
            return context.MealCategory.ToList();
        }
    }
}
