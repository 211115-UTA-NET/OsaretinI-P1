using System;
using System.Text.Json;
using OsaGadgetStore;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace P1GadgetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        
        private IConfiguration Configuration;
        public MainController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        [HttpGet("/GetAllItems")] 
        public ContentResult GetItems()

        {
            string connString = this.Configuration.GetConnectionString("RPS-DB-Connection");
            Inventory inventory = new Inventory(connString);
            List<MyData> result = inventory.GetAllInventory();

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(result);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }
        [HttpGet("/GetOrderByName/{id}")]
        public ContentResult GetPeople(string id)
        {

            string connString = this.Configuration.GetConnectionString("RPS-DB-Connection");
            Account acct = new Account(connString);

            List<Account> accinfo = acct.getCustomerInfo(id);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(accinfo);
            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };

        }
        [HttpGet("/GetOrderHistory/{id}")]
        public ContentResult GetOrderHistory(string id)
        {
            string connString = this.Configuration.GetConnectionString("RPS-DB-Connection");

            Inventory acct = new Inventory(connString);
            List<Inventory> accinfo = acct.getInventoryOrderHistory(id);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(accinfo);
            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };

        }
      
        [HttpPost("/test")]
      
        public async Task<IActionResult> AddOrder(List<testingClass> accountk2j)
        {
            string connString = this.Configuration.GetConnectionString("RPS-DB-Connection");

            List<ShoppingCart> fd = new();
            for (int i = 0; i < accountk2j[0].items.Length; i++)
            {
               
             fd.Add(new(Convert.ToInt32(accountk2j[0].items[i].itemId), accountk2j[0].items[i].itemNum, accountk2j[0].items[i].itemName, accountk2j[0].items[i].location, accountk2j[0].items[i].cost, accountk2j[0].items[i].Quantity));
                
            }

            try
            {
                Connection repository = new Connection(connString);
                repository.SaveToDb(accountk2j[0].CustomerId, accountk2j[0].Fname, accountk2j[0].Lname, accountk2j[0].StreetAddress, accountk2j[0].City, accountk2j[0].State, fd);
            }
            catch (SqlException ex)
            {
   
                return StatusCode(500);
            }





            return new ContentResult()
            {
                StatusCode = StatusCodes.Status201Created,
                ContentType = "application/json"
                
            };
        }
    }
}
