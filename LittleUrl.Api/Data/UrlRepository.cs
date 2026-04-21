namespace LittleUrl.Api.Data;

public class UrlRepository : IUrlRepository
{
    public void Add(string shortCode, string url)
    {
        throw new NotImplementedException();
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