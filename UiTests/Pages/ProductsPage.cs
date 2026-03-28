using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UiTests.Models;
using System.Globalization;

namespace UiTests.Pages;

public class ProductsPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public ProductsPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public void SortByPriceHighToLow()
    {
        var select = new SelectElement(_driver.FindElement(By.ClassName("product_sort_container")));
        select.SelectByText("Price (high to low)");
    }

    public Product GetProductFromInventory(string productName)
    {
        var items = _driver.FindElements(By.ClassName("inventory_item"));

        foreach (var item in items)
        {
            var name = item.FindElement(By.ClassName("inventory_item_name")).Text.Trim();
            if (name == productName)
            {
                var priceText = item.FindElement(By.ClassName("inventory_item_price"))
                    .Text.Replace("$", "").Trim();

                return new Product
                {
                    Name = name,
                    Price = decimal.Parse(priceText, CultureInfo.InvariantCulture)
                };
            }
        }

        throw new NoSuchElementException($"Product '{productName}' not found.");
    }

    public void OpenProductDetails(string productName)
    {
        var items = _driver.FindElements(By.ClassName("inventory_item"));

        foreach (var item in items)
        {
            var name = item.FindElement(By.ClassName("inventory_item_name")).Text.Trim();
            if (name == productName)
            {
                item.FindElement(By.ClassName("inventory_item_name")).Click();

                _wait.Until(d => d.Url.Contains("inventory-item.html"));
                return;
            }
        }

        throw new NoSuchElementException($"Product '{productName}' not found.");
    }

    public int GetCartBadgeCount()
    {
        var badge = _wait.Until(
            ExpectedConditions.ElementIsVisible(By.ClassName("shopping_cart_badge")));

        return int.Parse(badge.Text);
    }

    public void OpenCart()
    {
        _driver.FindElement(By.ClassName("shopping_cart_link")).Click();
    }
}