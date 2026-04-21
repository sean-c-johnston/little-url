using FluentAssertions;
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
        
        // I don't like mocks in general, but with repository/db access we can't unit test.
        // There'll be an integration test for this later though.
        mockStorage.Received(1).Insert("short-code", "www.google.com");
    }
    
    [Fact]
    public void GetAUrl()
    {
        var mockStorage = Substitute.For<IStorageProvider>();
        
        var urlRepository = new UrlRepository(mockStorage);
        urlRepository.Add("short-code", "www.google.com");
        
        urlRepository.Get("short-code");
        mockStorage.Received(1).Get("short-code");
    }
}