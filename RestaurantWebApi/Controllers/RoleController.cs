using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using ServiceBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebApi.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("AllowOrigin")]//Security
  public class RoleController : ControllerBase
  {
    IRoleService roleService;
    public RoleController(IRoleService roleService)
    {
      this.roleService = roleService;
    }

    [HttpGet("checkRoleCodeByEmployeePassword/{password}")]
    public string checkRoleCodeByEmployeePassword(int password)
    {
      return roleService.checkRoleCodeByEmployeePassword(password);
    }
    [HttpGet("getRoles")]
    [EnableCors("CorsPolicy")]
    public List<Roles> GetRoles()
    {
      return roleService.GetRoles();
    }
  }
}
