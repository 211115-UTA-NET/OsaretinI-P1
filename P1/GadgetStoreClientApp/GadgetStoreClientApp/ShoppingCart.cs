using System;
using Newtonsoft.Json;

namespace GadgetStoreClientApp
{
    public class ShoppingCart
    {
        [JsonProperty]

        public string itemName { get; set; }
        [JsonProperty]

        public int itemId { get; set; }
        [JsonProperty]

        public int itemNum { get; set; }
        [JsonProperty]

        public string location { get; set; }
        [JsonProperty]

        public double cost { get; set; }
        [JsonProperty]

        public int Quantity { get; set; }

        public ShoppingCart(int itemId, int itemNum, string itemName, string location, double cost, int Quatity)
        {
            this.itemName = itemName;
            this.itemNum = itemNum;
            this.itemId = itemId;
            this.location = location;
            this.cost = cost;
            this.Quantity = Quatity;
        }
        public ShoppingCart(int itemId, int itemNum, string itemName, string location, double cost, int Quatity,string Fname, string Lname)
        {
            this.itemName = itemName;
            this.itemNum = itemNum;
            this.itemId = itemId;
            this.location = location;
            this.cost = cost;
            this.Quantity = Quatity;
        }
        public ShoppingCart()
        {

        }
        public string getName()
        {
            return itemName;
        }
        public double getPrice()
        {
            return cost;
        }
        public string getLocation()
        {
            return location;
        }
        public int getQuatity()
        {
            return Quantity;
        }
        public int getItemId()
        {
            return itemId;
        }

        public int getItemNum()
        {
            return itemNum;
        }

        public double setTotalPricePerItem(double price)
        {
            price = price + price;
            return price;
        }

        public bool checkQuantitiy(int itemnum, int quantity, List<jsonData> items)
        {
            int currentStock = items[itemnum].quantity;
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
    }
}

