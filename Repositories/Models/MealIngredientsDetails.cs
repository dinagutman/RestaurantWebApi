using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class MealIngredientsDetails
    {
        public int MealCode { get; set; }
        public string MealIngredientsDescription { get; set; }

        public Meals MealCodeNavigation { get; set; }
    }
}
