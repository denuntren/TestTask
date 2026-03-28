using OpenQA.Selenium;

namespace UiTests.Pages;

public class LoginPage
{
    private readonly  IWebDriver _driver;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void Open(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }
    
    public void Login(string username, string password)
    {
        var usernameField = _driver.FindElement(By.Id("user-name"));
        var passwordField = _driver.FindElement(By.Id("password"));
        var loginButton = _driver.FindElement(By.Id("login-button"));

        usernameField.SendKeys(username);
        passwordField.SendKeys(password);
        loginButton.Click();
    }
}