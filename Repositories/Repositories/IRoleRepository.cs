using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
    public interface IRoleRepository
    {
        string checkRoleCodeByEmployeePassword(int password);
    List<Roles> GetRoles();
    }
}
