using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using Repositories.Repositories;
using ServiceBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantWebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("CorsPolicy")]
  public class OrderDetailsController : ControllerBase
  {
    IOrderDetailsService orderDetailsService;
    public OrderDetailsController(IOrderDetailsService orderDetailesService)
    {
      //Dependency Injection
      orderDetailsService = orderDetailesService;
    }

    [HttpPost("addOrderDetails")]
    public bool AddOrderdetails(OrderDetails orderDetails)
    {
      return orderDetailsService.addOrderdetails(orderDetails);
    }

    [HttpPost("deleteMealByOrderCode")]
    [EnableCors("CorsPolicy")]
    public bool DeleteMealByOrderCode([FromBody] int orderCode)
    {
      return orderDetailsService.DeleteMealByOrderCode(orderCode);
    }

    [HttpPost("deleteMealFromOrder")]
    [EnableCors("CorsPolicy")]
    public bool DeleteMealFromOrder(OrderDetails orderDetailsToDelete)
    {
      return orderDetailsService.DeleteMeal(orderDetailsToDelete);
    }
    [HttpGet("getOrderDetailsByOrderCode/{orderCode}")]
    [EnableCors("CorsPolicy")]
    public List<StringOrderDetails> GetOrderDetailsByOrderCode(int orderCode)
    {
      return orderDetailsService.GetOrderDetailsByOrderCode(orderCode);
    }
    [HttpPost("updateServingAmount")]
    [EnableCors("CorsPolicy")]
    public void UpdateServingAmount([FromBody] OrderDetails orderDetails)
    {
      orderDetailsService.UpdateServingAmount(orderDetails);
    }
    [HttpGet("checkForNewOrderDetails")]
    [EnableCors("CorsPolicy")]
    public StringOrderDetails CheckForNewOrderDetails()
    {
      return orderDetailsService.CheckForNewOrderDetails();
    }
    [HttpPost("updateMealAfterCreating")]
    [EnableCors("CorsPolicy")]
    public void UpdateMealAfterCreating([FromBody] UpdateOrderDetailsData data)
    {
      orderDetailsService.UpdateMealAfterCreating(data);
    }
    [HttpGet("isMealCreated/{orderCode}/{mealCode}")]
    [EnableCors("CorsPolicy")]
    public bool IsMealCreated(int orderCode, int mealCode)
    {
      return orderDetailsService.IsMealCreated(orderCode, mealCode);
    }
    [HttpGet("getTotalSoldMealsToday")]
   [EnableCors("CorsPolicy")]
        public int getTotalSoldMealsToday()
        {
            return orderDetailsService.getTotalSoldMealsToday();
        }
    }
}
