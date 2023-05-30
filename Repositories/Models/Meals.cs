using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Meals
    {
        public Meals()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int MealCode { get; set; }
        public string MealName { get; set; }
        public decimal MealPrice { get; set; }
        public decimal MealSalePrice { get; set; }
        public int? MealCategoryCode { get; set; }
        public int? MealStyleCode { get; set; }
        public int? MealTimeCode { get; set; }

        public MealCategory MealCategoryCodeNavigation { get; set; }
        public MealStyle MealStyleCodeNavigation { get; set; }
        public MealTime MealTimeCodeNavigation { get; set; }
        public MealIngredientsDetails MealIngredientsDetails { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
