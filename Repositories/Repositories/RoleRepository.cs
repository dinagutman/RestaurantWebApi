using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.Models;

namespace Repositories.Repositories
{
  public class RoleRepository : IRoleRepository
  {
        RestaurantObject context = new RestaurantObject();
    public RoleRepository(RestaurantObject context)
    {
      this.context = context;
    }
    public string checkRoleCodeByEmployeePassword(int password)
    {
      Employees employee = context.Employees.Where(e => e.EmployeeCode == password).FirstOrDefault();
      int? roleCode = employee.RoleCode;
      return context.Roles.Where(r => r.RoleCode == roleCode).FirstOrDefault().RoleName;
    }

    public List<Roles> GetRoles()
    {
      return context.Roles.ToList();
    }
  }
}
