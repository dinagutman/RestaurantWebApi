using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class TableStatus
    {
        public TableStatus()
        {
            RestaurantTables = new HashSet<RestaurantTables>();
        }

        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }

        public ICollection<RestaurantTables> RestaurantTables { get; set; }
    }
}
