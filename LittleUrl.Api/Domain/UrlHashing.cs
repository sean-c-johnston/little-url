using System.Text;
using Fnv1a;

namespace LittleUrl.Api.Domain;

public class UrlHashing
{
    private readonly Fnv1a32 _hashing = new();

    public string GenerateHash(string input)
    {
        _hashing.Append(Encoding.UTF8.GetBytes(input));
        return BitConverter.ToInt32(_hashing.GetCurrentHash(), 0).ToString();
    }
}