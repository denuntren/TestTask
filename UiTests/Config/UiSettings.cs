namespace UiTests.Config;

public class UiSettings
{
    public string BaseUrl { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Browser { get; set; } = "chrome";
    public int ImplicitWaitSeconds { get; set; }
    public string TargetProductName { get; set; } = string.Empty;
}