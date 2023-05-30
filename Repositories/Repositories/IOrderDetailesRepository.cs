using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
  public interface IOrderDetailesRepository
  {
    bool AddOrderdetails(OrderDetails orderDetails);
    bool DeleteMealByOrderCode(int orderCode);
    bool DeleteMeal(OrderDetails orderDetails);
    List<StringOrderDetails> GetOrderDetailsByOrderCode(int orderCode);
    void UpdateServingAmount(OrderDetails orderDetails);
    StringOrderDetails CheckForNewOrderDetails();
    void UpdateMealAfterCreating(UpdateOrderDetailsData data);
    List<OrderDetailsReceipt> GetOrderDetailsReceiptsByOrderCode(int orderCode);
    bool IsMealCreated(int orderCode, int mealCode);
   int GetTotalSoldMealsToday();
  }
}
