using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class MealCategory
    {
        public MealCategory()
        {
            Meals = new HashSet<Meals>();
        }

        public int MealCategoryCode { get; set; }
        public string MealCategoryName { get; set; }

        public ICollection<Meals> Meals { get; set; }
    }
}
