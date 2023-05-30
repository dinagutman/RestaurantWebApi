using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Repositories
{
    public class OrderDetailesRepository : IOrderDetailesRepository
    {
        RestaurantObject context = new RestaurantObject();
        public OrderDetailesRepository(RestaurantObject context)
        {
            this.context = context;
        }

        public bool AddOrderdetails(OrderDetails orderDetails)
        {
            var isExist = context.OrderDetails.Any(o => o.MealCode == orderDetails.MealCode && o.OrderCode == orderDetails.OrderCode);
            if (!isExist)
            {
                var res = context.OrderDetails.Add(orderDetails);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteMealByOrderCode(int orderCode)
        {
            List<OrderDetails> isExist = context.OrderDetails.Where(o => o.OrderCode == orderCode).ToList();
            if (isExist != null)
            {
                foreach (var item in isExist)
                {
                    var res = context.OrderDetails.Remove(item);
                    context.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public bool DeleteMeal(OrderDetails orderDetails)
        {
            var isExist = context.OrderDetails.Any(o => o.MealCode == orderDetails.MealCode && o.OrderCode == orderDetails.OrderCode && o.IsMealCreated == false);
            if (isExist == true)
            {
                var res = context.OrderDetails.Remove(orderDetails);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<StringOrderDetails> GetOrderDetailsByOrderCode(int orderCode)
        {
            List<OrderDetails> orderDetails = context.OrderDetails.Where(o => o.OrderCode == orderCode).ToList();
            List<StringOrderDetails> stringOrders = new List<StringOrderDetails>();
            foreach (var item in orderDetails)
            {
                Meals meal = context.Meals.Where(m => m.MealCode == item.MealCode).FirstOrDefault();
                if (meal != null)
                {
                    StringOrderDetails stringObject = new StringOrderDetails();
                    stringObject.MealName = meal.MealName;
                    stringObject.ServingAmount = int.Parse(item.ServingAmount);
                    stringObject.OrderCode = orderCode;
                    stringObject.MealPrice = meal.MealPrice;
                    stringObject.MealCode = meal.MealCode;
                    Orders order = context.Orders.Where(o => o.OrderCode == orderCode).FirstOrDefault();
                    stringObject.TableCode = order.RestaurantTableCode;
                    stringOrders.Add(stringObject);
                }
            }
            return stringOrders;
        }

        public void UpdateServingAmount(OrderDetails orderDetails)
        {
            var query = context.OrderDetails.Where(o => o.MealCode == orderDetails.MealCode && o.OrderCode == orderDetails.OrderCode).FirstOrDefault();
            if (query != null)
            {
                query.ServingAmount = orderDetails.ServingAmount;
                if (query.IsMealCreated == true)
                {
                    query.IsMealCreated = false;
                    Orders order = context.Orders.Where(o => o.OrderCode == orderDetails.OrderCode).FirstOrDefault();
                    RestaurantTables table = context.RestaurantTables.Where(t => t.RestaurantTableCode == order.RestaurantTableCode).FirstOrDefault();
                    table.TableStatusCode = 502;
                }
                context.SaveChanges();
            }
        }

        public StringOrderDetails CheckForNewOrderDetails()
        {
            OrderDetails query = context.OrderDetails.Where(m => m.IsMealCreated == false).LastOrDefault();
            if (query != null)
            {
                StringOrderDetails stringOrderDetails = new StringOrderDetails();
                stringOrderDetails.OrderCode = query.OrderCode;
                stringOrderDetails.TableCode = context.Orders.Where(o => o.OrderCode == query.OrderCode).FirstOrDefault().RestaurantTableCode;
                stringOrderDetails.MealCode = query.MealCode;
                stringOrderDetails.MealName = context.Meals.Where(m => m.MealCode == query.MealCode).FirstOrDefault().MealName;
                stringOrderDetails.MealPrice = context.Meals.Where(m => m.MealCode == query.MealCode).FirstOrDefault().MealPrice;
                stringOrderDetails.ServingAmount = int.Parse(query.ServingAmount) - query.HowMuchMealCreated.GetValueOrDefault();
                stringOrderDetails.HowMuchMealCreated = 0;
                stringOrderDetails.IsMealCreated = true;

                return stringOrderDetails;
            }
            return null;
        }
        public void UpdateMealAfterCreating(UpdateOrderDetailsData data)
        {
            OrderDetails query = context.OrderDetails.Where(o => o.OrderCode == data.OrderCode && o.MealCode == data.MealCode).FirstOrDefault();
            if (query != null)
            {
                query.IsMealCreated = true;
                query.HowMuchMealCreated = int.Parse(query.ServingAmount);
                context.SaveChanges();
            }
        }
        public List<OrderDetailsReceipt> GetOrderDetailsReceiptsByOrderCode(int orderCode)
        {
            List<OrderDetails> orderDetails = context.OrderDetails.Where(o => o.OrderCode == orderCode).ToList();
            List<OrderDetailsReceipt> orderDetailsReceipts = new List<OrderDetailsReceipt>();
            foreach (var item in orderDetails)
            {
                Meals meal = context.Meals.Where(m => m.MealCode == item.MealCode).FirstOrDefault();
                if (meal != null)
                {
                    OrderDetailsReceipt receipt = new OrderDetailsReceipt();
                    receipt.Meal = meal.MealName;
                    receipt.Amount = int.Parse(item.ServingAmount);
                    receipt.Price += meal.MealPrice;
                    receipt.Price += "  X  " + receipt.Amount;
                    orderDetailsReceipts.Add(receipt);
                }
            }
            return orderDetailsReceipts;
        }
        public int GetTotalSoldMealsToday()
        {
            var allMeals =
                from a in context.OrderDetails
                join b in context.Orders on a.OrderCode equals b.OrderCode
                where b.OrderTime.GetValueOrDefault().ToString("dd-MM-yyy") == DateTime.Today.ToString("dd-MM-yyyy")
                select a.HowMuchMealCreated;
            return allMeals.ToList().Count();
        }
        public bool IsMealCreated(int orderCode, int mealCode)
        {
            return context.OrderDetails.Any(o => o.MealCode == mealCode && o.OrderCode == orderCode && int.Parse(o.ServingAmount) == o.HowMuchMealCreated && o.IsMealCreated == true);
        }
    }
}
