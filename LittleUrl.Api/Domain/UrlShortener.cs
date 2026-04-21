using System.Text;
using Fnv1a;
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
        return new UrlHashing().GenerateHash(originalUrl);
    }

    public object Get(object shortCode)
    {
        throw new NotImplementedException();
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