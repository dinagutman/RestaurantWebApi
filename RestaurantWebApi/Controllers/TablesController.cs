using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using Repositories.Repositories;
using ServiceBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        ITableSrvice tableService;
        public TablesController(ITableSrvice tableSrvice)
        {
            this.tableService = tableSrvice;
        }

        [HttpGet("GetAll")]
        [EnableCors("AllowOrigin")]//Security

        public List<RestaurantTables> GetAll()
        {
            return tableService.GetAllTables();
        }

        [HttpGet("tableCode/{tableCode}")]
        public RestaurantTables GetById(int tableCode)
        {
            return tableService.GetById(tableCode);
        }

        [HttpGet("numOfSeats/{numOfSeats}")]
        public List<RestaurantTables> GetTablesByNumOfSeats(int numOfSeats)
        {
            return tableService.GetTablesByNumOfSeats(numOfSeats);
        }

        [HttpGet("statusCode/{statusCode}")]
        public List<RestaurantTables> GetTablesByStatusCode(int statusCode)
        {
            return tableService.GetTablesByStatusCode(statusCode);
        }

        [HttpGet("allAvailable")]
        [EnableCors("CorsPolicy")]
        public List<RestaurantTables> GetAllAvailableTables()
        {
            return tableService.GetAllAvailableTables();
        }
        [HttpGet("getAllBusyTables")]
        [EnableCors("CorsPolicy")]
        public List<DictionaryTableOrder> GetAllBusyTables()
        {
            return tableService.GetAllBusyTables();
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public void UpdateTableStatus([FromBody] UpdateTableData data)
        {
            tableService.UpdateTableStatus(data);
        }
        [HttpPost("{numOfSeats}")]
        [EnableCors("CorsPolicy")]
        public bool AddNewTable(int numOfSeats)
        {
           return tableService.AddNewTable(numOfSeats);
        }


        [HttpGet("getTableStatusByTableCode/{tableCode}")]
        [EnableCors("CorsPolicy")]
        public int? GetTableStatusByTableCode(int tableCode)
        {
            return tableService.GetTableStatusByTableCode(tableCode);
        }
    }
}
