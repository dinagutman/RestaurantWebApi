using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class MealStyle
    {
        public MealStyle()
        {
            Meals = new HashSet<Meals>();
        }

        public int MealStyleCode { get; set; }
        public string MealStyleDescription { get; set; }

        public ICollection<Meals> Meals { get; set; }
    }
}
