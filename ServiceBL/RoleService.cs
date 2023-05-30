using System;
using System.Collections.Generic;
using System.Text;
using Repositories.Models;
using Repositories.Repositories;

namespace ServiceBL
{
    public class RoleService : IRoleService
    {
        IRoleRepository roleRepo;
        public RoleService(IRoleRepository roleRepo)
        {
            //Dependency Injection
            this.roleRepo = roleRepo;
        }
        public string checkRoleCodeByEmployeePassword(int password)
        {
            return roleRepo.checkRoleCodeByEmployeePassword(password);
        }

    public List<Roles> GetRoles()
    {
      return roleRepo.GetRoles();
        }
  }
}
