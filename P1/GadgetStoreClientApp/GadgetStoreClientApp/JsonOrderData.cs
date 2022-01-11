using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadgetStoreClientApp
{
    public class JsonOrderData
    {
        public string itemName { get; set; }
        public double cost { get; set; }
        public int Quatity { get; set; }
        public string time { get; set; }
        public JsonOrderData(string itemName, double cost, int Quatity, string time)
        {
            this.itemName = itemName;
            this.cost = cost;
            this.Quatity = Quatity;
            this.time = time;

            //  this.cost = cost;
            //  this.location = location;
        }
    }
}
