using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace LittleUrl.Tests.Integration;

public class CreateEndpoint : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CreateEndpoint(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateAShortUrl()
    {
        var data = new
        {
            Url = "www.google.com"
        };
        var content = new StringContent(JsonSerializer.Serialize(data));
        
        var response = await _client.PostAsync("/shorten", content);

        response.EnsureSuccessStatusCode();
    }
}