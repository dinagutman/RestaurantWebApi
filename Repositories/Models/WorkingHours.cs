using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class WorkingHours
    {
        public int WorkingHoursCode { get; set; }
        public int EmployeeCode { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime WorkingDate { get; set; }
        public string EnterTime { get; set; }
        public string ExitTime { get; set; }
        public string TotalHoursForDay { get; set; }

        public Employees EmployeeCodeNavigation { get; set; }
    }
}
