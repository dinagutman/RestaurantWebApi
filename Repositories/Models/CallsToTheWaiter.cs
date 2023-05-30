using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class CallsToTheWaiter
    {
        public int CallCode { get; set; }
        public int RestaurantTableCode { get; set; }

        public RestaurantTables RestaurantTableCodeNavigation { get; set; }
    }
}
