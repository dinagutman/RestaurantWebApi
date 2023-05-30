using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using ServiceBL;
using System;
using System.Collections.Generic;

namespace RestaurantWebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("CorsPolicy")]
  public class WorkingHoursController : ControllerBase
  {
    IWorkingHoursService workingHoursService;
    public WorkingHoursController(IWorkingHoursService workingHoursService)
    {
      this.workingHoursService = workingHoursService;
    }
    [HttpGet("getAllWorkingHours")]
    public List<WorkingHours> GetAllWorkingHours()
    {
      return workingHoursService.GetAllWorkingHours();
    }

    [HttpPost("addWorkingHours")]
    [EnableCors("CorsPolicy")]
    public int AddWorkingHours(WorkingHours workingHours)
    {
      return workingHoursService.AddWorkingHours(workingHours);
    }
    [HttpGet("getWorkingHoursBetweenDates/{from}/{until}/{search}")]
    [EnableCors("CorsPolicy")]
    public List<WorkingHours> GetWorkingHoursByEmployeeCodeAndDates(DateTime from, DateTime until, string search = " ")
    {
      return workingHoursService.GetWorkingHoursByEmployeeCodeAndDates(from, until, search);
    }
    [HttpPost("updateExitTimeAndTotalHours")]
    [EnableCors("CorsPolicy")]
    public void UpdateExitTimeAndTotalHours([FromBody] int employeeCode)
    {
      workingHoursService.UpdateExitTimeAndTotalHours(employeeCode);
    }
  }
}
