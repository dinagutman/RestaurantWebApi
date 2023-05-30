using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
 public class UpdateOrderDetailsData
  {
    public int OrderCode { get; set; }
    public int MealCode { get; set; }
    public bool IsMealCreated { get; set; }
    public int HowMuchMealCreated { get; set; }
  }
}
