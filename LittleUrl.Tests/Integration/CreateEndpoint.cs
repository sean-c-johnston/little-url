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

    private const string GoogleUrl = "www.google.com";
    private readonly string _googleShortcode;

    public CreateEndpoint(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _googleShortcode = new UrlHashing().GenerateHash(GoogleUrl);
    }

    [Fact]
    public async Task ReturnTheCreatedUrl()
    {
        var client = _factory.CreateClient();

        var response = await SendCreateUrlRequest(GoogleUrl, client).StringContent();

        response.Should().Be(_googleShortcode);
    }

    [Fact]
    public async Task ResolveAUrlThatExists()
    {
        var client = _factory.CreateClient();
        await SendCreateUrlRequest(GoogleUrl, client);
        
        var response = await client.GetAsync($"/{_googleShortcode}");
        
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Redirect);
    }

    [Fact]
    public async Task NotResolveAUrlThatDoesNotExist()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/does-not-exist");
        
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    private static async Task<HttpResponseMessage> SendCreateUrlRequest(string url, HttpClient client)
    {
        var req = BuildRequestContent(new CreateShortUrl(url));
        return await client.PostAsync("/url/create", req);
    }

    private static StringContent BuildRequestContent(CreateShortUrl data)
    {
        var content = new StringContent(JsonSerializer.Serialize(data));
        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        return content;
    }
}