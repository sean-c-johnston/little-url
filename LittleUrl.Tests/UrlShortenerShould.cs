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
        shortUrl.Should().NotBe(Google);
    }
    
    [Fact]
    public void ShortenMultipleUrls()
    {
        var googleShortcode = _urlShortener.Shorten(Google);
        var yahooShortcode = _urlShortener.Shorten(Yahoo);
        
        googleShortcode.Should().NotBe(yahooShortcode);
    }

    [Fact]
    public void ShortenTheSameUrlConsistently()
    {
        var googleShortcode1 = _urlShortener.Shorten(Google);
        var googleShortcode2 = _urlShortener.Shorten(Google);
        
        googleShortcode1.Should().Be(googleShortcode2);
    }

    [Fact]
    public void ShortenMultipleUrlsOfSameLengthDifferently()
    {
        var shortcode1 = _urlShortener.Shorten("www.123.com");
        var shortcode2 = _urlShortener.Shorten("www.456.com");

        shortcode1.Should().NotBe(shortcode2);
    }
    
    // todo
    // humanized short urls like 'quick-hyper-eggplant' (giphy etc)
}