using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBL
{
    public interface IRoleService
    {
        string checkRoleCodeByEmployeePassword(int password);
    List<Roles> GetRoles();
  }
}

