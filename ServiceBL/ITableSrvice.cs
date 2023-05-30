using Repositories.Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBL
{
    public interface ITableSrvice
    {
        RestaurantTables GetById(int tableCode);

        List<RestaurantTables> GetAllTables();

        List<RestaurantTables> GetTablesByNumOfSeats(int numOfSeats);

        List<RestaurantTables> GetTablesByStatusCode(int statusCode);
        List<RestaurantTables> GetAllAvailableTables();
        List<DictionaryTableOrder> GetAllBusyTables();
        void UpdateTableStatus(UpdateTableData data);
        int? GetTableStatusByTableCode(int tableCode);
        bool AddNewTable(int numOfSeats);
    }
}
