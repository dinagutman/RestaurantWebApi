using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
 public interface IEmploymentRepository
  {
    List<Employment> GetEmployments();
  }
}
