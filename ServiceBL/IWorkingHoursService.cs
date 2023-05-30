using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBL
{
  public interface IWorkingHoursService
  {
    List<WorkingHours> GetAllWorkingHours();
    int AddWorkingHours(WorkingHours workingHours);
    List<WorkingHours> GetWorkingHoursByEmployeeCodeAndDates( DateTime fsrom, DateTime until, string search = " ");
    void UpdateExitTimeAndTotalHours(int employeeCode);
  }
}
