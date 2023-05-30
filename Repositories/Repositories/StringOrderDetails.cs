using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
  public class StringOrderDetails
  {
    public int? TableCode { get; set; }
    public int OrderCode { get; set; }
    public string MealName { get; set; }
    public int MealCode { get; set; }
    public int ServingAmount { get; set; }
    public decimal MealPrice { get; set; }
    public int? HowMuchMealCreated { get; set; }
    public bool IsMealCreated { get; set; }
  }
}
