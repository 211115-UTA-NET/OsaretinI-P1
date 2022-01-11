using System;
using System.Text.Json;
using OsaGadgetStore;
using Microsoft.AspNetCore.Mvc;

namespace P1GadgetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //1/9/22
        //private static readonly List<int> s_samples = new() { 12 };
        private IConfiguration Configuration;
        public TestController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        // [Route] works for all http methods(verbs)
        // [HttpGet], [HttpPost], etc - to also limit it to a specific method.

        // the job of an action method is to handle one set of requests
        // and return some "result" which asp.net will turn into the response
        [HttpGet("/GetAllItems")] // c# supports multiple attributes (same or different type)
                                  // public async Task<ContentResult> GetSamples()
        public ContentResult GetItems()

        {
            string connString = this.Configuration.GetConnectionString("RPS-DB-Connection");

            // IEnumerable<MyData> result;
            Inventory inventory = new Inventory(connString);
            List<MyData> result = inventory.GetAllInventory();

        
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(result);

            // var result3 = new ContentResult()
            // {
            //     StatusCode = 200,
            //     ContentType = "application/json",
            //    Content = json
            // };

            // return new JsonResult(result3);

            // IEnumerable<User> Users = await _repository.GetUsersAsync(name);



            // return new JsonResult(json);
            return new ContentResult()
            {
                //StatusCode = StatusCodes.Status201Created,
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };


        }
        //  [HttpGet]
        [HttpGet("/GetOrderByName/{id}")]
        // public async Task<ContentResult> GetSamples()
        public ContentResult GetPeople(string id)
        {



            string connString = this.Configuration.GetConnectionString("RPS-DB-Connection");


            Account acct = new Account(connString);
            List<Account> accinfo = acct.getCustomerInfo(id);





            var json = Newtonsoft.Json.JsonConvert.SerializeObject(accinfo);


            return new ContentResult()
            {
                //StatusCode = StatusCodes.Status201Created,
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };

        }
        //  [HttpGet]
        [HttpGet("/GetOrderHistory/{id}")]
        // public async Task<ContentResult> GetSamples()
        public ContentResult GetOrderHistory(string id)
        {



            string connString = this.Configuration.GetConnectionString("RPS-DB-Connection");

            Inventory acct = new Inventory(connString);
            List<Inventory> accinfo = acct.getInventoryOrderHistory(id);

          //  Account acct = new Account(connString);
          //  List<Account> accinfo = acct.getCustomerInfo(id);





            var json = Newtonsoft.Json.JsonConvert.SerializeObject(accinfo);


            return new ContentResult()
            {
                //StatusCode = StatusCodes.Status201Created,
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };

        }
        // "model binding" runs before the action method:
        //   - looks at the action method parameters, tries to fill them in
        //     by deserializing parts of the request, based on the parameter name and type.
        //   - [From___] attributes can influence/tell model binding what to do too
        //   - if model binding doesn't find anything in the request... it'll be left at default (not exception)
        //       so it's important to validate those parameters. (user input)
        [HttpPost("/test")]
        //  public ContentResult AddSample([FromBody] List<testingClass> accountk2j)
         // public ContentResult AddSample(List<testingClass> accountk2j)


       // [HttpPost]
        public async Task<IActionResult> AddRoundAsync(List<testingClass> accountk2j)
        {

         
            string connString = this.Configuration.GetConnectionString("RPS-DB-Connection");

          //   Connection repository = new Connection(connString);
           // repository.SaveToDb(accountk2j[0].CustomerId, accountk2j[0].Fname, accountk2j[0].Lname, accountk2j[0].StreetAddress, accountk2j[0].City, accountk2j[0].State, accountk2j[0].items.ToList);

            List<ShoppingCart> fd = new();
            // fd = accountk2j[0].items;

            for (int i = 0; i < accountk2j[0].items.Length; i++)
            {
               
             fd.Add(new(Convert.ToInt32(accountk2j[0].items[i].itemId), accountk2j[0].items[i].itemNum, accountk2j[0].items[i].itemName, accountk2j[0].items[i].location, accountk2j[0].items[i].cost, accountk2j[0].items[i].Quantity));
                
            }
            Connection repository = new Connection(connString);
             repository.SaveToDb(accountk2j[0].CustomerId, accountk2j[0].Fname, accountk2j[0].Lname, accountk2j[0].StreetAddress, accountk2j[0].City, accountk2j[0].State, fd);

        

            // good practice with POST, return a representation of the created resource in the body.
            return new ContentResult()
            {
                StatusCode = StatusCodes.Status201Created,
                ContentType = "application/json"
                
            };
        }
    }
}
