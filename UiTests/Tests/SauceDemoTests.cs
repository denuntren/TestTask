using NUnit.Framework;
using UiTests.Core;
using UiTests.Pages;

namespace UiTests.Tests;

[TestFixture]
public class SauceDemoTests : TestBase
{
    [Test]
    public void UserValidateBikeLightInCatalogDetailsAndCart()
    {
        var loginPage = new LoginPage(Driver);
        loginPage.Open(Settings.BaseUrl);
        loginPage.Login(Settings.Username, Settings.Password);
        
        var productsPage = new ProductsPage(Driver);
        productsPage.SortByPriceHighToLow();

        var productFromInventory = productsPage.GetProductFromInventory(Settings.TargetProductName);
        productsPage.OpenProductDetails(Settings.TargetProductName);
        
        var detailsPage = new ProductDetailsPage(Driver);
        var productFromDetails = detailsPage.GetProduct();

        Assert.Multiple(() =>
        {
            Assert.That(productFromDetails.Name, Is.EqualTo(productFromInventory.Name));
            Assert.That(productFromDetails.Price, Is.EqualTo(productFromInventory.Price));
        });
        
        detailsPage.AddToCart();
        
        Assert.That(detailsPage.GetCartBadgeCount(), Is.EqualTo(1));
        
        productsPage.OpenCart();
        
        var cartPage = new CartPage(Driver);
        var productFromCart = cartPage.GetCartProduct();
        
        Assert.Multiple(() =>
        {
            Assert.That(productFromCart.Name, Is.EqualTo(productFromInventory.Name));
            Assert.That(productFromCart.Price, Is.EqualTo(productFromInventory.Price));
        });
        
    }

}