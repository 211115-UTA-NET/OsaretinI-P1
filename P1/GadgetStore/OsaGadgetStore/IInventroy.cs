using System;
namespace OsaGadgetStore
{
    public interface IInventroy
    {
        public List<Inventory> getInventoryOrderHistory(string name);
        public List<MyData> GetAllInventory();
        public string GetItemName();

        public double getCost();

        public int getQuantity();

        public string getTime();
        
    }
}

