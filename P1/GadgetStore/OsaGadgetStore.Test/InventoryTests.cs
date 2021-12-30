using Xunit;

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
}
