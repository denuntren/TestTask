using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using UiTests.Config;

namespace UiTests.Core;

public abstract class TestBase
{
    protected IWebDriver Driver = null!;
    protected UiSettings Settings = null!;

    [SetUp]
    public void BaseSetUp()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(TestContext.CurrentContext.TestDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        Settings = config.GetSection("UiSettings").Get<UiSettings>()!;

        Driver = DriverFactory.Create(Settings.Browser);
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.ImplicitWaitSeconds);
    }

    [TearDown]
    public void BaseTearDown()
    {
        Driver.Quit();
    }
}