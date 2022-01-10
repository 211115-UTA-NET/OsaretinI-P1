using System;
namespace GadgetStoreClientApp
{
    public class SubmittedMove
    {
        public string? name { get; set; }
        public string? address { get; set; }


        public SubmittedMove(string n, string j)
        {
            this.name = n;
            this.address = j;
        }
    }

}

