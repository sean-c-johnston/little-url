using LittleUrl.Api.Data;

namespace LittleUrl.Api.Domain;

public interface IUrlShortener
{
    string Shorten(string originalUrl);
    string? Resolve(string shortCode);
}

public class UrlShortener : IUrlShortener
{
    private readonly IUrlRepository _urlRepository;

    public UrlShortener(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public string Shorten(string originalUrl)
    {
        var shortCode = new UrlHashing().GenerateHash(originalUrl);
        _urlRepository.Add(shortCode, originalUrl);
        return shortCode;
    }

    public string? Resolve(string shortCode)
    {
        return _urlRepository.Get(shortCode);
    }
}