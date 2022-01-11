//1/9/22
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace GadgetStoreClientApp
{
    public class Program
    {

        public async static Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("Welcome to Gadget Store");

            Console.WriteLine("Type 1 to shop, Type 2 to search  by name");
            string? res = Console.ReadLine();

            if (res == "1")
            {
               
                List<ShoppingCart> cartList = new();
                ShoppingCart cart = new ShoppingCart();
                HttpResponseMessage response = await client.GetAsync("https://gadgetstore20220110172934.azurewebsites.net/GetAllItems");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();


                List<jsonData> result = JsonConvert.DeserializeObject<List<jsonData>>(responseBody);
                //add to cart
                bool breakloop = false;
                while (breakloop == false)
                {
                    int i = 1;
                    Console.WriteLine("Current Inventory");
                    //display inventory
                    foreach (var item in result)
                    {
                        Console.WriteLine("Item#: " + i + " " + item.itemName + " Price: $" + item.price + " Location: " + item.location + " Quatity: " + item.quantity);
                        i++;
                    }

                    Console.WriteLine("Enter item# to add to cart. type DONE to complete");
                    string ans = Console.ReadLine();
                    int itemNum = 0;
                    if (ans == "done")
                        breakloop = true;
                    else
                    {
                        itemNum = Convert.ToInt32(ans);
                        itemNum--;
                    }
                    Console.WriteLine("Enter Quantity. Press Enter when done");
                    int quatity = Convert.ToInt32(Console.ReadLine());
                    Random ran = new Random();
                    int RandomitemNumber = ran.Next(1, 9999);
                    if (cart.checkQuantitiy(itemNum, quatity, result))
                    {
                        //double TotalPricePerItem = cart[itemNum].setTotalPricePerItem(result[itemNum].getPrice());
                        double TotalPricePerItem = result[itemNum].price * quatity;
                        int itemIdnum = itemNum + 1;

                        cartList.Add(new(RandomitemNumber, itemIdnum, result[itemNum].itemName, result[itemNum].location, TotalPricePerItem, quatity));
                        Console.WriteLine("Added to Shopping Cart");
                    }
                    else
                        Console.WriteLine("quatity not in stock. ");

                    Console.WriteLine("Type 1 to continue or type done to complete");
                    if (Console.ReadLine().ToString() == "done")
                    {
                        breakloop = true;



                        Console.WriteLine("Enter your first Name");
                        string fName = Console.ReadLine().ToString();
                        Console.WriteLine("Enter your Last Name");
                        string lName = Console.ReadLine().ToString();
                        Console.WriteLine("Enter your Street Address");
                        string StreetAddress = Console.ReadLine().ToString();
                        Console.WriteLine("Enter your City");
                        string City = Console.ReadLine().ToString();
                        Console.WriteLine("Enter your State");
                        string State = Console.ReadLine().ToString();



                        Account user = new Account(RandomitemNumber, fName, lName, StreetAddress, City, State, cartList);

                        var json = Newtonsoft.Json.JsonConvert.SerializeObject(user);



                        List<Account> fd = new();
                        fd.Add(new(RandomitemNumber, fName, lName, StreetAddress, City, State, cartList));



                        var url = "https://gadgetstore20220110172934.azurewebsites.net/test";
                        var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                        httpRequest.Method = "POST";

                        httpRequest.Headers["Authorization"] = "Bearer tr";
                        httpRequest.ContentType = "application/json";

                        var jsonF = Newtonsoft.Json.JsonConvert.SerializeObject(fd);


                        using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                        {
                            streamWriter.Write(jsonF);
                        }

                        var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var r2esult = streamReader.ReadToEnd();
                        }

                        Console.WriteLine(httpResponse.StatusCode);

                    }

                }

            }

            else if (res == "2")
            {
                Console.WriteLine("Enter Customer First Name and press enter");
                string cusName = Console.ReadLine();
                Console.WriteLine("Press 1 to view customer info, Press 2 to view order history");
                res = Console.ReadLine();
                try
                {

                    if (string.IsNullOrWhiteSpace(res))
                    {
                        throw new ArgumentException();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input");
                    return;
                }

                if (res == "1")
                {


                    HttpResponseMessage response = await client.GetAsync("https://gadgetstore20220110172934.azurewebsites.net/GetOrderByName/" + cusName);

                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();




                    List<Account> result = JsonConvert.DeserializeObject<List<Account>>(responseBody);

                    foreach (var item in result)
                    {
                        Console.WriteLine("Your Customer Info");
                        Console.WriteLine("First Name: " + item.Fname + " Last Name " + item.Lname+ " Street " + item.StreetAddress + " City: " + item.City + " State: " + item.State);
                    }
                }
                else if (res == "2")
                {
              
                   HttpResponseMessage response = await client.GetAsync("https://gadgetstore20220110172934.azurewebsites.net/GetOrderHistory/" + cusName);

                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();


                    List<JsonOrderData> result = JsonConvert.DeserializeObject<List<JsonOrderData>>(responseBody);
                    Console.WriteLine("Your Order History");

                    //display inventory
                    int i = 0;
                    foreach (var item in result)
                    {
                        Console.WriteLine("Item#: " + i + " " + item.itemName + " Price: $" + item.cost + " Location: "  + " Quatity: " + item.Quatity);
                        i++;
                    }
                }

                else
                {
                    Console.WriteLine("invalid input ");
                }
            }



        }
    }
}