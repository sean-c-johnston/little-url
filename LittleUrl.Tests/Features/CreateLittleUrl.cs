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

        var storageProvider = new InMemoryStorage();
        var urlRepository = new UrlRepository(storageProvider);
        var urlShortener = new UrlShortener(urlRepository);
        
        var shortCode = urlShortener.Shorten(originalUrl);

        var result = urlShortener.Resolve(shortCode);
        
        result.Should().Be(originalUrl);
    }
}