using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBL
{
    public interface IMealCategoryService
    {
     List<MealCategory> GettAllCategories();
    }
}
