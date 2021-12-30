using System;
using System.Data;
using System.Data.SqlClient;
using OsaGadgetStore;
namespace OsaGadgetStore
{
    public class Connection : IConn
    {
        private readonly string connectionString;

        public Connection(string connectionString)
        {
            ///this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            this.connectionString = connectionString;
        }



        public List<MyData> GetAllRoundsOfPlayer()
        {
            List<MyData> result = new();

            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                @"Select *
                from Inventory",
                connection);

            // using (SqlDataReader reader = cmd.ExecuteReader())
            // {
            //     while (reader.Read())
            //     {

            //         Console.WriteLine(String.Format("{0}", reader["FirstName"]));

            //      }
            //  }
            using SqlDataAdapter adapter = new(cmd);
            DataSet dataSet = new();
            adapter.Fill(dataSet);

                connection.Close();

            foreach(DataRow row in dataSet.Tables[0].Rows)
            {
                //Console.WriteLine($"{row["FirstName"]}: \"{row["LastName"]}");
                // Console.WriteLine(row["FirstName"]);
                int itemId = Convert.ToInt32(row["ID"]);
                string? itemName =row["ItemName"].ToString();
                double itemPrice = Convert.ToDouble(row["ItemPrice"]);
                string? itemLocation = row["ItemLocation"].ToString();
                int itemQuantity = Convert.ToInt32(row["ItemQuantity"]);


                result.Add(new(itemId,itemName, itemLocation, itemPrice, itemQuantity));

            }

            return result;
        }


        public void SaveToDb(int cusId, string Fname, string Lname,string StreetAddress, string City, string State, List<ShoppingCart> items)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
          
         
            string query = "SET IDENTITY_INSERT Account ON INSERT INTO Account (ID, FirstName, LastName, StreetAddress, City, State)";
            query += " VALUES (@Id, @fname, @lname, @StreetAddress, @City, @State)";

            SqlCommand myCommand = new SqlCommand(query, connection);

            myCommand.Parameters.AddWithValue("@Id", cusId);
            myCommand.Parameters.AddWithValue("@fname", Fname);
            myCommand.Parameters.AddWithValue("@lname", Lname);
            myCommand.Parameters.AddWithValue("@StreetAddress", StreetAddress);
            myCommand.Parameters.AddWithValue("@City", City);
            myCommand.Parameters.AddWithValue("@State", State);

            myCommand.ExecuteNonQuery();
            Thread.Sleep(2000);


            foreach (var item in items)
               {
                // Console.WriteLine("Item#: " + item.getItemId() + " " + item.getName() + " Price: $" + item.getPrice() + " Location: " + item.getLocation() + " Quatity: " + item.getQuatity());
                string time = DateTime.Now.ToString("HH:mm:ss tt");

                string query2 = "INSERT INTO [Order] (ID, ItemId, Cost, Quantity, Time)";
                query2 += " VALUES (@ID, @ItemId, @Cost, @Quantity, @Time)";

                SqlCommand myCommand2 = new SqlCommand(query2, connection);
                myCommand2.Parameters.AddWithValue("@ID", item.getItemId());
                myCommand2.Parameters.AddWithValue("@ItemId", item.getItemNum());
                myCommand2.Parameters.AddWithValue("@Cost", item.getPrice());
                myCommand2.Parameters.AddWithValue("@Quantity", item.getQuatity());
                myCommand2.Parameters.AddWithValue("@Time", time);

                myCommand2.ExecuteNonQuery();
                Thread.Sleep(2000);
            }




            connection.Close();
        }


        public List<Account> GetUserInfo(string name)
        {
            List<Account> result = new();

            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                @"Select *
                from Account
                where FirstName = @name",
                connection);

            cmd.Parameters.AddWithValue("@name", name);


            using SqlDataAdapter adapter = new(cmd);
            DataSet dataSet = new();
            adapter.Fill(dataSet);

            connection.Close();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
               
                string? cusName = row["FirstName"].ToString();
                string? cusLname = row["FirstName"].ToString();
                string? cusStreetAddress = row["StreetAddress"].ToString();
                string? cusCity = row["City"].ToString();
                string? cusState = row["State"].ToString();

                //double itemPrice = Convert.ToDouble(row["ItemPrice"]);
                // string? itemLocation = row["ItemLocation"].ToString();
                // int itemQuantity = Convert.ToInt32(row["ItemQuantity"]);


                result.Add(new(cusName, cusLname, cusStreetAddress, cusCity, cusState));

            }

            return result;
        }




        public List<Inventory> getInventoryOrderHistory(string name)
        {

            List<Inventory> result = new();

            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                @"Select Inventory.ItemName,[Order].Cost, [Order].Quantity,[Order].Time
                from [Order]
                join Account ON Account.Id =[Order].Id  
                join Inventory ON Inventory.ID =[Order].ItemId
                where FirstName = @name",
                connection);

            cmd.Parameters.AddWithValue("@name", name);


            using SqlDataAdapter adapter = new(cmd);
            DataSet dataSet = new();
            adapter.Fill(dataSet);

            connection.Close();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {

                string? itemName = row["ItemName"].ToString();
                string? Cost = row["Cost"].ToString();
                string? Quantity = row["Quantity"].ToString();
                string? Time = row["Time"].ToString();

                //double itemPrice = Convert.ToDouble(row["ItemPrice"]);
                // string? itemLocation = row["ItemLocation"].ToString();
                // int itemQuantity = Convert.ToInt32(row["ItemQuantity"]);


                result.Add(new(itemName, Cost, Quantity,Time));

            }

            return result;

        }


    }
}

