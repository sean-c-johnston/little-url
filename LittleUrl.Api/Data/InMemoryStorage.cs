namespace LittleUrl.Api.Data;

public class InMemoryStorage : IStorageProvider
{
    private readonly Dictionary<string, string> _urls = new();
    
    public void Insert(string shortCode, string url)
    {
        _urls[shortCode] = url;
    }

    public string? Get(string shortCode)
    {
        return _urls.GetValueOrDefault(shortCode);
    }
}