using Repositories.Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBL
{
    public class TableService : ITableSrvice
    {
        ITablesRepository tablesRepo;
        public TableService(ITablesRepository tablesRepository)
        {
            //Dependency Injection
            tablesRepo = tablesRepository;
        }

        public List<RestaurantTables> GetAllAvailableTables()
        {
            return tablesRepo.GetAllAvailableTables();
        }

        public List<DictionaryTableOrder> GetAllBusyTables()
        {
            return tablesRepo.GetAllBusyTables();
        }

        public List<RestaurantTables> GetAllTables()
        {
            return tablesRepo.GetAllTables();
        }

        public RestaurantTables GetById(int tableCode)
        {
            return tablesRepo.GetById(tableCode);
        }

        public List<RestaurantTables> GetTablesByNumOfSeats(int numOfSeats)
        {
            return tablesRepo.GetTablesByNumOfSeats(numOfSeats);
        }

        public List<RestaurantTables> GetTablesByStatusCode(int statusCode)
        {
            return tablesRepo.GetTablesByStatusCode(statusCode);
        }

        public int? GetTableStatusByTableCode(int tableCode)
        {
            return tablesRepo.GetTableStatusByTableCode(tableCode);
        }

        public void UpdateTableStatus(UpdateTableData data)
        {
             tablesRepo.UpdateTableStatus(data);
        }
        public bool AddNewTable(int numOfSeats)
        {
            return tablesRepo.AddNewTable(numOfSeats);
        }
    }
}