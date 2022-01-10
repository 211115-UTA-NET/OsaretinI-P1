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


        //public Accountk2[] Accountk2 { get; set; }

        //public string Accountk2 { get; set; }

        //  public string CustomerId { get; set; }

        // public string Fname { get; set; }

        //  public string Lname { get; set; }

        //   public string StreetAddress { get; set; }

        //  public string City { get; set; }

        //public string State { get; set; }

        //public List<ShoppingCart> items { get; set; }
        // public string name { get; set; }
        // public string address { get; set; }

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

