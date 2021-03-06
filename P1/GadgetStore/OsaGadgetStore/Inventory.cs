using Newtonsoft.Json;
using System;

namespace OsaGadgetStore
{
    public class Inventory:IInventroy
    {
       // public string connectionString = File.ReadAllText("C:/dbKey.txt");

       private string connectionString;
        [JsonProperty]

        private string itemName;

        private string itemId;
        [JsonProperty]

        private string location;
        [JsonProperty]

        private double cost;
        [JsonProperty]

        private int Quatity;
        [JsonProperty]

        private string time;

        public Inventory(string itemName, string itemId)
        {
            this.itemId = itemId;
            this.itemName = itemName;
          //  this.cost = cost;
          //  this.location = location;
        }
        public Inventory()
        {
            
            //  this.cost = cost;
            //  this.location = location;
        }

        public Inventory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Inventory(string itemName, string Cost, string Quantity, string time)
        {
            this.itemName = itemName;
            this.cost = Convert.ToDouble(Cost);
            this.Quatity = Convert.ToInt32(Quantity);
            this.time = time;
        }
        





        public List<Inventory> getInventoryOrderHistory(string name)
        {
            Connection repository = new Connection(connectionString);
            List<Inventory> allRecords = repository.getInventoryOrderHistory(name);

            return allRecords;
        }

        public List<MyData> GetAllInventory()
        {
            //items.Add(itemName, itemId, price);
          //  List<Inventory> items = new List<Inventory>();
           // items = new List<test>();


            Connection repository = new Connection(connectionString);

            List<MyData> allRecords = repository.GetAllRoundsOfPlayer();
         //  items = repository.GetAllRoundsOfPlayer();

            return allRecords;
        }

       

        public bool checkQuantitiy(int itemnum, int quantity, List<MyData> items)
        {
            int currentStock = items[itemnum].getQuatity();
            if (currentStock >= quantity)
            {

                items[itemnum].setNewQuantity(currentStock - quantity);
                return true;
            }
            else
                return false;

            //items.Add(itemName, itemId, price);
            //items.Add(new Inventory(itemName, itemId, price));
        }

        public string GetItemName()
        {
            return itemName;
        }
        public double getCost()
        {
            return cost;
        }
        public int getQuantity()
        {
            return Quatity;
        }
        public string getTime()
        {
            return time;
        }
    }
}

