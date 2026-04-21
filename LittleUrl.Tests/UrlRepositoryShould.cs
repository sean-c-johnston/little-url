using LittleUrl.Api.Data;
using NSubstitute;

namespace LittleUrl.Tests;

public class UrlRepositoryShould
{
    [Fact]
    public void AddAUrl()
    {
        var mockStorage = Substitute.For<IStorageProvider>();
        var urlRepository = new UrlRepository(mockStorage);
        urlRepository.Add("short-code", "www.google.com");
        
        mockStorage.Received(1).Insert("short-code", "www.google.com");
    }
}