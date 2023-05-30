using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Models;
using Repositories.Repositories;

namespace ServiceBL
{
  public static class IServiceCollectionExtension
  {
    public static IServiceCollection AddDependencies(this IServiceCollection collection)
    {
      collection.AddScoped<IEmployeeRepository, EmployeeRepository>();
      collection.AddScoped<ITablesRepository, TablesRepository>();
      collection.AddScoped<IOrdersRepository, OrdersRepository>();
      collection.AddScoped<IMealRepository, MealRepository>();
      collection.AddScoped<IMealCategoryRepository, MealCategoryRepository>();
      collection.AddScoped<IOrderDetailesRepository, OrderDetailesRepository>();
      collection.AddScoped<IRoleRepository, RoleRepository>();
      collection.AddScoped<IEmploymentRepository, EmploymentRepository>();
      collection.AddScoped<IWorkingHoursRepository, WorkingHoursRepository>();
      //adds context to service collection with scoped lifetime

      collection.AddDbContext<RestaurantObject>(options =>

      options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\RestaurantProject\RestaurantWebApi\DATA\Restaurant.mdf;Integrated Security=True;Connect Timeout=30"));
      return collection;
    }
  }
}
