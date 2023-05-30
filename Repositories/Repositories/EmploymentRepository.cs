using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.Models;

namespace Repositories.Repositories
{
  public class EmploymentRepository : IEmploymentRepository
  {
        RestaurantObject context = new RestaurantObject();
    public EmploymentRepository(RestaurantObject context)
    {
      this.context = context;
    }

    public List<Employment> GetEmployments()
    {
      return context.Employment.ToList();
    }
  }
}
