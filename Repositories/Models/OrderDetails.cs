using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class OrderDetails
    {
        public int OrderCode { get; set; }
        public int MealCode { get; set; }
        public string ServingAmount { get; set; }
        public bool IsMealCreated { get; set; }
        public int? HowMuchMealCreated { get; set; }

        public Meals MealCodeNavigation { get; set; }
        public Orders OrderCodeNavigation { get; set; }
    }
}
