using OsaGadgetStore;

namespace OsaGadgetStore
{
    public class Program
    {
        // separate parts of the code that have their own distinct purposes
        // from each other

        // five design principles: SOLID
        // S: single responsibility principle
        //   each class should have "one responsibility" (not several)
        //   each class should have "one reason to change"
        // we can apply the same idea at many scales: variable, method, project, apps/deployments

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Gadget Store");

            Console.WriteLine("Type 1 to shop, Type 2 to search  by name");
            string? response = Console.ReadLine();

            try
                {

                if (string.IsNullOrWhiteSpace(response))
                {
                    throw new ArgumentException();
                }
            }
                catch (Exception)
            {
                Console.WriteLine("Invalid Input");
                return;
            }


            if (response == "2")
            {


                
                Console.WriteLine("Enter Customer First Name and press enter");
                string cusName = Console.ReadLine();
                Console.WriteLine("Press 1 to view customer info, Press 2 to view order history");

            
                    response = Console.ReadLine();
                try
                {

                    if (string.IsNullOrWhiteSpace(response))
                    {
                        throw new ArgumentException();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input");
                    return;
                }

                if (response == "1")
                {
                    Account acct = new Account();


                    List<Account> accinfo = acct.getCustomerInfo(cusName);



                    foreach (var item in accinfo)
                    {
                        Console.WriteLine("Your Customer Info");
                        Console.WriteLine("First Name: " + item.getFName() + " Last Name " + item.getLName() + " Street " + item.getStreetAddress() + " City: " + item.getCity() + " State: " + item.getState());
                    }
                }
                else if (response == "2")
                {
                    Console.WriteLine("Your Order History");
                    Inventory acct = new Inventory();
                    List<Inventory> accinfo = acct.getInventoryOrderHistory(cusName);
                    //itemName, Cost, Quantity
                    foreach (var item in accinfo)
                    {
                        Console.WriteLine("ItemName: " + item.GetItemName() + " Cost " + item.getCost() + " Qunatity " + item.getQuantity()+ " Time "+item.getTime());
                    }
                }
            }
            else if (response == "1")
            {
                Inventory inventory = new Inventory();
                List<MyData> result = inventory.GetAllInventory();


                List<ShoppingCart> cart = new();
                Random ran = new Random();
                int RandomitemNumber = ran.Next(1, 9999);
                //add to cart
                bool breakloop = false;
                while (breakloop == false)
                {
                    int i = 1;
                    Console.WriteLine("Current Inventory");

                    foreach (var item in result)
                    {
                        Console.WriteLine("Item#: " + i + " " + item.getName() + " Price: $" + item.getPrice() + " Location: " + item.getLocation() + " Quatity: " + item.getQuatity());
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

                    if (inventory.checkQuantitiy(itemNum, quatity, result))
                    {
                        //double TotalPricePerItem = cart[itemNum].setTotalPricePerItem(result[itemNum].getPrice());
                        double TotalPricePerItem = result[itemNum].getPrice() * quatity;
                        int itemIdnum = itemNum + 1;
                        cart.Add(new(RandomitemNumber, itemIdnum, result[itemNum].getName(), result[itemNum].getLocation(), TotalPricePerItem, quatity));
                        Console.WriteLine("Added to Shopping Cart");


                    }
                    else
                        Console.WriteLine("quatity not in stock. ");

                    Console.WriteLine("Type 1 to continue or type done to complete");
                    if (Console.ReadLine().ToString() == "done")
                        breakloop = true;
                }

                breakloop = false;
                while (breakloop == false)
                    if (cart.Count != 0)
                    {
                        Console.WriteLine("Type 1 to view your shopping cart, or type 2 to checkout ");
                        string ans = Console.ReadLine().ToString();
                        if (ans == "1")
                        {
                            foreach (var item in cart)
                            {
                                Console.WriteLine("Your Shopping Cart");
                                Console.WriteLine("Item#: " + item.getItemId() + " " + item.getName() + " Price: $" + item.getPrice() + " Location: " + item.getLocation() + " Quatity: " + item.getQuatity());
                            }
                        }

                        Console.WriteLine("Type 1 to checkout or 2 to Exit");
                        if (Console.ReadLine().ToString() == "1")
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

                            Account user = new Account(RandomitemNumber,fName, lName, StreetAddress, City, State, cart);

                            user.AccountSave();
                            Console.WriteLine("Order Completed GoodBye");
                            breakloop = true;

                        }
                        else
                        {
                            Console.WriteLine("GoodBye");
                            breakloop = true;

                        }

                    }
            }



        }
    }
}
