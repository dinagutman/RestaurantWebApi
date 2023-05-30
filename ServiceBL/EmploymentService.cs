using System;
using System.Collections.Generic;
using System.Text;
using Repositories.Models;
using Repositories.Repositories;

namespace ServiceBL
{
  public class EmploymentService : IEmploymentService
  {
    IEmploymentRepository employmentRepo;
    public EmploymentService(IEmploymentRepository employmentRepo)
    {
      //Dependency Injection
      this.employmentRepo = employmentRepo;
    }
    public List<Employment> GetEmployments()
    {
      return employmentRepo.GetEmployments();
    }
  }
}
