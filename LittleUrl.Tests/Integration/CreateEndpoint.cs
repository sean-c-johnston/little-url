using System.Text.Json;
using FluentAssertions;
using LittleUrl.Api.Contracts;
using LittleUrl.Api.Core;
using LittleUrl.Api.Domain;
using Microsoft.AspNetCore.Mvc.Testing;

namespace LittleUrl.Tests.Integration;

public class CreateEndpoint : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    private const string Google = "www.google.com";
    private readonly string _googleShortcode;

    public CreateEndpoint(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _googleShortcode = new UrlHashing().GenerateHash(Google);
    }

    [Fact]
    public async Task ReturnTheCreatedUrl()
    {
        var client = _factory.CreateClient();

        var content = BuildRequestFrom(new CreateShortUrl("www.google.com"));

        var response = await client.PostAsync("/url/create", content).StringContent();

        response.Should().Be(_googleShortcode);
    }

    [Fact]
    public async Task ResolveAUrlThatExists()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/hellothere");
        
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Redirect);
    }

    private static StringContent BuildRequestFrom(CreateShortUrl data)
    {
        var content = new StringContent(JsonSerializer.Serialize(data));
        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        return content;
    }
}