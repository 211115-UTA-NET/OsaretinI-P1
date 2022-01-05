using System;
using Newtonsoft.Json;

namespace OsaGadgetStore
{
    public class Account
    {

        private int CustomerId;
        [JsonProperty]

        private string Fname;
        [JsonProperty]

        private string Lname;
        [JsonProperty]

        private string StreetAddress;
        [JsonProperty]

        private string City;
        [JsonProperty]

        private string State;
   

        private List<ShoppingCart> items;


                private string connectionString = File.ReadAllText("/Users/osaiyen/documents/dbKey.txt");


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
        public  Account()
        {
        }
        public Account(string Fname, string Lname, string StreetAddress, string City, string State)
        {
            this.Fname = Fname;
            this.Lname = Lname;
            this.StreetAddress = StreetAddress;
            this.City = City;
            this.State = State;
        }
        public void AccountSave()
        {
          
            Connection repository = new Connection(connectionString);
            repository.SaveToDb(CustomerId, Fname, Lname, StreetAddress, City, State, items);
        }


        

            public List<Account> getCustomerInfo(string name)
        {
            Connection repository = new Connection(connectionString);
            List<Account> allRecords = repository.GetUserInfo(name);

            return allRecords;
        }

       

        public string getFName()
        {
            return Fname;
        }
        public string getLName()
        {
            return Lname;
        }
        public string getStreetAddress()
        {
            return StreetAddress;
        }
        public string getCity()
        {
            return City;
        }
        public string getState()
        {
            return State;
        }
    }

}