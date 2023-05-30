using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class RestaurantTables
    {
        public RestaurantTables()
        {
            CallsToTheWaiter = new HashSet<CallsToTheWaiter>();
            Orders = new HashSet<Orders>();
            TablesForWaiter = new HashSet<TablesForWaiter>();
        }

        public int RestaurantTableCode { get; set; }
        public int NumOfSeats { get; set; }
        public int TableStatusCode { get; set; }

        public TableStatus TableStatusCodeNavigation { get; set; }
        public ICollection<CallsToTheWaiter> CallsToTheWaiter { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<TablesForWaiter> TablesForWaiter { get; set; }
    }
}
