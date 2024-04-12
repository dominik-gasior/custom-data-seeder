using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Seeders.EntityFrameworkCore;

public static class SeederExtensions
{
    public static void Seed<T>(
        this ModelBuilder modelBuilder,
        string folderName = "",
        string? fileName = null,
        JsonSerializerSettings? options = null)
        where T : class
    {
        options ??= GetSerializer();
        
        var seeder = new Seeder(options);
        
        modelBuilder.Entity<T>().HasData(seeder.FromJson<T>(folderName, fileName));
    }

    public static void Seed<T>(
        this DbContext context,
        string folderName = "",
        string? fileName = null,
        JsonSerializerSettings? options = null)
        where T : class
    {
        options ??= GetSerializer();
        
        var seeder = new Seeder(options);
        
        context.Set<T>().AddRange(seeder.FromJson<T>(folderName, fileName));
        context.SaveChanges();
    }

    private static JsonSerializerSettings GetSerializer()
        => new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };
}