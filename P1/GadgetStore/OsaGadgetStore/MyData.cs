using System;
using Newtonsoft.Json;

namespace OsaGadgetStore
{
    public class MyData
    {
        [JsonProperty]
        private string itemName { get; set; }
        [JsonProperty]
        private string location;
        [JsonProperty]
        private double price;
        [JsonProperty]
        private int quantity;
        [JsonProperty]
        private int itemId;


        public MyData(int itemId, string itemName, string itemLocation, double price, int quantity)
        {
            this.location = itemLocation;
            this.itemName = itemName;
            this.price = price;
            this.quantity = quantity;
            this.itemId = itemId;

            //  this.cost = cost;
            //  this.location = location;
        }

        public string getName()
        {
            return itemName;
        }
        public double getPrice()
        {
            return price;
        }
        public string getLocation()
        {
            return location;
        }
        public int getQuatity()
        {
            return quantity;
        }
        public int getItemId()
        {
            return itemId;
        }
        public void setNewQuantity(int newQuantity)
        {
            quantity = newQuantity;
        }
    }
}