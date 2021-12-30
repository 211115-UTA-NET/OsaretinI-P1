using System;
namespace OsaGadgetStore
{
    public class Shop
    {
      

        public string connectionString = File.ReadAllText("/Users/osaiyen/documents/dbKey.txt");
        public List<Inventory> items
        {
            set { items = value; }
            get { return items; }
        }


        public Shop( )
        {

        }


    }

}

