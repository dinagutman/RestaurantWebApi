using Repositories.Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBL
{
    public interface IOrderDetailsService
    {
        bool addOrderdetails(OrderDetails orderDetails);
        bool DeleteMealByOrderCode(int orderCode);
        bool DeleteMeal(OrderDetails orderDetails);
        List<StringOrderDetails> GetOrderDetailsByOrderCode(int orderCode);
        void UpdateServingAmount(OrderDetails orderDetails);
        StringOrderDetails CheckForNewOrderDetails();
        void UpdateMealAfterCreating(UpdateOrderDetailsData data);
        List<OrderDetailsReceipt> GetOrderDetailsReceiptsByOrderCode(int orderCode);
        bool IsMealCreated(int orderCode, int mealCode);
        int getTotalSoldMealsToday();
    }
}
