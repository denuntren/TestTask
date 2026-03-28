using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UiTests.Core;

public static class DriverFactory
{
    public static IWebDriver Create(string browser)
    {
        var options = new ChromeOptions();

        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-infobars");
        options.AddArgument("--incognito");
        options.AddArgument("--guest");
        options.AddArgument("--disable-features=PasswordLeakDetection,PasswordCheck,AutofillServerCommunication");
        options.AddArgument("--no-first-run");
        options.AddArgument("--no-default-browser-check");
        options.AddArgument("--disable-popup-blocking");

        options.AddExcludedArgument("enable-automation");
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

        return new ChromeDriver(options);
    }
}