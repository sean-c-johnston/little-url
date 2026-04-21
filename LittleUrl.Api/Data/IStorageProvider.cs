namespace LittleUrl.Api.Data;

public interface IStorageProvider
{
    void Insert(string shortCode, string url);
}