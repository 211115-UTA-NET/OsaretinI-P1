using System;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
namespace GadgetStoreClientApp
{
    public class jsonData
    {
        public string itemName { get; set; }
        public string location { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public int itemId { get; set; }

        public jsonData(int itemId, string itemName, string location, double price, int quantity)
        {
            this.location = location;
            this.itemName = itemName;
            this.price = price;
            this.quantity = quantity;
            this.itemId = itemId;

            //  this.cost = cost;
            //  this.location = location;
        }
        public void setNewQuantity(int newQuantity)
        {
            quantity = newQuantity;
        }


      
    }
}

