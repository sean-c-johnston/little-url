namespace LittleUrl.Api.Data;

public class UrlRepository : IUrlRepository
{
    private readonly IStorageProvider _storageProvider;

    public UrlRepository(IStorageProvider storageProvider)
    {
        _storageProvider = storageProvider;
    }

    public void Add(string shortCode, string url)
    {
        _storageProvider.Insert(shortCode, url);
    }

    public string Get(string shortCode)
    {
        throw new NotImplementedException();
    }
}

public interface IUrlRepository
{
    void Add(string shortCode, string url);
    string Get(string shortCode);
}