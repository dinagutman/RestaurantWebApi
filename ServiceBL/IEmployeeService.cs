using System;
using System.Collections.Generic;
using System.Text;
using Repositories.Models;

namespace ServiceBL
{
    public interface IEmployeeService
    {
        List<Employees> GetAllEmployees();
        Employees GetById(int employeeId);
        int AddEmployee(Employees employee);
        string checkAndGetRoleName(string name, int pass);
        int checkIdAndName(int id, string fullName);
        Employees GetEmployeeByOrderCode(int orderCode);
        Employees GetByCode(int code);
        bool Remove(int codeForRemove);
      }
}
