using Newtonsoft.Json;
using AssemblyExtensions = Seeders.Extensions.AssemblyExtensions;

namespace Seeders;

public class Seeder
{
    private readonly JsonSerializerSettings _jsonSerializerSettings;

    public Seeder(JsonSerializerSettings jsonSerializerSettings)
    {
        _jsonSerializerSettings = jsonSerializerSettings;
    }
    // - all data can manipulate with using faker library.
    
    // - fetch data from json from solution with using reflection and then generate object with using mapping mechanism.

    public T FromJson<T>(
        string folderName = "",
        string fileName = nameof(T)) 
        where T : class
        => Deserialize<T>(AssemblyExtensions.GetResource(fileName, folderName));

    // - fetch data from csv from solution with using reflection and then generate object with using mapping mechanism.

    // - mechanism for generate random data to database after run on development environment.

    // - mechanism for generate random data to test database

    // - also can be used data from other sources like api, external repository, etc. (if our data have a big size)
    
    private T Deserialize<T>(string resource)
        => JsonConvert.DeserializeObject<T>(resource, _jsonSerializerSettings) ??
           throw new ArgumentNullException();
    
}