using System;
namespace OsaGadgetStore
{
    public class ShoppingCart 
    {
        public string itemName;
        public int itemId;
        public int itemNum;
        public string location;
        public double cost;
        public int Quantity;

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

