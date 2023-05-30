using System;
using System.Collections.Generic;
using System.Text;
using Repositories.Models;
using Repositories.Repositories;

namespace ServiceBL
{
  public class WorkingHoursService : IWorkingHoursService
  {
    IWorkingHoursRepository workingHoursRepo;
    public WorkingHoursService(IWorkingHoursRepository workingHoursRepo)
    {
      //Dependency Injection
      this.workingHoursRepo = workingHoursRepo;
    }
    public int AddWorkingHours(WorkingHours workingHours)
    {
      return workingHoursRepo.AddWorkingHours(workingHours);
    }
    public List<WorkingHours> GetAllWorkingHours()
    {
      return workingHoursRepo.GetAllWorkingHours();
    }
    public List<WorkingHours> GetWorkingHoursByEmployeeCodeAndDates(DateTime from, DateTime until, string search = " ")
    {
      return workingHoursRepo.GetWorkingHoursByEmployeeCodeAndDates(from, until, search);
    }

    public void UpdateExitTimeAndTotalHours(int employeeCode)
    {
      workingHoursRepo.UpdateExitTimeAndTotalHours(employeeCode);
    }
  }
}
