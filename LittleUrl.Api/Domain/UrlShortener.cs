using LittleUrl.Api.Data;

namespace LittleUrl.Api.Domain;

public class UrlShortener
{
    private readonly UrlRepository _urlRepository;

    public UrlShortener(UrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public string Shorten(string originalUrl)
    {
        return originalUrl.Length.ToString();
    }

    public object Get(object shortCode)
    {
        throw new NotImplementedException();
    }
}