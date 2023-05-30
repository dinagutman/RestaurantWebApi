using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Repositories.Models;


namespace ServiceBL
{
  public class EmployeeService : IEmployeeService
  {
    IEmployeeRepository employeeRepo;
    public EmployeeService(IEmployeeRepository employeeRepository)
    {
      //Dependency Injection
      this.employeeRepo = employeeRepository;
    }

    public List<Employees> GetAllEmployees()
    {
      return employeeRepo.GetAllEmployees();
    }

    public Employees GetById(int employeeId)
    {
      return employeeRepo.GetById(employeeId);
    }

    public int AddEmployee(Employees employee)
    {
      return employeeRepo.AddEmployee(employee);
    }

    public string checkAndGetRoleName(string name, int pass)
    {
      return employeeRepo.checkAndGetRoleName(name, pass);
    }
        public int checkIdAndName(int id, string fullName)
        {
            return employeeRepo.checkIdAndName(id, fullName);
        }

        public Employees GetEmployeeByOrderCode(int orderCode)
        {
            return employeeRepo.GetEmployeeByOrderCode(orderCode);
        }

        public Employees GetByCode(int code)
        {
            return employeeRepo.GetByCode(code);
        }

        public bool Remove(int codeForRemove)
        {
          return employeeRepo.Remove(codeForRemove);
        }
    }
}
