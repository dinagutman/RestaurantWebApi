using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Http;

namespace Repositories.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        RestaurantObject context = new RestaurantObject();
        public OrdersRepository(RestaurantObject context)
        {
            this.context = context;
        }
        public int AddOrder(Orders newOrder)
        {
            var isExist = context.Orders.Any(o => o.RestaurantTableCode == newOrder.RestaurantTableCode && o.OrderTime == newOrder.OrderTime);
            if (!isExist)
            {
                var res = context.Orders.Add(newOrder);
                context.SaveChanges();
                return res.Entity.OrderCode;
            }
            return -1;
        }

        public bool DeleteOrderByOrderCode(int orderCode)
        {
            var isExist = context.Orders.Where(o => o.OrderCode == orderCode).FirstOrDefault();
            if (isExist != null)
            {
                var res = context.Orders.Remove(isExist);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Orders> GetAllOrders()
        {
            return context.Orders.ToList();
        }
        public Orders GetOrderByCode(int orderCode)
        {
            return context.Orders.Where(o => o.OrderCode == orderCode).FirstOrDefault();
        }
        public Orders GetOrderByRestaurantTableCode(int restaurantTableCode)
        {
            return context.Orders.Where(o => o.RestaurantTableCode == restaurantTableCode).FirstOrDefault();
        }
        public int GetOrderCodeByTableCode(int tableCode)
        {
            Orders order = context.Orders.Where(o => o.RestaurantTableCode == tableCode && o.Totalpayment == 0).FirstOrDefault();
            if (order != null)
            {
                return order.OrderCode;
            }
            return -1;
        }

        public decimal GetOrderPriceByOrderCode(int orderCode)
        {
            decimal totalPrice = 0;
            List<OrderDetails> orderDetails = context.OrderDetails.Where(o => o.OrderCode == orderCode).ToList();
            if (orderDetails != null)
            {
                foreach (var item in orderDetails)
                {
                    Meals meal = context.Meals.Where(m => m.MealCode == item.MealCode).FirstOrDefault();
                    totalPrice += meal.MealPrice * int.Parse(item.ServingAmount);
                }
            }
            return totalPrice;
        }

        public List<Orders> GetOrdersByEmployeeCode(int employeeCode)
        {
            return context.Orders.Where(o => o.EmployeeCode == employeeCode).ToList();
        }

        public decimal GetTotalIncomeToDay()
        {
            decimal total = 0;
            foreach (var item in context.Orders)
            {
                if (item.OrderTime.GetValueOrDefault().ToString("dd-MM-yyy") == DateTime.Today.ToString("dd-MM-yyy"))
                {
                    total += item.Totalpayment;
                }
            }
            return total;
        }

        public bool IsOrderPaid(int orderCode)
        {
            Orders order = context.Orders.Where(o => o.OrderCode == orderCode).FirstOrDefault();
            if (order != null && order.Totalpayment != 0)
            {
                return true;
            }
            return false;
        }
        public void UpdateTotalPaymentForOrder(OrderToUpdate data)
        {
            var query = context.Orders.Where(o => o.OrderCode == data.OrderCode).FirstOrDefault();
            if (query != null)
            {
                query.Totalpayment = data.TotalPayment;
                foreach (var item in context.OrderDetails)
                {
                    if (item.OrderCode == query.OrderCode)
                    {
                        item.IsMealCreated = true;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
