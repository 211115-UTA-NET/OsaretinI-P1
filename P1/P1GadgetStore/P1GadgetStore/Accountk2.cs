using System;
using Newtonsoft.Json;

namespace P1GadgetStore
{
	public class Accountk2
    {
        [JsonProperty]

        public string CustomerId;
        [JsonProperty]

        public string Fname;
        [JsonProperty]

        public string Lname;
        [JsonProperty]

        public string StreetAddress;
        [JsonProperty]

        public string City;
        [JsonProperty]

        public string State;
        public Accountk2(string Fname, string Lname, string StreetAddress, string City, string State)
        {
            this.Fname = Fname;
            this.Lname = Lname;
            this.StreetAddress = StreetAddress;
            this.City = City;
            this.State = State;
        }
        [JsonConstructor]
        public Accountk2() { }
    }
}

