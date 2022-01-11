using System;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using OsaGadgetStore;

namespace P1GadgetStore
{

	public class testingClass
	{
        public int CustomerId { get; set; }
        [JsonProperty]

        public string Fname { get; set; }
        [JsonProperty]

        public string Lname { get; set; }
        [JsonProperty]

        public string StreetAddress { get; set; }
        [JsonProperty]

        public string City { get; set; }
        [JsonProperty]

        public string State { get; set; }
        [JsonProperty]

        // private List<ShoppingCart> items{ get; set; }
        public ShoppingCart[] items { get; set; }


        //        [{
        //    "name":"name 1",
        //    "address":"address 1",
        //    "age":1
        //{
        //   "name":"name 2",
        // "address":"address 2",
        // "age":2
        //}]
    }
}

