using Xunit;
using Moq;
using Moq.AutoMock;
using Autofac;
using Autofac.Extras.Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OsaGadgetStore.Test;

public class UnitTest1
{
    [Fact]
    public void CheckSettingPrice()
    {

        //arrange
        var cart = new ShoppingCart(2, 3, "Samsung TV", "Tx", 20.00, 4);

        //Act
        //double ans = 198.99;
        double ans = cart.setTotalPricePerItem(10.00);

        //Assert
        Assert.Equal(ans, cart.getPrice());
    }



    [Fact]
    public void LoadCustomer()
    {
       

        // arrange
        string userName = "paul";
        Mock<Account> mockDecider = new();
        Mock<IConn> mockRepo = new();

       // "First Name: " + item.getFName() + " Last Name " + item.getLName() + " Street " + item.getStreetAddress() + " City: " + item.getCity() + " State: " + item.getState())
        List<Account> people = new()
        { //    Expected: ···ame: Paul Last Name Thoms Street 100 Main St City: Hartford S···

            new()
            {
                Fname = "Paul",
                Lname = "Paul",
                StreetAddress = "100 mainst",
                City = "Hartford",
                State = "CT"
            },
           
        };
        mockRepo.Setup(x => x.GetUserInfo(userName)).Returns(people);
        var account = new Account();

        var result = account.getCustomerInfoAsString(userName);
     
        var expected = "First Name: " + people[0].Fname + " Last Name " + people[0].Lname + " Street "+ people[0].StreetAddress + " City: "+ people[0].City +" State: "+people[0].State;

        Assert.Equal(expected: expected, actual: result);

    }

    [Fact]
    public async Task TestHandler()
    {
        var httpClient = new HttpClient(new MockHttpMessHdler());

        var content = await httpClient.GetStringAsync("https://gadgetstore20220110172934.azurewebsites.net/GetAllItems");

        Assert.Equal("httpContent/Message", content);

    }



}
