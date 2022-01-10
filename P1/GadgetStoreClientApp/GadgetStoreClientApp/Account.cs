using System;
using Newtonsoft.Json;

namespace GadgetStoreClientApp
{
    public class Account
    {
        [JsonProperty]

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

        public string State{ get; set; }
        [JsonProperty]

        private List<ShoppingCart> items;


        public Account(int cusId, string Fname, string Lname, string StreetAddress, string City, string State, List<ShoppingCart> items)
        {
            this.CustomerId = cusId;
            this.Fname = Fname;
            this.Lname = Lname;
            this.StreetAddress = StreetAddress;
            this.City = City;
            this.State = State;
            this.items = items;
        }
        public Account(){

        }
    }
}

