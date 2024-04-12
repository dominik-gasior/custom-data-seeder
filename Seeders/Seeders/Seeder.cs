using System.Reflection;
using Bogus;
using Newtonsoft.Json;
using AssemblyExtensions = Seeders.Extensions.AssemblyExtensions;

namespace Seeders;

public class Seeder
{
    private readonly JsonSerializerSettings _jsonSerializerSettings;
    internal static Assembly _callingAssembly;

    public Seeder(JsonSerializerSettings jsonSerializerSettings)
    {
        _jsonSerializerSettings = jsonSerializerSettings;
        _callingAssembly = Assembly.GetCallingAssembly();
    }
    
    public T FromJson<T>(
        string folderName = "",
        string? fileName = null)
        where T : class
    {
        Type type = typeof(T);

        if (type.GenericTypeArguments.Length == 0)
            return DeserializeToObject<T>(AssemblyExtensions.GetResource(fileName ?? typeof(T).Name, folderName));
        
        return DeserializeToObjects<T>(AssemblyExtensions.GetResource(fileName ?? type.GenericTypeArguments[0].Name, folderName));
    }
    
    public Faker<T> FromJsonToFaker<T>(
        string folderName = "",
        string? fileName = null)
        where T : class
        => new Faker<T>().CustomInstantiator(_ => FromJson<T>(folderName, fileName));
    
    private T DeserializeToObject<T>(string resource)
        => JsonConvert.DeserializeObject<T>(resource, _jsonSerializerSettings) ??
           throw new ArgumentNullException();
    
    private T DeserializeToObjects<T>(string resource)
        => JsonConvert.DeserializeObject<T>(resource, _jsonSerializerSettings) ??
           throw new ArgumentNullException();
}