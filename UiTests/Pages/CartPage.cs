using OpenQA.Selenium;
using UiTests.Models;

namespace UiTests.Pages;

public class CartPage
{
    private readonly IWebDriver _driver;
    
    public CartPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public Product GetCartProduct()
    {
        var name = _driver.FindElement(By.ClassName("inventory_item_name")).Text.Trim();
        var priceText = _driver.FindElement(By.ClassName("inventory_item_price"))
            .Text.Replace("$", "").Trim();

        return new Product
        {
            Name = name,
            Price = decimal.Parse(priceText, System.Globalization.CultureInfo.InvariantCulture)
        };
    }
}