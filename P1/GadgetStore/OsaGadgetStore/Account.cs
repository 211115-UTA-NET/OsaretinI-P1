using System;
using Newtonsoft.Json;

namespace OsaGadgetStore
{
    public class Account
    {

        public int CustomerId;
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
   

        private List<ShoppingCart> items;


         private string connectionString = File.ReadAllText("C:/dbKey.txt");
             //    private string connectionString;

        public Account(string connectionString)
        {
           // this.connectionString = connectionString;
        }
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
        public string getCustomerInfoAsString(string name)
        {
            Connection repository = new Connection(connectionString);
            List<Account> allRecords = repository.GetUserInfo(name);
            string text = "";
           
                 text =  "First Name: " + allRecords[0].getFName() + " Last Name " + allRecords[0].getLName() + " Street " + allRecords[0].getStreetAddress() + " City: " + allRecords[0].getCity() + " State: " + allRecords[0].getState();
            

           // text = text.Replace("@", "" + System.Environment.NewLine);

            return text;
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