namespace LittleUrl.Api.Core;

public static class HttpResponseMessageExtensions
{
    public static async Task<string> StringContent(this Task<HttpResponseMessage> msg)
    {
        return await (await msg).Content.ReadAsStringAsync();
    }
}