using System.Reflection;
using System.Resources;
using Newtonsoft.Json;

namespace Seeders;

public static class Seeder
{
    // - all data can manipulate with using faker library.
    
    // - fetch data from json from solution with using reflection and then generate object with using mapping mechanism.
    
    public static T FromJson<T>(
        string folderName = "",
        string fileName = nameof(T))
        where T : class
    {
        string[] existResources = Assembly.GetCallingAssembly().GetManifestResourceNames();
        
        string? resource = null;

        if (!string.IsNullOrEmpty(folderName))
        {
            folderName = "." + folderName + ".";
            foreach (var existResource in existResources)
                if (existResource.Contains(fileName) &&
                    existResource.Contains(folderName))
                {
                    resource = existResource;
                    break;
                }
        }
        else
        {
            foreach (var existResource in existResources)
                if (existResource.Contains(fileName))
                {
                    resource = existResource;
                    break;
                }
        }
        
        if (string.IsNullOrEmpty(resource))
            throw new ArgumentException("Resource not found. Check file name.");
        
        Assembly assembly = Assembly.GetCallingAssembly();
        
        using Stream stream = assembly.GetManifestResourceStream(resource)!;
        
        using StreamReader reader = new StreamReader(stream ?? throw new MissingManifestResourceException());
        var result = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
        return result ?? throw new ArgumentNullException();
    }

    // - fetch data from csv from solution with using reflection and then generate object with using mapping mechanism.

    // - mechanism for generate random data to database after run on development environment.

    // - mechanism for generate random data to test database

    // - also can be used data from other sources like api, external repository, etc. (if our data have a big size)
}