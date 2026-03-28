using System.Text;
using ApiTests.Core;
using ApiTests.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ApiTests.Tests;

[TestFixture]
public class ClientApiTests : ApiTestBase
{
    [Test]
    public async Task CreateClient()
    {
        var requestBody = new ClientRequest
        {
            Name = "Denys",
            Email = "denys@test.com",
            Balance = 100
        };
        
        var json = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await Client.PostAsync(Settings.ClientEndpoint, content);
        
        Assert.That((int)response.StatusCode, Is.EqualTo(200));
    }

    [Test]
    public async Task CreateClient_WithValidData_ReturnsResponseMatchingRequest()
    {
        var requestBody = new ClientRequest
        {
            Name = "Denys",
            Email = "denys@test.com",
            Balance = 100
        };

        var json = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await Client.PostAsync(Settings.ClientEndpoint, content);
        var responseBody = await response.Content.ReadAsStringAsync();

        var clientResponse = JsonConvert.DeserializeObject<ClientResponse>(responseBody);

        Assert.That(clientResponse, Is.Not.Null);

        Assert.Multiple(() =>
        {
            Assert.That(clientResponse!.Name, Is.EqualTo(requestBody.Name));
            Assert.That(clientResponse.Email, Is.EqualTo(requestBody.Email));
            Assert.That(clientResponse.Balance, Is.EqualTo(requestBody.Balance));
        });
    }
    
    [Test]
    public async Task CreateClient_WithValidData_ReturnsResponseWithId()
    {
        var requestBody = new ClientRequest
        {
            Name = "Test User",
            Email = "testuser@test.com",
            Balance = 50
        };

        var json = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await Client.PostAsync(Settings.ClientEndpoint, content);
        var responseBody = await response.Content.ReadAsStringAsync();

        var clientResponse = JsonConvert.DeserializeObject<ClientResponse>(responseBody);

        Assert.That(clientResponse, Is.Not.Null);
        Assert.That(clientResponse!.Id, Is.GreaterThanOrEqualTo(0));
    }
}