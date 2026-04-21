using FluentAssertions;
using LittleUrl.Api.Domain;

namespace LittleUrl.Tests;

public class UrlShortenerShould
{
    private const string Google = "www.google.com";
    private const string Yahoo = "yahoo.com";
    private readonly UrlShortener _urlShortener;

    public UrlShortenerShould()
    {
        _urlShortener = new UrlShortener(null!);
    }

    [Fact]
    public void ShortenAUrl()
    {
        var shortUrl = _urlShortener.Shorten(Google);
        shortUrl.Length.Should().BeLessThan(Google.Length);
    }
    
    [Fact]
    public void ShortenMultipleUrls()
    {
        var googleShortcode = _urlShortener.Shorten(Google);
        var yahooShortcode = _urlShortener.Shorten(Yahoo);
        
        googleShortcode.Should().NotBe(yahooShortcode);
    }
}