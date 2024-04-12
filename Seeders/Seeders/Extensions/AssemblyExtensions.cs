namespace Seeders.Extensions;

internal static class AssemblyExtensions
{
    internal static string GetResource(string fileName, string? folderName = null)
    {
        string[] existResources = Seeder._callingAssembly.GetManifestResourceNames();
        
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
            if (HasDuplicates(existResources))
                throw new ArgumentException("Resource names must be unique. Check file name.");
            
            foreach (var existResource in existResources)
                if (existResource.Contains(fileName))
                {
                    resource = existResource;
                    break;
                }
        }
        
        if (string.IsNullOrEmpty(resource))
            throw new ArgumentException("Resource not found. Check file name.");

        return StreamExtensions.FetchDataFromStream(resource);
    } 
    
    private static bool HasDuplicates(IEnumerable<string> list)
    {
        var hashSet = new HashSet<string>();
        foreach (var item in list)
        {
            var elements = item.Split(".");
            
            if (!hashSet.Add(elements[^2]))
            {
                return true;
            }
        }
        return false;
    }
}