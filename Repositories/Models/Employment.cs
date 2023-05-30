using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Employment
    {
        public Employment()
        {
            Employees = new HashSet<Employees>();
        }

        public int EmploymentCode { get; set; }
        public string EmploymentName { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}
