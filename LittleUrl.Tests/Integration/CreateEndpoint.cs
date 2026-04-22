using System.Text.Json;
using FluentAssertions;
using LittleUrl.Api.Domain;
using Microsoft.AspNetCore.Mvc.Testing;

namespace LittleUrl.Tests.Integration;

public class CreateEndpoint : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public CreateEndpoint(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ReturnTheCreatedUrl()
    {
        var client = _factory.CreateClient();
        
        var data = new
        {
            Url = "www.google.com"
        };
        var content = new StringContent(JsonSerializer.Serialize(data));
        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        
        var response = await client.PostAsync("/url/create", content);
        var responseContent = await response.Content.ReadAsStringAsync();
        
        var expected = new UrlHashing().GenerateHash(data.Url);
        responseContent.Should().Be(expected);
    }
}