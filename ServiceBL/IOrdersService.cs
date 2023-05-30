using Repositories.Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBL
{
  public interface IOrdersService
  {
    List<Orders> GetAllOrders();
    List<Orders> GetOrdersByEmployeeCode(int employeeCode);
    Orders GetOrderByCode(int orderCode);
    Orders GetOrderByRestaurantTableCode(int restaurantTableCode);
    int AddOrder(Orders newOrder);
    int GetOrderCodeByTableCode(int tableCode);
    decimal GetOrderPriceByOrderCode(int orderCode);
    bool DeleteOrderByOrderCode(int orderCode);
    void UpdateTotalPaymentForOrder(OrderToUpdate data);
    bool IsOrderPaid(int orderCode);
    decimal GetTotalIncomeToDay();
  }
}
