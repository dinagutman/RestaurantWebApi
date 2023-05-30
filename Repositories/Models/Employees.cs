using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Orders = new HashSet<Orders>();
            TablesForWaiter = new HashSet<TablesForWaiter>();
            WorkingHours = new HashSet<WorkingHours>();
        }

        public int EmployeeCode { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int? RoleCode { get; set; }
        public int? EmploymentCode { get; set; }
        public DateTime? StartingDate { get; set; }
        public decimal? BaseSalary { get; set; }
        public decimal? SalaryTip { get; set; }
        public int? EmployeeId { get; set; }

        public Employment EmploymentCodeNavigation { get; set; }
        public Roles RoleCodeNavigation { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<TablesForWaiter> TablesForWaiter { get; set; }
        public ICollection<WorkingHours> WorkingHours { get; set; }
    }
}
