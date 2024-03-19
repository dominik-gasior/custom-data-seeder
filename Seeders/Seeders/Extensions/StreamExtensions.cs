namespace Seeders.Extensions;

internal static class StreamExtensions
{
    internal static string FetchDataFromStream(string resourceSource)
    {
        var streamData = Seeder._callingAssembly.GetManifestResourceStream(resourceSource);
        using StreamReader reader = new StreamReader(streamData ?? throw new InvalidOperationException());
        return reader.ReadToEnd();
    }
}