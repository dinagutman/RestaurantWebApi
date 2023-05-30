using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Employees = new HashSet<Employees>();
        }

        public int RoleCode { get; set; }
        public string RoleName { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}
