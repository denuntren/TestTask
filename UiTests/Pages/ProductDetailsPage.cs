using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UiTests.Models;
using System.Globalization;

namespace UiTests.Pages;

public class ProductDetailsPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    
    public ProductDetailsPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public Product GetProduct()
    {
        var name = _wait.Until(d => d.FindElement(By.ClassName("inventory_details_name"))).Text.Trim();
        var priceText = _wait.Until(d => d.FindElement(By.ClassName("inventory_details_price")))
            .Text.Replace("$", "").Trim();

        return new Product
        {
            Name = name,
            Price = decimal.Parse(priceText, CultureInfo.InvariantCulture)
        };
    }

    public void AddToCart()
    {
        var button = _wait.Until(d => d.FindElement(By.CssSelector("button.btn_inventory")));
        button.Click();

        _wait.Until(d => d.FindElement(By.CssSelector("button.btn_inventory")).Text.Contains("Remove"));
    }

    public int GetCartBadgeCount()
    {
        var badge = _wait.Until(d => d.FindElement(By.ClassName("shopping_cart_badge")));
        return int.Parse(badge.Text);
    }

    public void OpenCart()
    {
        _wait.Until(d => d.FindElement(By.ClassName("shopping_cart_link"))).Click();
    }
}