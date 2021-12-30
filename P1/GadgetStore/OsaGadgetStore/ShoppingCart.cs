using System;
namespace OsaGadgetStore
{
    public class ShoppingCart : Shop
    {
        private string itemName;
        private int itemId;
        private int itemNum;
        private string location;
        private double cost;
        private int Quantity;

        public ShoppingCart(int itemId, int itemNum, string itemName,  string location, double cost, int Quatity)
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
            price = price+price;
            return price;
        }
    }
}

