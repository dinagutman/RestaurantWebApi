using System;
using System.Collections.Generic;
using System.Text;
using Repositories.Models;
using Repositories.Repositories;

namespace ServiceBL
{
  public class OrdersService : IOrdersService
  {
    IOrdersRepository ordersRepo;
    public OrdersService(IOrdersRepository ordersRepo)
    {
      //Dependency Injection
      this.ordersRepo = ordersRepo;
    }
    public int AddOrder(Orders newOrder)
    {
      return ordersRepo.AddOrder(newOrder);
    }

    public bool DeleteOrderByOrderCode(int orderCode)
    {
      return ordersRepo.DeleteOrderByOrderCode(orderCode);
    }

    public List<Orders> GetAllOrders()
    {
      return ordersRepo.GetAllOrders();
    }
    public Orders GetOrderByCode(int orderCode)
    {
      return ordersRepo.GetOrderByCode(orderCode);
    }
    public Orders GetOrderByRestaurantTableCode(int restaurantTableCode)
    {
      return ordersRepo.GetOrderByRestaurantTableCode(restaurantTableCode);
    }

    public int GetOrderCodeByTableCode(int tableCode)
    {
      return ordersRepo.GetOrderCodeByTableCode(tableCode);
    }

    public decimal GetOrderPriceByOrderCode(int orderCode)
    {
      return ordersRepo.GetOrderPriceByOrderCode(orderCode);
    }

    public List<Orders> GetOrdersByEmployeeCode(int employeeCode)
    {
      return ordersRepo.GetOrdersByEmployeeCode(employeeCode);
    }

    public decimal GetTotalIncomeToDay()
    {
      return ordersRepo.GetTotalIncomeToDay();
    }

    public bool IsOrderPaid(int orderCode)
    {
      return ordersRepo.IsOrderPaid(orderCode);
    }

    public void UpdateTotalPaymentForOrder(OrderToUpdate data)
    {
       ordersRepo.UpdateTotalPaymentForOrder(data);
    }
  }
}
