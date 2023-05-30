using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
  public interface IWorkingHoursRepository
  {
    List<WorkingHours> GetAllWorkingHours();
    int AddWorkingHours(WorkingHours workingHours);
    List<WorkingHours> GetWorkingHoursByEmployeeCodeAndDates(DateTime from, DateTime until, string search = " ");
    void UpdateExitTimeAndTotalHours(int employeeCode);
  }
}
