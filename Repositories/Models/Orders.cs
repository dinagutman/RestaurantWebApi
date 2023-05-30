using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderCode { get; set; }
        public int? RestaurantTableCode { get; set; }
        public int EmployeeCode { get; set; }
        public DateTime? OrderTime { get; set; }
        public decimal Totalpayment { get; set; }

        public Employees EmployeeCodeNavigation { get; set; }
        public RestaurantTables RestaurantTableCodeNavigation { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
