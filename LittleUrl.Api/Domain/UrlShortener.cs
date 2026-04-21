using System.Text;
using Fnv1a;
using LittleUrl.Api.Data;

namespace LittleUrl.Api.Domain;

public class UrlShortener
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

    public string Resolve(string shortCode)
    {
        return _urlRepository.Get(shortCode);
    }
}

public class UrlHashing
{
    private readonly Fnv1a32 _hashing = new();

    public string GenerateHash(string input)
    {
        _hashing.Append(Encoding.UTF8.GetBytes(input));
        return BitConverter.ToInt32(_hashing.GetCurrentHash(), 0).ToString();
    }
}