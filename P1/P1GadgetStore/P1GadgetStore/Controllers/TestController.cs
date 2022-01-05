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
        private static readonly List<int> s_samples = new() { 12 };

        // [Route] works for all http methods(verbs)
        // [HttpGet], [HttpPost], etc - to also limit it to a specific method.

        // the job of an action method is to handle one set of requests
        // and return some "result" which asp.net will turn into the response
        [HttpGet("/GetAllItems")] // c# supports multiple attributes (same or different type)
                  // public async Task<ContentResult> GetSamples()
        public ContentResult GetItems()

        {
            // IEnumerable<MyData> result;
            Inventory inventory = new Inventory();
            List<MyData> result = inventory.GetAllInventory();

            // asp.net provides a bunch of data types under the IActionResult interface
            // and/or the ActionResult abstract base class.
            // the job of an action result is to deserialize itself into an http response.
            // a basic one we can start with is ContentResult.
            // good for when you have something to put in the response body.
            // (otherwise... maybe StatusCodeResult)


            // Account acct = new Account();
            //  List<Account> accinfo = acct.getCustomerInfo("paul");

           // List<testingClass> mylist = new List<testingClass>();
            // mylist.Add(new("sfsf","fre"));






            // string json = JsonSerializer.Serialize(result);
          //  string json = JsonSerializer.Serialize(mylist);
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
        public  ContentResult GetPeople(string id)
        {





            Account acct = new Account();
            List<Account> accinfo =  acct.getCustomerInfo(id);




         
            var json =  Newtonsoft.Json.JsonConvert.SerializeObject(accinfo);


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
        public ContentResult AddSample([FromBody] int sample)
        {
            // this is bad... List is NOT threadsafe. (use ConcurrentList iirc)
            s_samples.Add(sample);
            string json = JsonSerializer.Serialize(sample);

            // good practice with POST, return a representation of the created resource in the body.
            return new ContentResult()
            {
                StatusCode = StatusCodes.Status201Created,
                ContentType = "application/json",
                Content = json
            };
        }
    }
}
