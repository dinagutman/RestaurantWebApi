using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class TablesForWaiter
    {
        public int RestaurantTableCode { get; set; }
        public int WaiterCode { get; set; }

        public RestaurantTables RestaurantTableCodeNavigation { get; set; }
        public Employees WaiterCodeNavigation { get; set; }
    }
}
