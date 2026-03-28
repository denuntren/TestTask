using ApiTests.Config;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace ApiTests.Core;

public abstract class ApiTestBase
{
    protected HttpClient Client = null!;
    protected ApiSettings Settings = null!;

    [SetUp]
    public void BaseSetUp()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(TestContext.CurrentContext.TestDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();
        
        Settings = config.GetSection("ApiSettings").Get<ApiSettings>()!;
        
        Client = new HttpClient
        {
            BaseAddress = new Uri(Settings.BaseUrl)
        };
    }
    
    [TearDown]
    public void BaseTearDown()
    {
        Client.Dispose();
    }
}