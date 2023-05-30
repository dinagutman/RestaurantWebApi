using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class MealTime
    {
        public MealTime()
        {
            Meals = new HashSet<Meals>();
        }

        public int MealTimeCode { get; set; }
        public string MealTimeDescription { get; set; }

        public ICollection<Meals> Meals { get; set; }
    }
}
