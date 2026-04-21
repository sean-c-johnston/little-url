using FluentAssertions;
using LittleUrl.Api.Data;
using LittleUrl.Api.Domain;

namespace LittleUrl.Tests.Features;

public class CreateLittleUrl
{
    [Fact]
    public void CreateAUrl()
    {
        const string originalUrl = "www.google.com";

        var urlRepository = new UrlRepository();
        var urlShortener = new UrlShortener(urlRepository);
        
        var shortCode = urlShortener.Shorten(originalUrl);

        var result = urlShortener.Get(shortCode);
        
        result.Should().Be(originalUrl);
    }
}